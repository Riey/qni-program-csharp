using System;
using System.Threading.Tasks;
using Qni.Core;
using Qni.Program.Simple;

namespace Qni.Sample.Sum.NetCore
{
    public static class Program
    {
        private static void QniEntry(IntPtr handle)
        {
            var ctx = new QniContext(handle);
            
            ctx.SetTextColor(0xFF_FFFFFF);
            ctx.SetBackColor(0xFF_000000);
            ctx.SetHighlightColor(0xFF_FFFF00);

            var sum = 0;
            
            ctx.PrintLine("-1을 입력하면 종료합니다");

            while (true)
            {
                ctx.PrintLine($"합계: {sum}");
                var ret = ctx.WaitInt();

                if (ret == -1)
                {
                    break;
                }

                sum += ret;
                ctx.DeleteLine(1);
            }
        }

        private static void StartProgram(IntPtr hubHandle)
        {
            QniProgramSimple.StartNewProgram(hubHandle, "127.0.0.1:4434");
        }
      
        public static void Main(string[] args)
        {
            QniProgramSimple.Init();
            var hub = new QniHub(QniEntry);
            var hubHandle = hub.Handle;

            var programTask = Task.Run(() => { StartProgram(hubHandle); });
            Console.WriteLine("Input Q to exit...");
            
            while (true)
            {
                if (Console.ReadLine() == "Q")
                {
                    break;
                }
            }
            
            hub.Exit();
            Console.WriteLine("Wait program exit...");
            programTask.Wait();
            hub.Dispose();
        }
    }
}