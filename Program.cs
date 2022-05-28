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
                        string line;
                        while ((line = sr.ReadLine()) != null)
                        {
                            execCMD.Add(line);
                        }
                    }
                    foreach (string cmd in execCMD)
                    {
                        Process myProcess = new Process();
                        myProcess.StartInfo.UseShellExecute = true;
                        myProcess.StartInfo.WorkingDirectory = Environment.CurrentDirectory;
                        myProcess.StartInfo.FileName = cmd;
                        myProcess.StartInfo.Verb = "runas";
                        myProcess.Start();
                    }
                    execCMD = null;
                }
                catch (Exception e)
                { //Exception;
                    sw.WriteLine(e.ToString());
                }
            }
        }
    }
}