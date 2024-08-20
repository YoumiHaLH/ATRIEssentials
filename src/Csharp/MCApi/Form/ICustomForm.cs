using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ATRIEssentialsPluginMainProject.MCApi.Commands;

namespace ATRIEssentialsPluginMainProject.MCApi.Form
{
    internal interface ICustomForm
    {
        IntPtr CustomForm();
        void setTiTle(string text);
        void addLabel(string text);
        void addInput(string name, string text, string tip, string defaultvaule);
        void addSwitch(string name,string text,bool IsOpen);
        void addDropdown(string name,string text,params string?[] parmstr);
        void SendTo(IntPtr ptr, CallBack back);
    }
}
