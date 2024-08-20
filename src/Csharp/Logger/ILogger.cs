using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATRIEssentialsPluginMainProject.Logger
{
    internal interface ILogger
    {
        void info_(byte[] message);
        void warn_(byte[] message);
        void error_(byte[] message);
        void fatal_(byte[] message);
    }
}
