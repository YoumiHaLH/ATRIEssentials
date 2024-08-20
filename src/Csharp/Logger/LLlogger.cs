using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATRIEssentialsPluginMainProject.Logger
{
#if LL
    internal class LLogger  : ILogger
      {

        [DllImport("ATRIEssentials.dll")]
        private extern static void info(byte[] bytes);
        [DllImport("ATRIEssentials.dll")]
        private extern static void error(byte[] bytes);
        [DllImport("ATRIEssentials.dll")]
        private extern static void warn(byte[] bytes);


        public void info_(byte[] message)
        {
            info(message);
        }

        public void warn_(byte[] message)
        {
            warn(message);
        }

        public void error_(byte[] message)
        {
           error(message);
        }

        public void fatal_(byte[] message)
        {
            throw new NotImplementedException();
        }
      }
#endif
}
