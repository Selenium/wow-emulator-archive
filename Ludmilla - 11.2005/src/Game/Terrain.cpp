#include <iostream>
#include <vector>
#include <string>

#define MAX_MAP					512	// Max map ID increase if Blizzard adds more
#define ADT_ARRAY_DIMENSION		64
#define ADT_ARRAY_MID			32
#define ADT_CHUNKS				16
#define ADT_CHUNK_Z1			9
#define ADT_CHUNK_Z2 			8
#define ADT_CHUNK1_SIZE 		ADT_CHUNK_Z1 * ADT_CHUNKS
#define ADT_CHUNK2_SIZE 		ADT_CHUNK_Z2 * ADT_CHUNKS

typedef unsigned int uint;
class LoadMAFile {
private:
		bool									has_no_map;	// import only variable
		bool									is_loaded;
		std::string								filename,stripfilename;
		float									z1[ADT_CHUNK1_SIZE][ADT_CHUNK1_SIZE];
		int										xloc, yloc;	// import only variable
		FILE									*loadma;

public:
	
		LoadMAFile (int map, int xloc, int yloc) {
			char locs[8];
			this->xloc = xloc;
			this->yloc = yloc;

			std::string zoneName = "unknown_zone";
			if (map == 0) 
				zoneName = "Azeroth";
			else
				if (map == 1) 
					zoneName = "Kalimdor";
			memset(locs,0,sizeof(locs));
			sprintf(locs,"%d_%d",xloc,yloc);
			this->filename = "Maps\\Ex";
			this->filename += zoneName;
			this->filename += "\\";
			this->filename += zoneName;
			this->filename += "_";
			this->filename += locs;
			this->filename += ".ma";

			loadma=fopen(this->filename.c_str(),"rb");
			if (loadma == NULL) {
				// Don't even try to load next time
				this->has_no_map = true;
				this->filename = '\0';
				return;
			}
			this->has_no_map = false;
		}
		void load_cached() {
			FILE *loadfile;
			this->filename += ".ma";
			std::cout << "Loading " << this->stripfilename << std::endl ;
			if ((loadfile = fopen(this->stripfilename.c_str(),"rb")) != NULL)	{
				unsigned short bread;
			
				for (int i = 0; i < ADT_CHUNK1_SIZE; i++) {
					for (int j = 0; j < ADT_CHUNK1_SIZE; j++) {
						fread(&bread,sizeof(bread),1,loadfile);
						this->z1[i][j] = bread * 0.0625f;
					}
				}

				this->is_loaded = true;
			}
			this->filename.clear();
		}
		bool cleanable() {
			return this->has_no_map;
		}
};
class WoWTerrainFile
{
private:
		bool									has_no_map;	// import only variable
		bool									is_loaded;
		std::string								filename,stripfilename;
		float									z1[ADT_CHUNK1_SIZE][ADT_CHUNK1_SIZE];
		float									z2[ADT_CHUNK2_SIZE][ADT_CHUNK2_SIZE];	// import only variable
		int										xloc, yloc;	// import only variable
		int										cache_position;
		FILE									*adtread;
public:
		float x0, y0;

		/// <summary>
		/// Default constructor is called by array construction code, by default
		/// set to empty ADT (no file)
		/// </summary>
		WoWTerrainFile (int map, int xloc, int yloc) {
			char locs[8];
			this->is_loaded = false;
			this->xloc = xloc;
			this->yloc = yloc;

			// Starting x and y locations for this chunk
			//this->x0 = xloc * ADT_CHUNK_METERS - 16000;
			//this->y0 = yloc * ADT_CHUNK_METERS - 16000;

			std::string zoneName = "unknown_zone";
			if (map == 0) 
				zoneName = "Azeroth";
			else
				if (map == 1) 
					zoneName = "Kalimdor";
			memset(locs,0,sizeof(locs));
			sprintf(locs,"%d_%d",xloc,yloc);
			this->filename = "Maps\\";
			this->filename += zoneName;
			this->filename += "\\";
			this->filename += zoneName;
			this->filename += "_";
			this->filename += locs;
			this->filename += ".adt";

			this->stripfilename += zoneName;
			this->stripfilename += "_";
			this->stripfilename += locs;
			
			adtread=fopen(this->filename.c_str(),"rb");
			if (adtread == NULL) {
				// Don't even try to load next time
				this->has_no_map = true;
				this->filename = '\0';
				return;
			}
			this->has_no_map = false;
		}

