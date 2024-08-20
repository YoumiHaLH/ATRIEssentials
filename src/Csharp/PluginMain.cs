global using System.Runtime.InteropServices;
using System.Reflection;
using net.r_eg.Conari;
using ATRIEssentialsPluginMainProject;
using ATRIEssentialsPluginMainProject.Logger;
using Console = Colorful.Console;
using System.Drawing;
using Colorful;
using System.Globalization;
using System.Net.Http.Json;
using ATRIEssentialsPluginMainProject.i18n;
using ATRIEssentialsPluginMainProject.MCApi.Commands;
using ATRIEssentialsPluginMainProject.MCApi.Form;
using ATRIEssentialsPluginMainProject.Utils;
using Newtonsoft.Json;
using Path = System.Path;
using Config =  ATRIEssentialsPluginMainProject.Config.Config;
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
        public static Config? cfg { get; set; }
        public static int load(IntPtr arg, int argLength)
        {
            
            try
            {
                int consoleWidth = Console.WindowWidth;
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
                    Console.WriteLine(line.PadLeft(line.Length + padding)+"\0", Color.FromArgb(125, 184, 191));
                }
                LoadLibs();                                                                   
                i18n.InitI18n();
               cfg =  LoadConfig();
            }
            catch (Exception e)
            {
                logger.error(e);
            }                  
            return 0;                  
        }

        public static Config? LoadConfig()
        {
            logger.info(i18n.Get("atri.initconfig"));
#if DEBUG
            Config cfg_d = new();
            var serializeObject_d = JsonConvert.SerializeObject(cfg_d);
            File.Create(Path.config).Dispose();
            File.WriteAllText(Path.config, serializeObject_d);
            return cfg;
#endif
            if (!File.Exists(Path.config))
            {
                Config cfg = new();
                var serializeObject = JsonConvert.SerializeObject(cfg);
                File.Create(Path.config).Dispose();
                File.WriteAllText(Path.config,serializeObject);
                return cfg;
            }
            var readAllText = File.ReadAllText(Path.config);
            var deserialize = JsonConvert.DeserializeObject<Config>(readAllText);
            return deserialize;
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
        
        [DllExport]
        public static void enable()
        {
            CommandRegister.RegisterCommand("test","test",ICommands.CommandLevel.Any,((ref IntPtr a, ref IntPtr b) =>
            {
                var isPlayer = ATRIEssentialsPluginMainProject.LLApi.LLMCAPI.Command.Command.isPlayer(ref a);
                if (isPlayer)
                {
                    Custom ct = new Custom();
                    ct.setTiTle("1");
                    ct.addLabel("2");
                    ct.addDropdown("name", "原神", ["1"]);
                    ct.addSwitch("na", "test", true);
                    var player = ATRIEssentialsPluginMainProject.LLApi.LLMCAPI.Command.Command.GetPlayer(ref a);
                    ct.sendTo(player,(ref IntPtr a, ref IntPtr b) =>
                    {
                        Console.WriteLine("1");
                    });

                }
                Console.WriteLine(isPlayer);
            }));
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
