using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace VisualRoundAbout
{
    public static class NativeCode
    {
        public static class User32
        {
            [DllImport("user32.dll")]
            public static extern IntPtr WindowFromPoint(Point pt);
            [DllImport("user32.dll")]
            public static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);
        }

        public static class Constants
        {
            public const int WM_KEYDOWN = 0x0100;
            public const int VK_F5 = 0x74;
            public const int VK_F7 = 0x76;
        }
    }
}
