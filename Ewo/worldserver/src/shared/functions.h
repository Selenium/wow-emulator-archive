// Copyright (C) 2006 Team Evolution
#ifndef FUNCTIONS_H
#define FUNCTIONS_H 1

#ifndef PI
	#define PI 3.1415926538f
#endif

//this function is used at server startup so no need to be very fast
static void safe_strcpy(char *dst,const char* src,uint32 maxlen)
{
//	strcpy(dst,src);
	uint32 len=0;
	while(len<maxlen && src[len]!=0)
	{
		dst[len]=src[len];
		len++;
	}
	//just make sure we have a terminator
	if(len<maxlen) dst[len]=0;
	else dst[maxlen-1]=0;/**/
}

static float get_orientation(float viewer_x,float viewer_y,float target_x, float target_y)
{
	float angle;
	float dif_x = (target_x-viewer_x),dif_y=(target_y-viewer_y);
	if(dif_x!=0)
		angle = atan(dif_y/dif_x);
	else angle = PI / 2;
	if(dif_y < 0 && dif_x < 0) 	angle += PI; //3
	else if(dif_y < 0 && dif_x > 0)	angle = 2*PI - (-angle);//4
	else if(dif_y > 0 && dif_x < 0)	angle = PI - (-angle);//2
	return angle;
}

static void PackGuid(const uint64& sourceguid, uint8* dest, uint32& c)
{
    char guid_mask = 0x00;
    long mask_pos = c;

    // allocate space for mask
    dest[c] = 0x00;                     c++;
    
    // allocate guid ptr
    char *guidptr = ((char*)sourceguid);

    // loop through guid bytes, and find anything thats not 0, and apply to mask
    for(uint8 i=0; i < 8; ++i)
    {
        if(guidptr[i] != 0)
        {
            guid_mask |= (1<<i);    // set corresponding bit to 1
            dest[c] = guidptr[i];   c++;
        }
    }

    // go back, and apply the mask
    dest[mask_pos] = guid_mask;
}

//buffer needs to be atleast 64 bit long (8 byte)
static void UnpackGuid(uint8 *source, uint32 &c, uint8* destination)
{
    char guid_mask = source[c];  c++;
    uint8 tmp = 0x1;

    for(uint8 i = 0; i < 8; ++i)
    {
        if(guid_mask & tmp)
        {
            // that position isn't a 0. append the field
            destination[i] = source[c]; c++;
        } else {
            // else it's 0.
            destination[i] = 0x0;
        }
        tmp = tmp << 1; // move 1 bit back
    }
}
static void UnpackGuid(uint8 *source,uint8* destination)
{
    char guid_mask = source[0];
	char c=1;
    uint8 tmp = 0x1;

    for(uint8 i = 0; i < 8; ++i)
    {
        if(guid_mask & tmp)
        {
            // that position isn't a 0. append the field
            destination[i] = source[c]; c++;
        } else {
            // else it's 0.
            destination[i] = 0x0;
        }
        tmp = tmp << 1; // move 1 bit back
    }
}
#endif FUNCTIONS_H

