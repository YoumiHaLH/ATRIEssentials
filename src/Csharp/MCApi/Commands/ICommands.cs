using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATRIEssentialsPluginMainProject.MCApi.Commands
{
    internal delegate void CallBack(ref IntPtr orgin, ref IntPtr output);
    internal interface ICommands
    {
        enum CommandLevel
        {
            Admin,
            Any,
            GameDirectors,
            Host,
            Internal
        }
        void RegisterCommand(string text,string describes,CallBack back,CommandLevel level);
        void addOverLoad<T>(T struct_);
    }
}
