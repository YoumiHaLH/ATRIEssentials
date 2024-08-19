#include "extern.h"
#include "mod/MyMod.h"
#include "Util.h"
#include "string"
extern "C" {
	EXTERN void info(const char* cha) { 
	 my_mod::MyMod::getInstance().getSelf().getLogger().info(cha);
    }
    EXTERN void error(const char* cha) {
        std::string s = "\033[0m\033[1;4;41;33m";
        s += cha;
        s += "\033[0m";
        my_mod::MyMod::getInstance().getSelf().getLogger().error(s);
    }
    EXTERN void warn(const char* cha) {
	    my_mod::MyMod::getInstance().getSelf().getLogger().warn(cha);
    }
}