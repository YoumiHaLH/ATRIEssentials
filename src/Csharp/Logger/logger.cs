global using net.r_eg.Conari.Native;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ATRIEssentials;

using net.r_eg.Conari.Types;

namespace ATRIEssentialsPluginMainProject.Logger
{
    internal static class logger
    {
#if LL
        private static ILogger logger_ = new LLogger();
#elif END
        private static ILogger logger_ = new ENDLogger();
#elif BDSX
        private static ILogger logger_ = new BDSXLogger();
#endif

        public static void info<T>(T text)
        {
            logger_.info_(text.ToString().GetBytes());
        }

        public static void error<T>(T text)
        {
            logger_.error_(text.ToString().GetBytes());
        }

        public static void warn<T>(T text)
        {
            logger_.error_(text.ToString().GetBytes());
        }
        public static byte[] GetBytes(this string in_)
        {
            return Encoding.UTF8.GetBytes(in_);
        }
       
    }
}