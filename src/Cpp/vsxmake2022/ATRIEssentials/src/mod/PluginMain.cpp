#include "mod/MyMod.h"
// #include "mod/ResOutHelper/releaseHelper.h"
#include "ll/api/mod/RegisterHelper.h"
#include <memory>

namespace my_mod {

static std::unique_ptr<MyMod> instance;

MyMod& MyMod::getInstance() { return *instance; }

bool MyMod::load() {
    // BOOL ref = UseCustomResource();
    // std::cout << "ÊÍ·Å×´Ì¬: " << ref << std::endl;
    getSelf().getLogger().debug("Loading...");
    // Code for loading the mod goes here.
    return true;
}
bool MyMod::enable() {
    getSelf().getLogger().debug("Enabling...");
    // Code for enabling the mod goes here.
    return true;
}

bool MyMod::disable() {
    getSelf().getLogger().debug("Disabling...");
    // Code for disabling the mod goes here.
    return true;
}

} // namespace my_mod

LL_REGISTER_MOD(my_mod::MyMod, my_mod::instance);