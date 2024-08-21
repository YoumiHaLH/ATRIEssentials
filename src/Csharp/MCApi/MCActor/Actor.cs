using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATRIEssentialsPluginMainProject.MCApi.MCActor
{
    internal class Actor
    {
        public IntPtr ptr;

        public unsafe Actor(IntPtr ptr)
        {
            this.ptr = ptr;
        } 
    }
}
