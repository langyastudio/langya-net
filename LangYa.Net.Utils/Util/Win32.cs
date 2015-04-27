using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace LangYa.Net.Utils.Util
{
    /// <summary>
    /// Win32 API
    /// </summary>
    internal static class Win32
    {
        /// <summary>
        /// 窗口闪动
        /// </summary>
        /// <param name="hwnd">窗口句柄</param>
        /// <param name="bInvert">是否为闪</param>
        /// <returns>成功返回0</returns>
        [DllImport("user32.dll")]
        public static extern bool FlashWindow(IntPtr hwnd, bool bInvert);
    }
}
