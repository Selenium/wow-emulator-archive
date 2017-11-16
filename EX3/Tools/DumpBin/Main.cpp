// (c) AbyssX Group
#include <stdio.h>
#include <string>

using namespace std;

int main(int argc, char **argv)
{
	FILE *fpin;
	FILE *fpout;
	unsigned char c;
	unsigned short i;

	unsigned char send;
	unsigned char hlen;
	string host;
	unsigned short dlen;
	string data;

	if (argc < 3) 
	{
		fprintf(stderr, "Usage: %s <in> <out>\n", argv[0]);
		return 0;
	}
	
	fpin = fopen(argv[1], "rb");
	if (!fpin)
	{
		fprintf(stderr, "Unable to open '%s'\n", argv[1]);
		return 0;
	}
	
	fpout = fopen(argv[2], "w");
	if (!fpout)
	{
		fclose(fpin);
		fprintf(stderr, "Unable to open '%s'\n", argv[2]);
		return 0;
	}

	while (true)
	{
		fread(&send, 1, 1, fpin);
		if (feof(fpin))
			break;
		fread(&hlen, 1, 1, fpin);
		host.erase();
		for (i = 0; i < hlen; i++)
		{
			fread(&c, 1, 1, fpin);
			host.push_back(c);
		}
		data.erase();
		fread(&dlen, 1, 2, fpin);
		for (i = 0; i < dlen; i++)
		{
			fread(&c, 1, 1, fpin);
			data.push_back(c);
		}

		fprintf(fpout, "%s data %s %s:\n", send ? "Sent" : "Received",
			send ? "to" : "from", host.c_str());
		for (i = 0; i < dlen; i++)
			fprintf(fpout, "%02X%s", (unsigned char)data[i], ((i + 1) % 8) ? " " : "\n");
		if (((i + 1) % 8) == 0)
			fprintf(fpout, "\n\n");
		else
			fprintf(fpout, "\n\n");
	}

	fclose(fpin);
	fclose(fpout);

	return 0;
}
 
 