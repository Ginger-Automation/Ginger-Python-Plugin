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

namespace GingerPythonPlugin
{
    [GingerService("SHELL", "Shell Server")]
    public class GingerPythonService : IGingerService, IStandAloneAction
    {

        [GingerAction("RunPython", "Run Python file" )]
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
                object result = source.Execute(scope);
                // GA.AddOutput(string param, object value, string path = null);

           //    engine.Runtime.Globals.SetVariable("property_value", "TB Test");
           //     scope.SetVariable("name","value");


            }
            else
                Console.WriteLine("Please provide python file name");

            Console.WriteLine("End RunPython");


            return scope;
        }


        [GingerAction("RunPython", "Run Python script")]
        public ScriptScope RunPythonScript(IGingerAction GA, string script, List<String> LibList)
        {
            ScriptScope scope = null;
            Console.WriteLine("Start RunPythonScript");

            var engine = Python.CreateEngine();
            if (LibList != null && LibList.Count > 0)
            {
                var searchPaths = engine.GetSearchPaths();
                foreach (String lib in LibList)
                    searchPaths.Add(@lib);
                engine.SetSearchPaths(searchPaths);
            }
            ScriptSource source = engine.CreateScriptSourceFromString(script);
            source.Execute();

            Console.WriteLine("End RunPythonScript");
            return scope;
        }


    }
}
