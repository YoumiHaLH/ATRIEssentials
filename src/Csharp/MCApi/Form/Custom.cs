using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ATRIEssentialsPluginMainProject.MCApi.Commands;

namespace ATRIEssentialsPluginMainProject.MCApi.Form
{
    internal class Custom
    {
        private LLApi.LLMCAPI.Form.Custom custom;
        public Custom()
        {
            custom = new LLApi.LLMCAPI.Form.Custom();
        }
        public IntPtr CustomForm()
        {
            throw new NotImplementedException();
        }

        public Custom setTiTle(string text)
        {
            custom.setTiTle(text);
            return this;
        }

        public Custom addLabel(string text)
        {
            custom.addLabel(text);
            return this;
        }

        public Custom addInput(string name, string text, string tip, string defaultvaule)
        {
            custom.addInput(name, text, tip, defaultvaule);
            return this;
        }

        public Custom addSwitch(string name, string text, bool IsOpen)
        {
            custom.addSwitch(name, text, IsOpen);
            return this;
        }

        public Custom addDropdown(string name, string text, params string?[] parmstr)
        {
            custom.addDropdown(name,text,parmstr);
            return this;

        }

        public void sendTo(IntPtr ptr,CallBack back)
        {
            custom.SendTo(ptr,back);
        }
    }
}
