global using System.Runtime.InteropServices;
using System.Reflection;
using net.r_eg.Conari;
using ATRIEssentialsPluginMainProject;
using ATRIEssentialsPluginMainProject.Logger;
using Console = Colorful.Console;
using System.Drawing;
using Colorful;
using System.Globalization;
using ATRIEssentialsPluginMainProject.i18n;

namespace ATRIEssentials
{
    public static class PluginMain
    {
        public static string dll_path = "./plugins/ATRIEssentials";
        public static ConariL Conari = new ConariL("ATRIEssentials.dll");
        public static dynamic dll = Conari.DLR;
        public static ulong Version = 589;
        public static string GameVersion = "1.21.2";
        public static string auother = "YoumiHa";
        public static int load(IntPtr arg, int argLength)
        {
            
            try
            {
                int consoleWidth = Console.WindowWidth;
                
                // 打印图案
                string[] lines = {
                    "             _______   _____    _____ ",
                    "     /\\     |__   __| |  __ \\  |_   _|",
                    "    /  \\       | |    | |__) |   | |  ",
                    "   / /\\ \\      | |    |  _  /    | |  ",
                    "  / ____ \\     | |    | | \\ \\   _| |_ ",
                    " /_/    \\_\\    |_|    |_|  \\_\\ |_____|",
                    "                                      ",
                    "                                      ",
                    "----------------------------------------------------",
                    "                                                    ",
                    $"     适配版本:   {GameVersion}                                 ",
                    $"     适配协议:   {Version}                                    "    ,
                    $"     构建日期:   {GetBuildTime(Assembly.GetExecutingAssembly())}                     ",
                    $"     作者:     {auother}                                ",
                    "                                                    ",
                    "----------------------------------------------------"
                };

                foreach (string line in lines)
                {
                    int padding = (consoleWidth - line.Length) / 2;
                    Console.WriteLine(line.PadLeft(line.Length + padding), Color.FromArgb(140, 196, 200));
                }
                LoadLibs();
                i18n.InitI18n();
            }
            catch (Exception e)
            {
                logger.error(e);
            }
            Console.WriteLine(i18n.Get("atri.initconfig","zh_CN"));
            return 0;
        }
        public static DateTime GetBuildTime(Assembly assembly)
        {
            const string buildVersionMetadataPrefix = "+build";

            var attribute = assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>();
            if (attribute?.InformationalVersion != null)
            {
                var value = attribute.InformationalVersion;
                var index = value.IndexOf(buildVersionMetadataPrefix, StringComparison.Ordinal);
                if (index > 0)
                {
                    value = value[(index + buildVersionMetadataPrefix.Length)..];
                    if (DateTime.TryParseExact(value, "yyyyMMddHHmmssZ", CultureInfo.InvariantCulture, DateTimeStyles.None, out var result))
                        return result;
                }
            }
            return default;
        }
        private static void Print(string text)
        {
            int windowWidth = Console.WindowWidth;
            int textLength = text.Length;
            int spaces = (windowWidth - textLength) / 2;

            Console.WriteLine(new string(' ', spaces) + text, Color.FromArgb(140, 196, 200));
        }
        [DllExport]
        public static void enable()
        {
            Console.WriteLine("1");
        }

        [DllExport]
        public static void disable()
        {
            Console.WriteLine("LoadSuccess");
        }

        public static void LoadLibs()
        {
            var strings = Directory.GetFiles(dll_path + "/.lib/", "*.dll");
            foreach (var s in strings)
            {
                if (s.LastIndexOf("ATRIEssentialsPluginMainProject.dll") != -1 || s.LastIndexOf("nethost.dll") != -1)
                {
                    continue;
                }

                try
                {
                    Assembly.LoadFrom(s);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }
    }
}
