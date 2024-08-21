#include "Util.h"
#include "extern.h"
#include "ll/api/form/SimpleForm.h"
#include <mc/math/vector/component/BoolN.h>
extern  "C" {
    typedef wchar_t* string;
EXTERN ll::form::SimpleForm* SimpleForm_() {
     auto ptr = new ll::form::SimpleForm();
     return ptr;
 }
EXTERN void setTitle_S(ll::form::SimpleForm* ptr,string chr) {
     ptr->setTitle(_C(chr));   
 }
 EXTERN void setContent_S(ll::form::SimpleForm* ptr,string str) {
    ptr->setContent(_C(str));
 }
EXTERN void addButton_img_S(ll::form::SimpleForm* ptr,string str,string str2,INVOKE invoke,int type) {
  std::string a;
     switch (type) {
     case 0:
       a = "path";
         break;
     case 1:
       a = "url";
     }
     ptr->appendButton(_C(str),_C(str2),a, [invoke](Player & player) -> void {
         invoke(&player);
     });
 }
EXTERN void addButton_S(ll::form::SimpleForm* ptr,string str,INVOKE invoke) { ptr->appendButton(_C(str), [invoke](Player& player)->void {
    invoke(&player) ;
});
}
 EXTERN void SendTo_S(ll::form::SimpleForm* ptr,Player* player) {
    ptr->sendTo(*player);
    delete ptr;
 }
}