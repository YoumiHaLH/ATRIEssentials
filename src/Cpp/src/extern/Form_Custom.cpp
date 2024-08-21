#include "Util.h"
#include "extern/extern.h"
#include "string"
#include <Windows.h>
#include <ll/api/form/CustomForm.h>
#include <mc/math/vector/component/BoolN.h>
extern  "C"{
typedef  wchar_t* string;
EXTERN ll::form::CustomForm* CustomForms() {
    auto cu =  new ll::form::CustomForm();
    
    return cu;
  }
EXTERN void setTitle(ll::form::CustomForm* ptr,string cha) {
   (*ptr).setTitle(_C(cha));
 }
EXTERN void addLabel(ll::form::CustomForm* ptr, string cha) {
    (*ptr).appendLabel(_C(cha));
}
EXTERN void addInput(ll::form::CustomForm* ptr, string cha,string cha2,string cha3,string cha4) {
    (*ptr).appendInput(_C(cha),_C(cha2),_C(cha3),_C(cha4));
}
EXTERN void addSwitch(ll::form::CustomForm* ptr,string cha,string cha2,bool isopen) {
    (*ptr).appendToggle(_C(cha),_C(cha2),isopen);
}

EXTERN void addDropdown(ll::form::CustomForm* ptr, string cha, string cha2, string a[], int len) {
    std::vector<std::string> vec;
    for (int i = 0; i < len; i++) {
        vec.push_back(_C(a[0]));
    } 
    (*ptr).appendDropdown(_C(cha),_C(cha2),vec);
}
EXTERN void SendTo_(ll::form::CustomForm* ptr, Player* player,INVOKE invoke) {
    (*ptr).sendTo(*player, [invoke](Player& player, ll::form::CustomFormResult const& result, ll::form::FormCancelReason) {
        invoke();
    });
    delete ptr;
 }
}