		/// <summary>
		/// Read ADT file contents in memory
		/// </summary>
		void load_adt() {
			if (this->has_no_map) return;

			std::cout << "Reading " << this->filename.c_str() << std::endl;
			
			long			pos = 0;
			uint			chunk_size;
			char			b[5];

			uint			xloc = 0;
			uint			yloc = 0;

			b[4] = 0;

			// This code relies that ADT always contains 16x16 chunks of
			// 8x8 and 9x9 float arrays (144 float heights)
			//
			while (!feof(adtread)) {
				// Read chunk title (reversed, ends with 'M')
				fread(b,4,1,adtread);
				std::string cname = b;
				
				if (cname.length() == 0) break;	// END OF LOADING ADT
				if (cname.length() == 4 && cname.c_str()[3] != 'M') break;	// END OF LOADING ADT

				pos = ftell(adtread);
				
				if (!feof(adtread)) break;	// END OF LOADING ADT

				fread(&chunk_size,sizeof(uint),1,adtread);

				//Log ("Chunk '{0}' size={1} at {2}", cname, chunk_size, pos);

				// We're interested only in CNK chunk, skip other
				if (cname.compare("KNCM")) {
					fseek(adtread,pos+(long)chunk_size+4,SEEK_CUR);
					continue;
				}

				// Read x, y, z from chunk header
				//  +0x68
				fseek(adtread,pos+0x6C,SEEK_CUR);

				float x, y, z;
				fread(&x,sizeof(x),1,adtread);
				fread(&y,sizeof(y),1,adtread);
				fread(&z,sizeof(z),1,adtread);

				// std::cout << x << " " << y << " " << z << std::endl;

				if (xloc == 0 && yloc == 0) {
					// Save x0 and y0 for future
					this->x0 = x;
					this->y0 = y;
				}

				fseek(adtread,pos+0x90,SEEK_CUR);
				
				char temp;
				for (int i = 0; i < ADT_CHUNK_Z1; i++) {
					for (int j = 0; j < ADT_CHUNK_Z1; j++) {
						fread(&temp,sizeof(temp),1,adtread);
						this->z1[ADT_CHUNK_Z1+j][ADT_CHUNK_Z1+i] = temp + z;
					}
				}

				for (int i = 0; i < ADT_CHUNK_Z2; i++) {
					for (int j = 0; j < ADT_CHUNK_Z2; j++) {
						fread(&temp,sizeof(temp),1,adtread);
						this->z2[ADT_CHUNK_Z2+j][ADT_CHUNK_Z2+i] = temp + z;
					}
				}

				// Step to next buffer
				yloc++;
				if (yloc >= 16) {
					xloc++;
					yloc = 0;
				}

				fseek(adtread,pos + (long)chunk_size + 4,SEEK_CUR);
			}

			fclose(adtread);
			adtread = NULL;

			// Mark ourself, that we're not empty now!
			this->has_no_map = false;
			this->is_loaded = true;
		}
		/// <summary>
		/// Save this chunk to big cache file, save index information too
		/// </summary>
		
		void save_cache () {
			
            FILE *savefile;
			int i,j;
			this->stripfilename += ".ma";
			int ADT_CHUNK_z1=ADT_CHUNK_Z1,ADT_CHUNK_z2=ADT_CHUNK_Z2;
			if (!this->has_no_map || this->is_loaded) {
				if ((savefile = fopen(this->stripfilename.c_str(),"wb+"))!=NULL) {
					for (i = 0; i < ADT_CHUNK_z1; i++) {
						for (j = 0; j < ADT_CHUNK_z1; j++) {
							fwrite(&this->z1[ADT_CHUNK_z1+j][ADT_CHUNK_z1+i],4,1,savefile);
						}
					}

					for (i = 0; i < ADT_CHUNK_z2; i++) {
						for (j = 0; j < ADT_CHUNK_z2; j++) {
							fwrite(&this->z2[ADT_CHUNK_z2+j][ADT_CHUNK_z2+i],4,1,savefile);
						}
					}
					fclose(savefile);
					savefile=NULL;
				}
			}
		}

		void load_cached() {
			FILE *loadfile;
			this->stripfilename += ".ma";
			std::cout << "Loading " << this->stripfilename << std::endl ;
			if ((loadfile = fopen(this->stripfilename.c_str(),"rb")) != NULL)	{
				unsigned short bread;
			
				for (int i = 0; i < ADT_CHUNK1_SIZE; i++) {
					for (int j = 0; j < ADT_CHUNK1_SIZE; j++) {
						fread(&bread,sizeof(bread),1,loadfile);
						this->z1[i][j] = bread * 0.0625f;
					}
				}

				this->is_loaded = true;
			}
		}

		void print() {
			for (int i = 0; i < ADT_CHUNK1_SIZE; i++) {
				for (int j = 0; j < ADT_CHUNK1_SIZE; j++) {
					std::cout << "Z1: " << this->z1[i][j] <<std::endl;
				}
			}
		}
		
		/// <summary>
		/// public: Get elevation of terrain at specified location
		/// </summary>
		float GetTerrainZ (float x, float y) {
			//if (this.has_no_map) return 10001;
			if (!this->is_loaded) this->load_cached();
			
			if (!this->is_loaded) {
				// Log ("ERR still not loaded after called load_cached()");
				return 10002;
			}

			int	xi = (int)((this->x0 - x) * 0.270007); // = / 3.7036);
			int	yi = (int)((this->y0 - y) * 0.270007); // = / 3.7036);

			//Log ("GetTerrainZ xi={0} yi={1} :: x0={2} y0={3}", xi, yi, this.x0, this.y0);

			if (xi < 0) { /* Log ("ERR xi < 0!");*/ return 10003; }
			if (xi >= ADT_CHUNK1_SIZE) { /*Log ("ERR xi is too big!");*/ return 10004; }
			if (yi < 0) { /*Log ("ERR yi < 0!");*/ return 10005; }
			if (yi >= ADT_CHUNK1_SIZE) { /*Log ("ERR yi is too big!");*/ return 10006; }

			//Log ("{0} {1} {2} {3}", z1[xi, yi], z1[xi-1, yi], z1[xi, yi-1], z1[xi-1, yi-1]);
			return this->z1[xi][yi];
		}
};
 //small example on using the system
/*
int main()
{
	LoadMAFile *load_maps[64][64];
	
	for(int i = 0; i < 64; i++) {
		for(int j = 0; j < 64; j++) {
			load_maps[i][j] = new LoadMAFile(0,i,j);
			if(load_maps[i][j]->cleanable()) {
				std::cout << "deleting " << i << ", " << j <<std::endl;
				delete load_maps[i][j];
				load_maps[i][j] = NULL;
			}
		}
	}
	for(int i = 0; i < 64; i++) {
		for(int j = 0; j < 64; j++) {
			if(load_maps[i][j] != NULL)
				delete load_maps[i][j];
		}
	}
	return 0;
}
*/