using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ServiceProcess;
using System.Management;
using System.Management.Instrumentation;
using System.Diagnostics;

namespace sysinfo
{
    public partial class main : Form
    {
        Reporting reporting = new Reporting();

        public main()
        {
            InitializeComponent();
        }

        private void buttonUpload_Click(object sender, EventArgs e)
        {
            reporting.run();
        }

        public static void addText(String text)
        {
            outputStatus.Text += "\r\n" + text;
        }
    }
}
