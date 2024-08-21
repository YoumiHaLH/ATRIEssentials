#include <Windows.h>
#include "string"
std::string WcharToChar(const wchar_t* wcharStr) {
    int bufferSize = WideCharToMultiByte(CP_UTF8, 0, wcharStr, -1, nullptr, 0, nullptr, nullptr);
    if (bufferSize == 0) {
        return "";
    }
    std::string charStr(bufferSize, 0);
    WideCharToMultiByte(CP_UTF8, 0, wcharStr, -1, &charStr[0], bufferSize, nullptr, nullptr);
    return charStr;
}