using System;
using System.Collections.Generic;
using System.Text;

namespace eWoW
{

    enum CHAR : byte // Error codes for CharacterHandler
    {
        CREATE_OK			    = 0x2E,
        CREATE_FAILED		    = 0x30,
	    CREATE_NAME_IN_USE      = 0x31,
        CREATE_NOT_SAME_SIDE    = 0x33,
        CREATE_MAX_PLAYER_REALM = 0x34,
	    DELETE_OK			    = 0x35,
	    DELETE_FAIL		        = 0x36,
    }
}
