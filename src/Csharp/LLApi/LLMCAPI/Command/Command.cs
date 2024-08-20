using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATRIEssentialsPluginMainProject.Logger;
using ATRIEssentialsPluginMainProject.MCApi.Commands;

namespace ATRIEssentialsPluginMainProject.LLApi.LLMCAPI.Command
{
    internal class Command : ICommands
    {
        [DllImport("ATRIEssentials.dll")]
        public static extern void RegisterCommand(byte[] name, byte[] decribe,int level,CallBack callBack);

        [DllImport("ATRIEssentials.dll")]
        public static extern bool isPlayer(ref IntPtr ptr);
        [DllImport("ATRIEssentials.dll")]
        public static extern IntPtr GetPlayer(ref IntPtr ptr);
        public void RegisterCommand(string text, string describes, CallBack back,ICommands.CommandLevel level)
        {
            RegisterCommand(text.GetBytes(),describes.GetBytes(),(int)level,back);
        }
        
        public void addOverLoad<T>(T struct_)
        {
            throw new NotImplementedException();
        }
        
    }
}
