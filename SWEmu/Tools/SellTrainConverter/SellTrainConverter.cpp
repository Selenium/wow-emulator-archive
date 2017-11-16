// SellTrainConverter.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#define _FileExists(filename) ( (_access( filename, 0 )) != -1 )

int _tmain(int argc, _TCHAR* argv[])
{
	long creatureid;
	if (_FileExists("creatures.scp"))
	{
		FILE *f = fopen("creatures.scp","rt");
		char intext[128];
		if (f)
		{
			FILE *ftrain = fopen("trainertemplates.bin","wb");
			FILE *fsell = fopen("selltemplates.bin","wb");
			_TrainerItem traini;
			_SellItem selli;
			int traincount = 0;
			int sellcount = 0;
			while (fgets(intext,120,f))
			{
				intext[strlen(intext)-1]=0;
				if(!strncmp(intext,"[creature",9))
				{
					strtok(intext," ");
					// char *tempnum = 
					creatureid = atoi(strtok(NULL,"]"));
					printf("setting creature to %d\r\n",creatureid);
				}
				if(!strncmp(intext,"sell=",5))
				{
					// Sell!
					char *meh = strtok(intext,"=");
					long itemnumber = atoi(strtok(NULL,"\n"));
					printf("creature %d: SELL %d\r\n",creatureid,itemnumber);
					selli.CreatureTemplateGuid = creatureid;
					selli.SellID = itemnumber;
					fwrite(&selli,sizeof(selli),1,fsell);
					sellcount++;
				}
				if(!strncmp(intext,"train=",6))
				{
					// Train!
					char *meh = strtok(intext,"=");
					long itemnumber = atoi(strtok(NULL,"\n"));
					printf("creature %d: TRAIN %d\r\n",creatureid,itemnumber);
					traini.CreatureTemplateGuid = creatureid;
					traini.SpellID = itemnumber;
					fwrite(&traini,sizeof(traini),1,ftrain);
					traincount++;
				}


				//printf("%s",intext);
			}
			fclose(f);
			fclose(ftrain);
			fclose(fsell);
			printf("\r\n\r\nWrote %d sell items and %d trainer items",sellcount,traincount);
		}
	}
	return 0;
}

