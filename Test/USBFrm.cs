using LangYa.Net.Utils.Device;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test
{
    public partial class USBFrm : Form
    {
        public USBFrm()
        {
            InitializeComponent();
        }

        USBMonitor usbMonitor = new USBMonitor();
        protected override void WndProc(ref Message m)
        {
            usbMonitor.FillData(this, m, listBox);

            base.WndProc(ref m);
        }
    }
}
