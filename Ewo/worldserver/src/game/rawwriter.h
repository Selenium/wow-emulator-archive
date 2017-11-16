#include <string.h>
 
class RAWWriter
{
    private:
       unsigned char *Output;
        int Position;
		char opcodegroup;

    public:
        RAWWriter(char *Buffer) : Output(Buffer), Position(0) {}
		Packet(char opcode) : Position(4) 
		{
			//an overflow can occur here if not careful!
			Output = (unsigned char*)calloc(10000,sizeof(unsigned char)); //10000 is plenty
			ClearBuffer();
			this->opcodegroup = opcode;
		}

        inline int GetLength()
        {
            return Position;
        }
		
		void ClearBuffer()
		{
			memset(Output,0,sizeof(Output));
		}

		void SetPositon(int PositionToSet)
		{
			Position = PositionToSet;
		}
		void FillBuffer(unsigned char filler, int howmany)
		{
			for(int i = 0; i<howmany; i++)
			{
				Output[Position] = filler;
				Position++;
			}

		}
		void InsertString(char* buffer,int size)
		{
			memcpy(&Output[Position],buffer,size);
            this->SetPositon((Position + size));
		}

        template<class T> RAWWriter &operator<<(T Value)
        {
            memcpy(&Output[Position], &Value, sizeof(Value));
            Position += sizeof(Value);
            return *this;
        }
};