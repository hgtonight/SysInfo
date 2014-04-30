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
    class PageFile
    {
        public String getPageFile()
        {
            try
            {
                String output = "";

                int size = 9999;
                int maxSize = 9999;

                ObjectQuery query = new ObjectQuery("select * from Win32_PageFileUsage");
                ManagementObjectSearcher searcher = new
                ManagementObjectSearcher(query);
                ManagementObjectCollection vals = searcher.Get();

                foreach (ManagementObject val in vals)
                {
                    size = System.Convert.ToInt32(val.GetPropertyValue("CurrentUsage"));
                    maxSize = System.Convert.ToInt32(val.GetPropertyValue("AllocatedBaseSize"));
                }

                output += "=================\r\n";
                output += "=== Page File ===\r\n";
                output += "=================\r\n\r\n";
                output += "  Current Size: " + size + " MB\r\n";
                output += "  Maximum Size: " + maxSize + " MB\r\n\r\n";

                main.addText("PageFile Completed Successfully");

                return output;
            }
            catch(Exception ex)
            {
                MessageBox.Show("A bad thing happened when attempting to get the Service List :( \n\n Error: \n" + ex);
                main.addText("PageFile Completed with Errors");
            }
            return "Error in Services Retrieval";
        }
    }
}
