using System;

namespace Qni.Core
{
    public class QniCollectedException : Exception
    {
        public QniCollectedException() : base("program is collected")
        {
            
        }
    }
}