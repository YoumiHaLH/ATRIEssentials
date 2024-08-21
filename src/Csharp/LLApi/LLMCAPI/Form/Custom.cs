global using net.r_eg.Conari.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATRIEssentials;
using ATRIEssentialsPluginMainProject.Logger;
using ATRIEssentialsPluginMainProject.MCApi.Commands;
using ATRIEssentialsPluginMainProject.MCApi.Form.Custom;
using ATRIEssentialsPluginMainProject.MCApi.MCActor;

namespace ATRIEssentialsPluginMainProject.LLApi.LLMCAPI.Form
{
    internal class Custom : ICustomForm
    {
        [DllImport("ATRIEssentials.dll")]
        
        private extern static IntPtr CustomForms();

        [DllImport("ATRIEssentials.dll")]
        private extern static void SendTo_(IntPtr ptr,IntPtr ptr2, CallBack call);
      
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
            PluginMain.dll.setTitle(ptr,new NativeString<WCharPtr>(text));
        }

        public void addLabel(string text)
        {
            PluginMain.dll.addLabel(ptr,new NativeString<WCharPtr>(text));
        }

        public void addInput(string name, string text, string tip, string defaultvaule)
        {
            PluginMain.dll.addInput(ptr,new NativeString<WCharPtr>(name),new NativeString<WCharPtr>(text),new NativeString<WCharPtr>(tip),new NativeString<WCharPtr>(defaultvaule));
        }

        public void addSwitch(string name, string text, bool IsOpen)
        {
            PluginMain.dll.addSwitch(ptr, new NativeString<WCharPtr>(name), new NativeString<WCharPtr>(text), IsOpen);
        }

        public void addDropdown(string name, string text,string[] parmstr)
        {
            
            PluginMain.dll.addDropdown(ptr,new NativeString<WCharPtr>(name),new NativeString<WCharPtr>(text),new UnmanagedStringArray<WCharPtr>(parmstr),parmstr.Length);
            // addDropdown(ptr,name.GetBytes(),new NativeString<by>(),by.ToArray(),parmstr.Length);
        }
        private string UnicodeToUTF8(string strFrom)
        {
            byte[] bytes = Encoding.Default.GetBytes(strFrom);
            return Encoding.UTF8.GetString(bytes);
        }
        public void SendTo(IntPtr ptr,CallBack back)
        {
             SendTo_(this.ptr,ptr, back);
        }

    }
}
