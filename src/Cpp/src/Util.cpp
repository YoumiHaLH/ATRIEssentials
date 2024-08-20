#include "Util.h"
#include "Windows.h"
#include "extern/extern.h"

#include <vector>
char* wide_Char_To_Multi_Byte(const wchar_t* pWCStrKey) {
    int   pSize    = WideCharToMultiByte(CP_OEMCP, 0, pWCStrKey, wcslen(pWCStrKey), NULL, 0, NULL, NULL);
    char* pCStrKey = new char[pSize + 1];
    WideCharToMultiByte(CP_OEMCP, 0, pWCStrKey, wcslen(pWCStrKey), pCStrKey, pSize, NULL, NULL);
    pCStrKey[pSize] = '\0';
    return pCStrKey;
}
extern "C"{
}
