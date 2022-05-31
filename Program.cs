using System;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;
namespace AdmCallNamespace
{
    class AdmCall
    {
        static void Main(string[] args)
        {
            using (StreamWriter sw = new StreamWriter("admcall.log"))
            {
                try
                {
                    List<string> execCMD = new List<string>();
                    using (StreamReader sr = new StreamReader("commandlist.txt"))
                    {
                        string cmd;
                        while ((cmd = sr.ReadLine()) != null)
                        {
                            Process myProcess = new Process();
                            myProcess.StartInfo.UseShellExecute = true;
                            myProcess.StartInfo.WorkingDirectory = Environment.CurrentDirectory;
                            myProcess.StartInfo.FileName = cmd;
                            myProcess.StartInfo.Verb = "runas";
                            sw.Write("Executing: " + cmd + "\t");
                            myProcess.Start();
                            myProcess.WaitForExit();
                            sw.WriteLine("ExitCode: " + myProcess.ExitCode);
                        }
                        execCMD = null;
                    }
                }
                catch (Exception e)
                { //Exception;
                    sw.WriteLine(e.ToString());
                }
            }
        }
    }
}