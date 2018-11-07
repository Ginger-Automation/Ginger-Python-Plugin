using Amdocs.Ginger.Plugin.Core;
using System;
using System.Diagnostics;
using System.IO;


using IronPython.Hosting;
using IronPython.Runtime;
using IronPython;
using Microsoft.Scripting.Hosting;
using Microsoft.Scripting;
using System.Collections.Generic;

namespace GingerIronPythonPlugin
{
    [GingerService("Python", "Run Python")]
    public class GingerPythonService : IGingerService, IStandAloneAction
    {

        [GingerAction("RunPythonFile", "Run Python file" )]
        public ScriptScope RunPython(IGingerAction GA, string PythonFile, List<String> LibList)
        {
            Console.WriteLine("start RunPython");
            ScriptScope scope = null;
            if (PythonFile != null)
            {
                var engine = Python.CreateEngine();
                if (LibList != null && LibList.Count > 0)
                {
                    var searchPaths = engine.GetSearchPaths();
                    foreach (String lib in LibList)
                        searchPaths.Add(@lib);
                    engine.SetSearchPaths(searchPaths);
                }
                scope = engine.CreateScope();

                Console.WriteLine("Run filename- " + PythonFile);
                ScriptSource source = engine.CreateScriptSourceFromFile(PythonFile);
                source.Execute(scope);

                var varsOut = scope.GetItems();
                foreach (var v in varsOut)
                {
                    if (v.Key.StartsWith("__")) continue; // ignore internal vars
                    GA.AddOutput(v.Key, v.Value);
                }


            }
            else
                Console.WriteLine("Please provide python file name");

            Console.WriteLine("End RunPython");


            return scope;
        }


        [GingerAction("RunPython", "Run Python script")]
        public ScriptScope RunPythonScript(IGingerAction GA, string script, List<String> LibList)
        {
            Console.WriteLine("Start RunPythonScript");

            var engine = Python.CreateEngine();
            ScriptScope scope = engine.CreateScope();
            if (LibList != null && LibList.Count > 0)
            {
                var searchPaths = engine.GetSearchPaths();
                foreach (String lib in LibList)
                    searchPaths.Add(@lib);
                engine.SetSearchPaths(searchPaths);
            }
            ScriptSource source = engine.CreateScriptSourceFromString(script);
            source.Execute();

            var varsOut = scope.GetItems();
            foreach (var v in varsOut)
            {
                if (v.Key.StartsWith("__")) continue; // ignore internal vars
                GA.AddOutput(v.Key, v.Value);
            }

            Console.WriteLine("End RunPythonScript");
            return scope;
        }

        [GingerAction("RunScript", "Run Script")]
        public void RunScript(IGingerAction GA, string script)  // replace with List , string[] vars
        {
            Console.WriteLine("start RunPythonScript");
            
            var engine = Python.CreateEngine();
            ScriptScope scope = engine.CreateScope();

            engine.Execute(script, scope);

            var varsOut = scope.GetItems();
            foreach (var v in varsOut)
            {
                if (v.Key.StartsWith("__")) continue; // ignore internal vars
                GA.AddOutput(v.Key, v.Value);
            }
            // engine.Execute("print A;print B; sum=A+B", scope);
            // int sum = scope.GetVariable("sum");
            
            Console.WriteLine("End RunPythonScript");
        }

    }
}
