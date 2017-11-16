// (c) AbyssX Group
#include <stdio.h>
#include <string>

using namespace std;

unsigned char charToChar(unsigned char c)
{
	if (c >= '0' && c <= '9')
		return (c - '0');
	if (c >= 'A' && c <= 'F')
		return (c - 'A') + 10;
	return 0x00;
}

unsigned char getHex(FILE *fp)
{
	unsigned char c, ret;

	do
	{
		fread(&c, 1, 1, fp);
	} while (isspace(c));

	ret = charToChar(c) * 16;
	fread(&c, 1, 1, fp);
	ret += charToChar(c);

	return ret;
}
	
string getToWhite(FILE *fp)
{
	string ret;
	char c;

	while (fread(&c, 1, 1, fp))
	{
		if (isspace(c))
			return ret;
		ret.push_back(c);
	}
	return ret;
}

void skipWhite(FILE *fp)
{
	char c;

	while (fread(&c, 1, 1, fp))
	{
		if (!isspace(c))
		{
			fseek(fp, -1, SEEK_CUR);
			return;
		}
	}
}

void skipToNewline(FILE *fp)
{
	char c;

	while (true)
	{
		fread(&c, 1, 1, fp);
		if (c == '\n')
			break;
	}
}

int main(int argc, char **argv)
{
	FILE *fpin;
	FILE *fpout;
	string tmp;
	bool dontlog;
	unsigned short i, j;

	char send;
	string rhost, shost;
	unsigned short len;
	string data;


	if (argc < 3) 
	{
		fprintf(stderr, "Usage: %s <in> <out>\n", argv[0]);
		return 0;
	}

	fpin = fopen(argv[1], "r");
	if (!fpin)
	{
		fprintf(stderr, "Unable to open '%s'\n", argv[1]);
		return 0;
	}
	
	fpout = fopen(argv[2], "wb");
	if (!fpout)
	{
		fclose(fpin);
		fprintf(stderr, "Unable to open '%s'\n", argv[2]);
		return 0;
	}

	while (true)
	{
		getToWhite(fpin); // Packet Number
		skipWhite(fpin);

		if (feof(fpin))
			break;

		shost = getToWhite(fpin); // Sending Host
		skipWhite(fpin);

		rhost = getToWhite(fpin); // Recieving Host
		if (rhost == "127.0.0.1" && shost == "127.0.0.1")
			dontlog = true;
		else
			dontlog = false;
		skipWhite(fpin);

		tmp = getToWhite(fpin); // Data len
		len = (unsigned short)atoi(tmp.c_str());
		skipWhite(fpin);

		tmp = getToWhite(fpin); // Send / Recv strings
		if (tmp[0] == 'R')
			send = 0;
		if (tmp[0] == 'S')
			send = 1;
		skipWhite(fpin);

		// Data collection:
		data.erase();
		for (i = 0; i < len / 16; i++)
		{
			getToWhite(fpin); // Packet offset
			skipWhite(fpin);

			for (j = 0; j < 16; j++)
				data.push_back(getHex(fpin));
			skipToNewline(fpin);
		}

		if (data.length() < len)
		{
			getToWhite(fpin); // Packet offset
			skipWhite(fpin);

			for (i = (unsigned short) data.length(); i < len; i++)
			{
				data.push_back(getHex(fpin));
				skipWhite(fpin);
			}
			skipToNewline(fpin);
		}
		skipWhite(fpin);

		if (!dontlog)
		{
			unsigned char hlen;

	    fwrite(&send, 1, 1, fpout);
			if (send)
				hlen = (unsigned char)rhost.length();
			else
				hlen = (unsigned char)shost.length();
			fwrite(&hlen, 1, 1, fpout);
			if (send)
				fwrite(rhost.c_str(), hlen, 1, fpout);
			else
				fwrite(shost.c_str(), hlen, 1, fpout);
			fwrite(&len, 2, 1, fpout);
			fwrite(data.c_str(), 1, len, fpout);
		}
	}

	fclose(fpin);
	fclose(fpout);

	return 0;
}
	