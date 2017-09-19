using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;

namespace LangYa.Net.Utils.Device
{
    /// <summary>
    /// USB插拔监控类
    /// </summary>
    public class USBMonitor
    {
        private delegate void SetTextCallback(string s);
        private IList<string> _usbdiskList = new List<string>();
        private ListBox _listbox = null;
        private Form _form = null;

        public USBMonitor()
        {
            System.Timers.Timer timer = new System.Timers.Timer(1000);
            timer.Enabled = true;

            // 达到间隔时发生
            timer.Elapsed += new System.Timers.ElapsedEventHandler(TimerList);
            timer.AutoReset = false; // 仅在间隔第一次结束后引发一次          
        }

        public void FillData(Form form, Message m, ListBox listbox)
        {
            _listbox = listbox;
            _form = form;

            try
            {
                if (m.Msg == (int)HWndProMsgType.WM_DEVICECHANGE) // 系统硬件改变发出的系统消息
                {
                    switch (m.WParam.ToInt32())
                    {
                        case (int)HWndProMsgType.WM_DEVICECHANGE:
                            break;
                        //设备检测结束，并且可以使用
                        case (int)HWndProMsgType.DBT_DEVICEARRIVAL:
                            {
                                ScanUSBDisk();
                                _listbox.Items.Clear();
                                foreach (string str in _usbdiskList)
                                {
                                    _listbox.Items.Add(str);
                                }
                            }
                            break;
                        // 设备卸载或者拔出
                        case (int)HWndProMsgType.DBT_DEVICEREMOVECOMPLETE:
                            {
                                ScanUSBDisk();
                                _listbox.Items.Clear();
                                foreach (string str in _usbdiskList)
                                {
                                    _listbox.Items.Add(str);
                                }
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("当前盘不能正确识别，请重新尝试！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// 设置USB列表
        /// </summary>
        void TimerList(object sender, System.Timers.ElapsedEventArgs e)
        {
            ScanUSBDisk();
            foreach (string str in _usbdiskList)
            {
                SetText(str);
            }
        }

        /// <summary>
        /// 扫描U口设备
        /// </summary>
        private void ScanUSBDisk()
        {
            _usbdiskList.Clear();
            DriveInfo[] drives = DriveInfo.GetDrives();

            foreach (DriveInfo drive in drives)
            {
                if ((drive.DriveType == DriveType.Removable) && !drive.Name.Substring(0, 1).Equals("A"))
                {
                    try
                    {
                        _usbdiskList.Add(drive.Name);
                    }
                    catch
                    {
                        MessageBox.Show("当前盘不能正确识别，请重新尝试！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        /// <summary>
        /// 设置List列表
        /// </summary>
        /// <param name="text">名称</param>
        public void SetText(string text)
        {
            if (_listbox == null)
                return;

            if (this._listbox.InvokeRequired) // 调用方位于创建控件所在的线程以外的线程中
            {
                if (_listbox.Items.Contains(text))
                    return;

                SetTextCallback d = new SetTextCallback(SetText);
                _form.Invoke(d, new object[] { text });
            }
            else
            {
                if (_listbox.Items.Contains(text))
                    return;

                this._listbox.Items.Add(text);
            }
        }
    }
}
