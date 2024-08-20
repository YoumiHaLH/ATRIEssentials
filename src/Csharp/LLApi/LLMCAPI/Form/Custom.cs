global using net.r_eg.Conari.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATRIEssentials;
using ATRIEssentialsPluginMainProject.Logger;
using ATRIEssentialsPluginMainProject.MCApi.Commands;
using ATRIEssentialsPluginMainProject.MCApi.Form;
using ATRIEssentialsPluginMainProject.Utils;

namespace ATRIEssentialsPluginMainProject.LLApi.LLMCAPI.Form
{
    internal class Custom : ICustomForm
    {
        [DllImport("ATRIEssentials.dll")]
        
        private extern static IntPtr CustomForms();

        [DllImport("ATRIEssentials.dll")]
        private extern static void SendTo_(IntPtr ptr,IntPtr ptr2, CallBack call);
        [DllImport("ATRIEssentials.dll")]
        private extern static void addDropdown(IntPtr ptr, byte[] name, byte[] text, byte[][] bytes,int len);

        private IntPtr ptr;
        public Custom()
        {
            ptr = CustomForms();
        }
        public IntPtr CustomForm()
        {
            return CustomForms();
        }

        public void setTiTle(string text)
        {
            PluginMain.dll.setTitle(ptr,text);
        }

        public void addLabel(string text)
        {
            PluginMain.dll.addLabel(ptr,text);
        }

        public void addInput(string name, string text, string tip, string defaultvaule)
        {
            PluginMain.dll.addInput(ptr,name,text,tip,defaultvaule);
        }

        public void addSwitch(string name, string text, bool IsOpen)
        {
            PluginMain.dll.addSwitch(ptr, name, text, IsOpen);
        }

        public void addDropdown(string name, string text,string[] parmstr)
        {
            List<byte[]> by = new List<byte[]>();
            foreach (var s in parmstr)
            {
                by.Add(s.GetBytes());
            }
           addDropdown(ptr,name.GetBytes(),text.GetBytes(),by.ToArray(),parmstr.Length);
        }

        public void SendTo(IntPtr ptr,CallBack back)
        {
             SendTo_(this.ptr,ptr, back);
        }

    }
}
