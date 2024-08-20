
#include "MyMod.h"
// #include "mod/ResOutHelper/releaseHelper.h"
#include "ll/api/mod/RegisterHelper.h"
#include <memory>
#include "filesystem"
#include "Windows.h"
#include "iostream"
void LoadMain();

namespace my_mod {

static std::unique_ptr<MyMod> instance;

MyMod& MyMod::getInstance() { return *instance; }
typedef void(_cdecl* enable_)();
typedef void(_cdecl* disenable_)();
HMODULE hmoudle_;
bool MyMod::load() {
    getSelf().getLogger().title = "\033[0m\033[1;36mATRI\033[0m";
    LoadMain();
    hmoudle_ = GetModuleHandle(L"ATRIEssentialsPluginMainProject.dll");
    return true;
}
bool MyMod::enable() {
    ((enable_)GetProcAddress(hmoudle_, "enable"))();
    return true;
}

bool MyMod::disable() {
    ((disenable_)GetProcAddress(hmoudle_, "disable"))();
    return true;
}
}
LL_REGISTER_MOD(my_mod::MyMod, my_mod::instance);