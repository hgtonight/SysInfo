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
    class RAM
    {
        public String getMemory()
        {
            try
            {
                String output = "";

                double capacity = 9999;
                int speed = 9999;

                output += "=====================\r\n";
                output += "=== Hardware List ===\r\n";
                output += "=====================\r\n\r\n";

                ObjectQuery query = new ObjectQuery("select * from Win32_PhysicalMemory");
                ManagementObjectSearcher searcher = new
                ManagementObjectSearcher(query);
                ManagementObjectCollection vals = searcher.Get();

                foreach (ManagementObject val in vals)
                {
                    capacity += System.Convert.ToDouble(val.GetPropertyValue("Capacity"));
                    speed = System.Convert.ToInt32(val.GetPropertyValue("Speed"));
                }

                output += "--- Memory ---\r\n";
                output += "  Capacity: " + (Math.Round((capacity / 1048576), 0)) + " MB \r\n";
                output += "  Speed: " + speed + " MHz\r\n\r\n";

                main.addText("RAM Completed Successfully");

                return output;
            }
            catch(Exception ex)
            {
                MessageBox.Show("A bad thing happened when attempting to get the RAM Info :( \n\n Error: \n" + ex);
                main.addText("RAM Completed with Errors");
            }
            return "Error in RAM Retrieval";
        }
    }
}
