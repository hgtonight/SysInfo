using System;
using System.IO;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace sysinfo
{
    class Reporting
    {
        OperatingSystem os = new OperatingSystem();
        CPU cpu = new CPU();
        GFX gfx = new GFX();
        HardDrive hardDrive = new HardDrive();
        InstalledPrograms programs = new InstalledPrograms();
        Motherboard mb = new Motherboard();
        PageFile pageFile = new PageFile();
        ProcessList processes = new ProcessList();
        RAM memory = new RAM();
        ServiceList services = new ServiceList();
        StartupItems startupItems = new StartupItems();
        HardDrive hd = new HardDrive();

        String report = "";

        private String GenerateReport()
        {
            report += createHeader();
            report += os.getOS();
            report += memory.getMemory();
            report += cpu.getCPU();
            report += gfx.getGFXUnit();
            report += hd.buildData();
            report += pageFile.getPageFile();
            report += processes.getProcessList();
            report += services.getServiceList();
            report += startupItems.getStartupItems();

            return report;
        }
        private String createHeader()
        {
            String headerText = "";

            headerText += "=== SysInfo - Version 0.1.1a - 4/20/2014 === \r\n";
            headerText += "=== Report Generated On: " + DateTime.Now + " Local Time === \t\n";
            headerText += "=== Begin Report ===\r\n\r\n";

            return headerText;
        }
        private void writeReport(String text)
        {
            SaveFileDialog savefile = new SaveFileDialog();
            savefile.InitialDirectory = Convert.ToString(Environment.SpecialFolder.MyDocuments);
            savefile.Filter = "Text Document (*.txt)|*.txt";
            String path = "C:\\sysinfodump.txt";

            if (savefile.ShowDialog() == DialogResult.OK)
            {
                path = savefile.FileName;
            }
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@path))
            {
                file.Write(text);
            }

            Process.Start("notepad.exe", path);
        }
        public void uploadReport(String report)
        {
            try
            {
                main.addText("\r\n --- Beginning Upload ---");

                // Get the object used to communicate with the server.
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://www.kautzman.com/test.txt");
                request.Method = WebRequestMethods.Ftp.UploadFile;

                // This example assumes the FTP site uses anonymous logon.
                request.Credentials = new NetworkCredential("sysinfo@kautzman.com", "sysUpload1");

                // Copy the contents of the file to the request stream.
                byte[] fileContents = Encoding.UTF8.GetBytes(report);
                request.ContentLength = fileContents.Length;

                Stream requestStream = request.GetRequestStream();
                requestStream.Write(fileContents, 0, fileContents.Length);
                requestStream.Close();

                FtpWebResponse response = (FtpWebResponse)request.GetResponse();

                Console.WriteLine("Upload File Complete, status {0}", response.StatusDescription);

                response.Close();

                main.addText("Upload Completed Successfully!");
                main.addText("Report available at:");
                main.addText("http://www.kautzman.com/sysinfo/test.txt");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error uploading file to server \r\n\r\n" + ex);
                main.addText("Upload Failed!");
            }
        }
        public void run()
        {
            String report = "";

            try
            {
                report = GenerateReport();
                // writeReport(report);
                uploadReport(report);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failure to generate/upload report \n\n Error: \n" + ex);
            }
        }
    }
}
