using Amdocs.Ginger.Plugin.Core;
using System;
using System.Diagnostics;
using System.IO;
using System.Collections.Generic;
using GingerPythonPluginConsole;

namespace GingerPythonPlugin
{
    [GingerService("Python", "Run Python")]
    public class GingerPythonService : IGingerService, IStandAloneAction
    {

        

        [GingerAction("RunScript", "Run Script")]
        public void RunScript(IGingerAction GA, string scriptContent,List<Arg> args=null)  
        {
            Console.WriteLine("start RunPythonScript");

            PythonProcess p = PythonProcess.Builder();
            Scope scope = Scope.Builder().
                SetContent(scriptContent);
            if (args != null){
                foreach (Arg a in args)
                    scope.AddVariable(a.value);
            }

            p.Execute(scope);
            var OutputItems = p.getOutput();
            foreach (var v in OutputItems)
            {
                GA.AddOutput(v.Key , v.Value);
                Console.WriteLine(v.Key + v.Value);
            }



            Console.WriteLine("End RunPythonScript");
        }

        [GingerAction("RunScriptFile", "Run Script file")]
        public void RunScriptFile(IGingerAction GA, string scriptFileName,  List<Arg> args=null)
        {
            Console.WriteLine("start RunPythonScript");

            PythonProcess p = PythonProcess.Builder();
            Scope scope = Scope.Builder().SetFile(scriptFileName);
            if (args != null)
            {
                foreach (Arg a in args)
                    scope.AddVariable(a.value);
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
