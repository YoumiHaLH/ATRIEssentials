using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATRIEssentialsPluginMainProject.MCApi.Form.Simple
{
    internal delegate void CallBack(ref IntPtr player);
    internal interface ISimpleForm
    {
        public enum ImgType
        {
            path = 0,
            url = 1

        }
        void setTitle(string str);
        void setContent(string str);
        void addButton(string str1, string str2,ImgType ty, CallBack ck);
        void addButton(string str1, CallBack ck);
        void SendTo(IntPtr player);
    }
}
