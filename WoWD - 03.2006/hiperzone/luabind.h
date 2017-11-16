
extern "C" {
	#include "lua.h"
	#include "lualib.h"
	#include "lauxlib.h"
};

// luabind
#include "luabind/luabind.hpp"

// even though we won't be usnig any of Lua's return policies in this tutorial, include these files in anctipation
// of the next part of this series
#include "luabind/adopt_policy.hpp"
#include "luabind/out_value_policy.hpp"
#include "luabind/return_reference_to_policy.hpp"

using namespace luabind;


class testclass
{
public:
	void add();
	void remove();

};

