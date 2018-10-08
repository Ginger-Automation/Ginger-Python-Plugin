using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;


namespace PythonLib
{
    class PythonProcess
    {
        Process p = null;

        public static PythonProcess Builder()
        {
            PythonProcess PythonProcess = new PythonProcess();
            PythonProcess.CreateProcess();
            return PythonProcess;
        }

        private  Process CreateProcess()
        {
            p = new Process();

            try
            {
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                    p.StartInfo.FileName = "python";
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                    p.StartInfo.FileName = "python.exe";
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to create process");
                throw e;
            }
           

            return p;
        }


        public Scope Execute(Scope Scope)
        {
            try
            {
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.UseShellExecute = false;
                if (Scope != null)
                {
                    String ScriptArgs = Scope.getExecuteArgs();
                    if (ScriptArgs != null)
                    {
                        p.StartInfo.Arguments = ScriptArgs; 
                        p.Start();
                        StreamReader s = p.StandardOutput;
                        String output = s.ReadToEnd();
                        Console.WriteLine(output);
                    }
                    else
                        Console.WriteLine("Invalid script parameters");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to execute process");
                throw e;
            }


            return Scope;
        }


    }
}
