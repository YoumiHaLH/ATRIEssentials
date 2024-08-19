#pragma once

#include "ll/api/mod/NativeMod.h"

namespace my_mod {

class MyMod {

public:
    static MyMod& getInstance();

    MyMod(ll::mod::NativeMod& self) : mSelf(self) {}

    [[nodiscard]] ll::mod::NativeMod& getSelf() const { return mSelf; }

    /// @return True if the mod is loaded successfully.
    bool load();
    bool enable();
    bool disable();

    // TODO: Implement this method if you need to unload the mod.
    // /// @return True if the mod is unloaded successfully.
    // bool unload();
private:
    ll::mod::NativeMod& mSelf;
};

} 
