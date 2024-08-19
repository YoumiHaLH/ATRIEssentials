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
        [DllImport("ATRIEssentials.dll")]
        private extern static void info(byte[] bytes);
        [DllImport("ATRIEssentials.dll")]
        private extern static void error(byte[] bytes);
        [DllImport("ATRIEssentials.dll")]
        private extern static void warn(byte[] bytes);

        /// <summary>
        /// INFO
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="text"></param>
        public static void info<T>(T text)
        {
            info(text.ToString().GetBytes());
        }

        public static void error<T>(T text)
        {
            error(text.ToString().GetBytes());
        }

        public static void warn<T>(T text)
        {
            warn(text.ToString().GetBytes());
        }
        public static byte[] GetBytes(this string in_)
        {
            return Encoding.UTF8.GetBytes(in_);
        }
    }
}