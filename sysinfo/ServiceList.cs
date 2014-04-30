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
    class ServiceList
    {
        public String getServiceList()
        {
            try
            {
                String output = "";

                ServiceController[] scServices;
                scServices = ServiceController.GetServices();

                output += "====================\r\n";
                output += "=== Service List ===\r\n";
                output += "====================\r\n\r\n";

                foreach (ServiceController scTemp in scServices)
                {
                    if (scTemp.Status == ServiceControllerStatus.Running)
                    {
                        output += "Service: " + scTemp.ServiceName + "\r\n";
                        output += "  Display name: " + scTemp.DisplayName + "\r\n\r\n";
                    }
                }

                main.addText("Services Completed Successfully");

                return output;
            }
            catch(Exception ex)
            {
                MessageBox.Show("A bad thing happened when attempting to get the Service List :( \n\n Error: \n" + ex);
                main.addText("Services Completed with Errors");
            }
            return "Error in Services Retrieval";
        }
    }
}
