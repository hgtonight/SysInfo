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
    class GFX
    {
        public String getGFXUnit()
        {
            try
            {
                String output = "";
                int debug = 0;

                String gfxSpeed = "9999";
                uint gfxMemory = 9999;
                String gfxName = "9999";

                ObjectQuery query = new ObjectQuery("select * from Win32_VideoController");
                ManagementObjectSearcher searcher = new
                ManagementObjectSearcher(query);
                ManagementObjectCollection vals = searcher.Get();

                foreach (ManagementObject val in vals)
                {
                    gfxSpeed = System.Convert.ToString(val.GetPropertyValue("Description"));
                    gfxMemory = System.Convert.ToUInt32(val.GetPropertyValue("AdapterRAM"));
                    gfxName = System.Convert.ToString(val.GetPropertyValue("Name"));

                    output += "--- GFX Unit ---\r\n";
                    output += "  Name: " + gfxName + "\r\n";
                    output += "  Memory: " + (gfxMemory / 1048576) + " MB\r\n\r\n";

                    debug++;
                }

                main.addText("GFX Completed Successfully");

                //output += "--- GFX Unit ---\r\n";
                //output += "  Name: " + gfxName + "\r\n";
                //output += "  Memory: " + (gfxMemory / 1048576) + " MB\r\n\r\n";

                return output;
            }
            catch(Exception ex)
            {
                MessageBox.Show("A bad thing happened when attempting to GFX Info:( \n\n Error: \n" + ex);
                main.addText("GFX Completed with Errors");
            }
            return "Error in GFX Retrevial";
        }
    }
}
