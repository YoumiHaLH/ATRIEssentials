global using System.Runtime.InteropServices;
namespace ATRIEssentials
{
    public static class PluginMain
    {
        [DllExport]
        
        public static void load()
        {
            Console.WriteLine("LoadSuccess");
        }
    }
}
