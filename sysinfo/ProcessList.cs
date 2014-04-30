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
    class ProcessList
    {
        public String getProcessList()
        {
            try
            {
                String output = "";

                double memory;
                Process[] processlist = Process.GetProcesses();

                output += "====================\r\n";
                output += "=== Process List ===\r\n";
                output += "====================\r\n\r\n";

                output += "Process Name -- Memory Usage\r\n\r\n";

                foreach (Process theprocess in processlist)
                {
                    memory = Math.Round((theprocess.PrivateMemorySize64 / 1048576.0), 2);
                    output += theprocess.ProcessName + " " + memory + " MB\r\n";
                }

                output += "\r\n";

                main.addText("Process List Completed Successfully");

                return output;
            }
            catch(Exception ex)
            {
                MessageBox.Show("A bad thing happened when attempting to get the Process List :( \n\n Error: \n" + ex);
                main.addText("Process List Completed with Errors");
            }
            return "Error in Process List Retrieval";
        }
    }
}
