#include "Util.h"
#include "Windows.h"
#include "extern/extern.h"
#include <vector>
std::string WcharToChar(const wchar_t* wcharStr) {
    int bufferSize = WideCharToMultiByte(CP_UTF8, 0, wcharStr, -1, nullptr, 0, nullptr, nullptr);
    if (bufferSize == 0) {
        return "";
    }
    std::string charStr(bufferSize, 0);
    WideCharToMultiByte(CP_UTF8, 0, wcharStr, -1, &charStr[0], bufferSize, nullptr, nullptr);
    return charStr;
}

