using System;
using System.Runtime.InteropServices;

namespace Qni.Program.Simple.Native
{
    public static class QniProgramSimpleLib
    {
        private const string QniProgramSimpleLibName = "qni";
        
        [DllImport(QniProgramSimpleLibName)]
        public static extern void qni_init_program();
        
        [DllImport(QniProgramSimpleLibName)]
        public static extern unsafe void qni_start_program(IntPtr hub, byte* host, UIntPtr hostLen);
    }
}
