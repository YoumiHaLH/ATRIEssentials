using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATRIEssentials;
using ATRIEssentialsPluginMainProject.MCApi.Form.Simple;

namespace ATRIEssentialsPluginMainProject.LLApi.LLMCAPI.Form
{
    internal class SimpleForm : ISimpleForm
    {
        [DllImport("ATRIEssentials.dll")]
        private static extern IntPtr SimpleForm_();

        [DllImport("ATRIEssentials.dll")]
        private static extern IntPtr addButton_img_S( IntPtr a,NativeString<WCharPtr> b,NativeString<WCharPtr> c,CallBack ck,int d);

        [DllImport("ATRIEssentials.dll")]
        private static extern IntPtr addButton_S(IntPtr a,IntPtr b,CallBack ck);

        [DllImport("ATRIEssentials.dll")]
        private static extern IntPtr SendTo_S( IntPtr a,IntPtr b);
        private IntPtr ptr;
        public SimpleForm()
        {
            ptr = SimpleForm_();
        }
        public void setTitle(string str)
        {
            PluginMain.dll.setTitle_S(ptr,new NativeString<WCharPtr>(str));
        }

        public void setContent(string str)
        {
            PluginMain.dll.setContent_S(ptr,new NativeString<WCharPtr>(str));
        }

        public void addButton(string str1, string str2, ISimpleForm.ImgType ty,CallBack ck)
        {
            addButton_img_S(ptr, new NativeString<WCharPtr>(str1), new NativeString<WCharPtr>(str2), ck, (int)ty);
        }

        public void addButton(string str1, CallBack ck)
        {
            addButton_S(ptr, new NativeString<WCharPtr>(str1).AddressPtr, ck);
        }

        public void SendTo(IntPtr player)
        {
            SendTo_S(ptr, player);
        }
    }
}
