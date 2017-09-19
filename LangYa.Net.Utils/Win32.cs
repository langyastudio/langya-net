using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace LangYa.Net.Utils
{
    #region HChangeNotifyFlags
    [Flags]
    public enum HChangeNotifyFlags
    {
        SHCNF_DWORD = 0x0003,
        SHCNF_IDLIST = 0x0000,
        SHCNF_PATHA = 0x0001,
        SHCNF_PATHW = 0x0005,
        SHCNF_PRINTERA = 0x0002,
        SHCNF_PRINTERW = 0x0006,
        SHCNF_FLUSH = 0x1000,
        SHCNF_FLUSHNOWAIT = 0x2000
    }
    #endregion//enum HChangeNotifyFlags
    #region HChangeNotifyEventID
    [Flags]
    public enum HChangeNotifyEventID
    {
        SHCNE_ALLEVENTS = 0x7FFFFFFF,
        SHCNE_ASSOCCHANGED = 0x08000000,
        SHCNE_ATTRIBUTES = 0x00000800,
        SHCNE_CREATE = 0x00000002,
        SHCNE_DELETE = 0x00000004,
        SHCNE_DRIVEADD = 0x00000100,
        SHCNE_DRIVEADDGUI = 0x00010000,
        SHCNE_DRIVEREMOVED = 0x00000080,
        SHCNE_EXTENDED_EVENT = 0x04000000,
        SHCNE_FREESPACE = 0x00040000,
        SHCNE_MEDIAINSERTED = 0x00000020,
        SHCNE_MEDIAREMOVED = 0x00000040,
        SHCNE_MKDIR = 0x00000008,
        SHCNE_NETSHARE = 0x00000200,
        SHCNE_NETUNSHARE = 0x00000400,
        SHCNE_RENAMEFOLDER = 0x00020000,
        SHCNE_RENAMEITEM = 0x00000001,
        SHCNE_RMDIR = 0x00000010,
        SHCNE_SERVERDISCONNECT = 0x00004000,
        SHCNE_UPDATEDIR = 0x00001000,
        SHCNE_UPDATEIMAGE = 0x00008000,
    }
    #endregion

    /// <summary>  
    /// windows消息常量  
    /// </summary>  
    [Flags]
    public enum HWndProMsgType
    {
        WM_DEVICECHANGE = 0x219, // 系统硬件改变发出的系统消息  
        DBT_DEVICEARRIVAL = 0x8000,// 设备检测结束，并且可以使用  
        DBT_CONFIGCHANGECANCELED = 0x0019,
        DBT_CONFIGCHANGED = 0x0018,
        DBT_CUSTOMEVENT = 0x8006,
        DBT_DEVICEQUERYREMOVE = 0x8001,
        DBT_DEVICEQUERYREMOVEFAILED = 0x8002,
        DBT_DEVICEREMOVECOMPLETE = 0x8004,// 设备卸载或者拔出  
        DBT_DEVICEREMOVEPENDING = 0x8003,
        DBT_DEVICETYPEHANGED = 0x0007,
        DBT_QUERYCHANGSPECIFIC = 0x8005,
        DBT_DEVNODES_CECONFIG = 0x0017,
        DBT_USERDEFINED = 0xFFFF,
    }

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
        /// <summary>
        /// 桌面刷新 
        ///  SHChangeNotify(HChangeNotifyEventID.SHCNE_ASSOCCHANGED, HChangeNotifyFlags.SHCNF_IDLIST, IntPtr.Zero, IntPtr.Zero);
        /// </summary>
        [DllImport("shell32.dll")]
        public static extern void SHChangeNotify(HChangeNotifyEventID wEventId, HChangeNotifyFlags uFlags, IntPtr dwItem1, IntPtr dwItem2);
    }
}
