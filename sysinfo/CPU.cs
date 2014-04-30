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
    class CPU
    {
        public String getCPU()
        {
            try
            {
                String output = "";

                int cpuSpeed = 9999;
                int cpuDataWidth = 9999;
                String cpuName = "9999";

                ObjectQuery query = new ObjectQuery("select * from Win32_Processor");
                ManagementObjectSearcher searcher = new
                ManagementObjectSearcher(query);
                ManagementObjectCollection vals = searcher.Get();

                foreach (ManagementObject val in vals)
                {
                    cpuSpeed = System.Convert.ToInt32(val.GetPropertyValue("MaxClockSpeed"));
                    cpuDataWidth = System.Convert.ToInt32(val.GetPropertyValue("DataWidth"));
                    cpuName = System.Convert.ToString(val.GetPropertyValue("name"));

                    output += "--- CPU ---\r\n";
                    output += "  Name: " + cpuName + "\r\n";
                    output += "  Speed: " + cpuSpeed + "MHz\r\n";
                    output += "  Width: " + cpuDataWidth + "-bit\r\n\r\n";
                }

                main.addText("CPU Completed Successfully");

                return output;
            }
            catch(Exception ex)
            {
                MessageBox.Show("A bad thing happened when attempting to get the CPU Info :( \n\n Error: \n" + ex);
                main.addText("CPU Completed with Errors");
            }
            return "Error in CPU Retrieval";
        }
    }
}
