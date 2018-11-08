using System;
using System.Runtime.InteropServices;

namespace Qni.Core.Native
{
    public delegate void QniProgramEntryCallback(IntPtr ctx);

    public enum FontStyle : uint
    {
        Regular = 0,
        Italic = 1,
        Bold = 2,
    }
    
    public static class QniCoreLib
    {
        private const string QniCoreLibName = "qni";

        [DllImport(QniCoreLibName)]
        public static extern IntPtr qni_hub_new(QniProgramEntryCallback entry);

        [DllImport(QniCoreLibName)]
        public static extern void qni_hub_delete(IntPtr hub);

        [DllImport(QniCoreLibName)]
        public static extern void qni_hub_exit(IntPtr hub);

        [DllImport(QniCoreLibName)]
        public static extern unsafe int qni_print(IntPtr ctx, byte* text, UIntPtr len);

        [DllImport(QniCoreLibName)]
        public static extern unsafe int qni_print_line(IntPtr ctx, byte* text, UIntPtr len);
       
        [DllImport(QniCoreLibName)]
        public static extern int qni_new_line(IntPtr ctx);
        
        [DllImport(QniCoreLibName)]
        public static extern int qni_delete_line(IntPtr ctx, uint count);

        [DllImport(QniCoreLibName)]
        public static extern unsafe int qni_set_font(IntPtr ctx, byte* fontFamily, UIntPtr fontFamilyLen, float fontSize, FontStyle fontStyle);

        [DllImport(QniCoreLibName)]
        public static extern int qni_set_text_color(IntPtr ctx, uint color);
        
        [DllImport(QniCoreLibName)]
        public static extern int qni_set_back_color(IntPtr ctx, uint color);
        
        [DllImport(QniCoreLibName)]
        public static extern int qni_set_highlight_color(IntPtr ctx, uint color);
        
        [DllImport(QniCoreLibName)]
        public static extern unsafe int qni_wait_int(IntPtr ctx, int* ret);
    }
}