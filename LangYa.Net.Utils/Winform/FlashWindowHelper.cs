using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace LangYa.Net.Utils.Winform
{
    /// <summary>
    /// 窗口闪动的辅助类
    /// </summary>
    public class FlashWindowHelper
    {
        Timer   _timer;
        int     _count      = 0;
        int     _maxTimes   = 0;
        IntPtr  _window;

        public void Flash(int times, double millliseconds, IntPtr window)
        {
            _maxTimes   = times;
            _window     = window;

            _timer = new Timer();
            _timer.Interval = millliseconds;
            _timer.Elapsed += _timer_Elapsed;
            _timer.Start();
        }

        void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (++_count < _maxTimes)
            {
                Win32.FlashWindow(_window, (_count % 2) == 0);
            }
            else
            {
                _timer.Stop();
            }
        }
    }
}
