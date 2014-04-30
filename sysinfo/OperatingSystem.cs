using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ServiceProcess;
using System.Management;
using System.Management.Instrumentation;
using System.Diagnostics;

namespace sysinfo
{
    class OperatingSystem
    {
        public String getOS()
        {
            try
            {
                String output = "";

                String osName = "9999";
                String architecture = "9999";
                long osFreeMemory = 9999;

                ObjectQuery query = new ObjectQuery("select * from Win32_OperatingSystem");
                ManagementObjectSearcher searcher = new
                ManagementObjectSearcher(query);
                ManagementObjectCollection vals = searcher.Get();

                foreach (ManagementObject val in vals)
                {
                    osName = System.Convert.ToString(val.GetPropertyValue("Name"));
                    architecture = System.Convert.ToString(val.GetPropertyValue("OSArchitecture"));
                    osFreeMemory = System.Convert.ToInt64(val.GetPropertyValue("FreePhysicalMemory"));
                }
                osFreeMemory = (osFreeMemory / 1024);

                output += "========================\r\n";
                output += "=== Operating System ===\r\n";
                output += "========================\r\n\r\n";
                output += "  Name: " + osName + "\r\n";
                output += "  Architecture: " + architecture + "\r\n";
                output += "  Reported Free Physical Memory: " + osFreeMemory + " MB\r\n\r\n";

                main.addText("OS Completed Successfully");

                return output;
            }
            catch (Exception ex)
            {
                MessageBox.Show("A bad thing happened when attempting to get the Operating System Info :( \n\n Error: \n" + ex);
                main.addText("OS Completed with Errors");
            }
            return "Error in OS Info Retrieval";
        }
    }
}
