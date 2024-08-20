using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATRIEssentialsPluginMainProject.LLApi.LLMCAPI.Command;

namespace ATRIEssentialsPluginMainProject.MCApi.Commands
{
    internal static class CommandRegister
    {
        private static ICommands commands = new Command();
        public static void RegisterCommand(string text,string describes,ICommands.CommandLevel level,CallBack back)
        {
            commands.RegisterCommand(text,describes,back,level);
        }
    }
}
