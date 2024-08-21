using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATRIEssentialsPluginMainProject.MCApi.Form.Simple;
using ATRIEssentialsPluginMainProject.MCApi.MCActor;

namespace ATRIEssentialsPluginMainProject.MCApi.Form
{
    internal class SimpleForm
    {
        internal ISimpleForm Simple = new LLApi.LLMCAPI.Form.SimpleForm();

        public void setTitle(string str)
        {
            Simple.setTitle(str);
        }

        public void setContent(string str)
        {
            Simple.setContent(str);
        }

        public void addButton(string str1, string str2,ISimpleForm.ImgType ty, CallBack ck)
        {
            Simple.addButton(str1, str2, ty,ck);
        }

        public void addButton(string str1, CallBack ck)
        {
           Simple.addButton(str1, ck);
        }

        public void SendTo(Player pl)
        {
            Simple.SendTo(pl.ptr);
        }
    }
}
