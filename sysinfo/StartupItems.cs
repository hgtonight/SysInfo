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
    class StartupItems
    {
        public String getStartupItems()
        {

            try
            {
                String output = "";

                ManagementClass mangnmt = new ManagementClass("Win32_StartupCommand");

                ManagementObjectCollection mcol = mangnmt.GetInstances();

                output += "=====================\r\n";
                output += "=== Startup Items ===\r\n";
                output += "=====================\r\n\r\n";

                foreach (ManagementObject strt in mcol)
                {
                    String name = strt["Name"].ToString();
                    String loc = strt["Location"].ToString();
                    String command = strt["Command"].ToString();

                    output += "Name: " + name + "\r\n";
                    output += "Location: " + loc + "\r\n";
                    output += "Command: " + command + "\r\n\r\n";

                    //output +="User: " + strt["User"].ToString());
                }

                main.addText("Startup Items Completed Successfully");

                return output;
            }
            catch(Exception ex)
            {
                MessageBox.Show("A bad thing happened when attempting to get the Startup Items :( \n\n Error: \n" + ex);
                main.addText("Startup Items Completed with Errors");
            }
            return "Error in Startup Item Retrieval";
        }
    }
}
