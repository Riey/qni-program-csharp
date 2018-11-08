using System;
using System.Text;
using Qni.Core.Native;

namespace Qni.Core
{
    public class QniContext
    {
        private readonly IntPtr _handle;
        
        public QniContext(IntPtr handle)
        {
            _handle = handle;
        }

        private static void CheckReturnCode(int code)
        {
            if (code != 0)
            {
                throw new QniCollectedException();
            }
        }

        public void Print(string text)
        {
            var bytes = Encoding.UTF8.GetBytes(text);

            unsafe
            {    
                fixed(byte* ptr = &bytes[0])
                {
                    CheckReturnCode(QniCoreLib.qni_print(_handle, ptr, (UIntPtr) bytes.Length));
                }
            }
        }

        public void PrintLine(string text)
        {
            var bytes = Encoding.UTF8.GetBytes(text);

            unsafe
            {    
                fixed(byte* ptr = &bytes[0])
                {
                    CheckReturnCode(QniCoreLib.qni_print_line(_handle, ptr, (UIntPtr) bytes.Length));
                }
            }
        }

        public void NewLine()
        {
            CheckReturnCode(QniCoreLib.qni_new_line(_handle));
        }

        public void DeleteLine(uint count)
        {
            CheckReturnCode(QniCoreLib.qni_delete_line(_handle, count));
        }

        public void SetFont(string fontFamily, float fontSize, FontStyle fontStyle)
        {
            var bytes = Encoding.UTF8.GetBytes(fontFamily);

            unsafe
            {    
                fixed(byte* ptr = &bytes[0])
                {
                    CheckReturnCode(QniCoreLib.qni_set_font(_handle, ptr, (UIntPtr) bytes.Length, fontSize, fontStyle));
                }
            }
        }

        public void SetTextColor(uint color)
        {
            CheckReturnCode(QniCoreLib.qni_set_text_color(_handle, color));
        }

        public void SetBackColor(uint color)
        {
            CheckReturnCode(QniCoreLib.qni_set_back_color(_handle, color));
        }

        public void SetHighlightColor(uint color)
        {
            CheckReturnCode(QniCoreLib.qni_set_highlight_color(_handle, color));
        }

        public int WaitInt()
        {
            unsafe
            {
                int ret;

                CheckReturnCode(QniCoreLib.qni_wait_int(_handle, &ret));

                return ret;
            }
        }
    }
}