//#pragma comment(lib, "./nethost.lib")
#include "stdio.h"
#include <Windows.h>
#include <assert.h>
#include <chrono>
#include <mod/.NETExport/coreclr_delegates.h>
#include <mod/.NETExport/hostfxr.h>
#include <iostream>
#include <mod/.NETExport/nethost.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <thread>
#include <vector>
#define STR(s)         L##s
#define CH(c)          L##c
#define DIR_SEPARATOR  L'\\'
#define string_compare wcscmp
using string_t = std::basic_string<char_t>;

namespace {

hostfxr_initialize_for_dotnet_command_line_fn init_for_cmd_line_fptr;
hostfxr_initialize_for_runtime_config_fn      init_for_config_fptr;
hostfxr_get_runtime_delegate_fn               get_delegate_fptr;
hostfxr_run_app_fn                            run_app_fptr;
hostfxr_close_fn                              close_fptr;
bool                                          load_hostfxr(const char_t* app);
load_assembly_and_get_function_pointer_fn     get_dotnet_load_assembly(const char_t* assembly);
void* run_component(const string_t& root_path);
component_entry_point_fn GetMethod(
    load_assembly_and_get_function_pointer_fn& load_assembly_and_get_function_pointer,
   const string_t&                                  dotnetlib_path,
   const char_t*&                                    dotnet_type,
   const char_t*                                    dotnet_type_method
);
} // namespace

void LoadMain() {
    char_t host_path[MAX_PATH];
    auto   size = ::GetFullPathNameW(L"bedrock_server_mod.exe", sizeof(host_path) / sizeof(char_t), host_path, nullptr);
    assert(size != 0);
    string_t root_path = host_path;
    auto     pos       = root_path.find_last_of(DIR_SEPARATOR);
    assert(pos != string_t::npos);
    root_path = root_path.substr(0, pos + 1);
    run_component(root_path);
}
namespace {
void* run_component(const string_t& root_path) {

    if (!load_hostfxr(nullptr)) {
        assert(false && "Failure: load_hostfxr()");
        return nullptr;
    }
    const string_t config_path = root_path + STR("plugins\\ATRIEssentials\\.lib\\tmp.json");
    load_assembly_and_get_function_pointer_fn load_assembly_and_get_function_pointer = nullptr;
    load_assembly_and_get_function_pointer = get_dotnet_load_assembly(config_path.c_str());
    assert(load_assembly_and_get_function_pointer != nullptr && "Failure: get_dotnet_load_assembly()");
    const string_t           dotnetlib_path     = root_path + STR("plugins\\ATRIEssentials\\.lib\\ATRIEssentialsPluginMainProject.dll");
    const char_t*            dotnet_type        = STR("ATRIEssentials.PluginMain, ATRIEssentialsPluginMainProject");
    const char_t*            dotnet_type_method = STR("load");
    component_entry_point_fn PluginMain         = nullptr;
    int                      rc                 = load_assembly_and_get_function_pointer(
        dotnetlib_path.c_str(),
        dotnet_type,
        dotnet_type_method,
        nullptr,
        nullptr,
        (void**)&PluginMain
    );
    assert(rc == 0 && PluginMain != nullptr && "Failure: load_assembly_and_get_function_pointer()");
    PluginMain(nullptr,0);
    return nullptr;
}
component_entry_point_fn GetMethod(
    load_assembly_and_get_function_pointer_fn& load_assembly_and_get_function_pointer,
   const string_t&                                  dotnetlib_path,
   const char_t*&                                    dotnet_type,
   const char_t*                                    dotnet_type_method
) {
    component_entry_point_fn PluginMain = nullptr;
    int rc = load_assembly_and_get_function_pointer(
        dotnetlib_path.c_str(),
        dotnet_type,
        dotnet_type_method,
        nullptr,
        nullptr,
        (void**)&PluginMain
    );
    assert(rc == 0 && PluginMain != nullptr && "Failure: load_assembly_and_get_function_pointer()");
    return PluginMain;
}
} // namespace
namespace {
void* load_library(const char_t*);
void* get_export(void*, const char*);
void* load_library(const char_t* path) {
    HMODULE h = ::LoadLibraryW(path);
    assert(h != nullptr);
    return (void*)h;
}
void* get_export(void* h, const char* name) {
    void* f = ::GetProcAddress((HMODULE)h, name);
    assert(f != nullptr);
    return f;
}

bool load_hostfxr(const char_t* assembly_path) {
    typedef int(_cdecl * get_hostfxr_patah)(
        char_t * buffer,
        size_t * buffer_size,
        const struct get_hostfxr_parameters* parameters
    );
    HMODULE hmod =  LoadLibrary(L"F:\\bds1.21.2\\plugins\\ATRIEssentials\\.lib\\nethost.dll");
    auto   get_hostfxr_path = (get_hostfxr_patah)GetProcAddress(hmod, "get_hostfxr_path");
    get_hostfxr_parameters params{sizeof(get_hostfxr_parameters), assembly_path, nullptr};
    // Pre-allocate a large buffer for the path to hostfxr
    char_t buffer[MAX_PATH];
    size_t buffer_size = sizeof(buffer) / sizeof(char_t);
    int    rc          = get_hostfxr_path(buffer, &buffer_size, &params);
    if (rc != 0) {
        return false;
    }
    void* lib = load_library(buffer);
    init_for_cmd_line_fptr =
        (hostfxr_initialize_for_dotnet_command_line_fn)get_export(lib, "hostfxr_initialize_for_dotnet_command_line");
    init_for_config_fptr =
        (hostfxr_initialize_for_runtime_config_fn)get_export(lib, "hostfxr_initialize_for_runtime_config");
    get_delegate_fptr = (hostfxr_get_runtime_delegate_fn)get_export(lib, "hostfxr_get_runtime_delegate");
    run_app_fptr      = (hostfxr_run_app_fn)get_export(lib, "hostfxr_run_app");
    close_fptr        = (hostfxr_close_fn)get_export(lib, "hostfxr_close");

    return (init_for_config_fptr && get_delegate_fptr && close_fptr);
}
load_assembly_and_get_function_pointer_fn get_dotnet_load_assembly(const char_t* config_path) {
    // Load .NET Core
    void*          load_assembly_and_get_function_pointer = nullptr;
    hostfxr_handle cxt                                    = nullptr;
    int            rc                                     = init_for_config_fptr(config_path, nullptr, &cxt);
    if (rc != 0 || cxt == nullptr) {
        std::cerr << "Init failed: " << std::hex << std::showbase << rc << std::endl;
        close_fptr(cxt);
        return nullptr;
    }

    // Get the load assembly function pointer
    rc = get_delegate_fptr(cxt, hdt_load_assembly_and_get_function_pointer, &load_assembly_and_get_function_pointer);
    if (rc != 0 || load_assembly_and_get_function_pointer == nullptr) {
        std::cerr << "Get delegate failed: " << std::hex << std::showbase << rc << std::endl;
    }

    close_fptr(cxt);
    return (load_assembly_and_get_function_pointer_fn)load_assembly_and_get_function_pointer;
}
} // namespace
