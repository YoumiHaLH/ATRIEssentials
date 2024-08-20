using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATRIEssentialsPluginMainProject.Utils
{
    internal class UnmanagedStringArray : NativeArray<nint>
    {
        private IntPtr[] ptrArray;
        public UnmanagedStringArray(string[] strArray)
        {
            if (strArray.Length == 0)
            {
                throw new Exception("String Array Can't have 0 members");
            }
            ptrArray = new IntPtr[strArray.Length];

            for (int i = 0; i < strArray.Length; i++)
            {
                ptrArray[i] = Marshal.StringToHGlobalAnsi(strArray[i]);
            }
            WriteLength(ptrArray.Length);
            memory.write(ptrArray);
        }

        private void WriteLength(int length)
        {
            if (length < 0) throw new ArgumentOutOfRangeException(nameof(length));

            Length = length;
            Size = net.r_eg.Conari.Static.Members.SizeOf<nint>(length);
            memory = Marshal.AllocHGlobal(Size);
            Owner = true;
        }
        ~UnmanagedStringArray(){
            this.release(false);
            foreach (var ptr in ptrArray)
            {
                Marshal.FreeHGlobal(ptr);
            }
        }
    }
}
