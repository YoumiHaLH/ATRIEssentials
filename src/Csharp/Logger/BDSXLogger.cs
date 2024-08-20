using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATRIEssentialsPluginMainProject.Logger
{
#if BDSX
    internal class BDSXLogger : ILogger
    {
        public void info_(byte[] message)
        {
            throw new NotImplementedException();
        }

        public void warn_(byte[] message)
        {
            throw new NotImplementedException();
        }

        public void error_(byte[] message)
        {
            throw new NotImplementedException();
        }

        public void fatal_(byte[] message)
        {
            throw new NotImplementedException();
        }
    }
#endif

}
