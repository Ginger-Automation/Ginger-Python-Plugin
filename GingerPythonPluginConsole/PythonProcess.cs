using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace GingerPythonPlugin
{
    class PythonProcess
    {
        Process p = null;
        Dictionary<string, string> OutputMap = new Dictionary<string, string>(); 

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
                        StoreOutput(output);
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

        public Dictionary<string, string> getOutput()
        {
            return OutputMap;
        }
        public void clearOutput()
        {
            OutputMap = new Dictionary<string, string>();
        }

        private void StoreOutput(String output)
        {
           int i = 0;
           var OutputItems = Regex.Split(output, "\r\n|\r|\n");
            foreach (var v in OutputItems)
            {
               if (v != null && v != "")
               {
                 var keyValue =  v.Split("=");
                 if (keyValue != null && keyValue.Length == 1){
                   i++;
                   OutputMap.Add("Param" + i, keyValue[0]);
                 }
                 else if (keyValue != null && keyValue.Length == 2){
                        OutputMap.Add(keyValue[0], keyValue[1]);
                 }

               }
                
            }
        }

    }
}
