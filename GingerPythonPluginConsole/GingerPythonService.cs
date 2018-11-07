using Amdocs.Ginger.Plugin.Core;
using System;
using System.Diagnostics;
using System.IO;
using System.Collections.Generic;

namespace GingerPythonPlugin
{
    [GingerService("Python", "Run Python")]
    public class GingerPythonService : IGingerService, IStandAloneAction
    {

        

        [GingerAction("RunScript", "Run Script")]
        public void RunScript(IGingerAction GA, string scriptName, string scriptContent,String[] args=null)  
        {
            Console.WriteLine("start RunPythonScript");

            PythonProcess p = PythonProcess.Builder();
            Scope scope = Scope.Builder(scriptName, scriptContent);
            if (args != null){
                for (int i = 0; i < args.Length; i++)
                    scope.AddVariable(args[i]);
            }

            p.Execute(scope);
            var OutputItems = p.getOutput();
            foreach (var v in OutputItems)
            {
                GA.AddOutput(v.Key , v.Value);
   //             Console.WriteLine(v.Key + v.Value);
            }



            Console.WriteLine("End RunPythonScript");
        }

        [GingerAction("RunScript", "Run Script")]
        public void RunScriptFile(IGingerAction GA, string scriptFileName, String[] args=null)
        {
            Console.WriteLine("start RunPythonScript");

            PythonProcess p = PythonProcess.Builder();
            Scope scope = Scope.Builder(scriptFileName);
            if (args != null)
            {
                for (int i = 0; i < args.Length; i++)
                    scope.AddVariable(args[i]);
            }

            p.Execute(scope);
            var OutputItems = p.getOutput();
            foreach (var v in OutputItems)
            {
                GA.AddOutput(v.Key, v.Value);
                //             Console.WriteLine(v.Key + v.Value);
            }



            Console.WriteLine("End RunPythonScript");
        }

    }
}
