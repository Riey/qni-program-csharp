using System;
using Qni.Core.Native;

namespace Qni.Core
{
    public class QniHub : IDisposable
    {
        public IntPtr Handle { get; }

        public QniHub(QniProgramEntryCallback entry)
        {
            Handle = QniCoreLib.qni_hub_new(entry);

            if (Handle == IntPtr.Zero)
            {
                throw new Exception("create hub failed");
            }
        }

        private void ReleaseUnmanagedResources()
        {
            QniCoreLib.qni_hub_delete(Handle);
        }

        public void Dispose()
        {
            ReleaseUnmanagedResources();
            GC.SuppressFinalize(this);
        }

        ~QniHub()
        {
            ReleaseUnmanagedResources();
        }

        public void Exit()
        {
            QniCoreLib.qni_hub_exit(Handle);
        }
    }
}