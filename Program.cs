using System;
using System.Diagnostics;
//using System.Security.Principal;

//WindowsIdentity id = WindowsIdentity.GetCurrent();
//WindowsPrincipal pr = new WindowsPrincipal(id);
namespace AdmCallNamespace
{
    class AdmCall
    {
        static void Main(string[] args)
        {
            try
            {
                /*
                ProcessStartInfo si = new ProcessStartInfo();
                si.UseShellExecute = true;
                si.WorkingDirectory = Directory.GetCurrentDirectory();
                si.FileName = "cmd";
                si.Arguments = "/c SetIP.exe";
                if (!pr.IsInRole(System.Security.Principal.WindowsBuiltInRole.Administrator))
                { //Call SetIP.exe use Administrator's privilege;
                    si.Verb = "RunAs";
                }
                Process.Start(si);
                */
                Process myProcess = new Process();
                myProcess.StartInfo.UseShellExecute = true;
                myProcess.StartInfo.WorkingDirectory = Environment.CurrentDirectory;
                myProcess.StartInfo.FileName = "SetIP.exe";
                //myProcess.StartInfo.FileName = "cmd";
                //myProcess.StartInfo.Arguments = "/c D:\\test\\SetIP.lnk";
                myProcess.StartInfo.Verb = "runas";
                /*
                myProcess.StartInfo.UseShellExecute = false;
                myProcess.StartInfo.FileName = "runas";
                myProcess.StartInfo.Arguments = "/turstlevel:0x40000 SetIP.exe";
                */
                myProcess.Start();

            }
            catch (Exception e)
            { //Exception;
                Console.WriteLine(e.ToString());
            }
        }
    }
}