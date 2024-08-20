#include "extern/extern.h"
#include "string"
#include <ll/api/form/CustomForm.h>
#include <mc/math/vector/component/BoolN.h>
extern  "C"{
typedef const char* string;
EXTERN ll::form::CustomForm* CustomForms() {
    auto cu =  new ll::form::CustomForm();
    
    return cu;
  }
EXTERN void setTitle(ll::form::CustomForm* ptr,const char* cha) {
   (*ptr).setTitle(cha);
 }
EXTERN void addLabel(ll::form::CustomForm* ptr, const char* cha) {
    (*ptr).appendLabel(cha);
}
EXTERN void addInput(ll::form::CustomForm* ptr, const char* cha,const char* cha2,const char* cha3,const char* cha4) {
    (*ptr).appendInput(cha,cha2,cha3,cha4);
}
EXTERN void addSwitch(ll::form::CustomForm* ptr,string cha,string cha2,bool isopen) {
    (*ptr).appendToggle(cha,cha2,isopen);
}

EXTERN void addDropdown(ll::form::CustomForm* ptr, string cha, string cha2, string* a,int len) {
    std::vector<std::string> vec;

    for (int i = 0; i < len; i++) {
        vec.push_back(a[i]);
    } 
    (*ptr).appendDropdown(cha,cha2,vec);
}
EXTERN void SendTo_(ll::form::CustomForm* ptr, Player* player,INVOKE invoke) {
    (*ptr).sendTo(*player, [invoke](Player& player, ll::form::CustomFormResult const& result, ll::form::FormCancelReason) {
        invoke();
    });
    delete ptr;
 }
}