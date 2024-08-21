#pragma once
#include <string>
#define _C(wcharStr) (WcharToChar(wcharStr))
std::string WcharToChar(const wchar_t* wcharStr);