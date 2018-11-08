using System;
using System.Text;
using Qni.Program.Simple.Native;

namespace Qni.Program.Simple
{
    public static class QniProgramSimple
    {
        public static void Init()
        {
            QniProgramSimpleLib.qni_init_program();
        }

        public static void StartNewProgram(IntPtr hubHandle, string host)
        {
            var bytes = Encoding.UTF8.GetBytes(host);

            unsafe
            {
                fixed (byte* ptr = &bytes[0])
                {
                    QniProgramSimpleLib.qni_start_program(hubHandle, ptr, (UIntPtr) bytes.Length);
                }
            }
        }
    }
}