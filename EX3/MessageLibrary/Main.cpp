#include "MessageEnvironment.h"
#include <conio.h>

// Test harness for the Message Library.

// Function: Main.
int main(int argc, char **argv)
{
	DoubleWord i;
	ChatCommand command("!rawpkt 99 00 00 00 00 4D 79 54 65 73 74 00 01 00 03 00 00 00 00 00", 0x00);
	Byte *data = new Byte[command.GetParameterCount()];

	printf("Command: %s\n", command.GetCommand().c_str());
	printf("Number of parameters: %d\n", command.GetParameterCount());

	for (i = 0; i < command.GetParameterCount(); i++)
	{
		char hex;
		hex = command.GetParameter(i).c_str()[0];
		
		if(hex >= 'a' && hex <= 'f') hex -= 32;
		if(hex >= 'A' && hex <= 'F') data[i] = (hex - 55) << 4;
		else
		if(hex >= '0' && hex <= '9') data[i] = (hex - 48) << 4;

		hex = command.GetParameter(i).c_str()[1];
		
		if(hex >= 'a' && hex <= 'f') hex -= 32;
		if(hex >= 'A' && hex <= 'F') data[i] |= hex - 55;
		else
		if(hex >= '0' && hex <= '9') data[i] |= hex - 48;
	}

	delete data;

	getch();
	return 0;
}
