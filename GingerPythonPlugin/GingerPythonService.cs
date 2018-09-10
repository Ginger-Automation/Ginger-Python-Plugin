using Amdocs.Ginger.Plugin.Core;
using System;
using System.Diagnostics;
using System.IO;


using IronPython.Hosting;
using IronPython.Runtime;
using IronPython;
using Microsoft.Scripting.Hosting;
using Microsoft.Scripting;





namespace GingerPythonPlugin
{
    [GingerService("SHELL", "Shell Server")]
    public class GingerPythonService : IGingerService, IStandAloneAction
    {

        [GingerAction("RunPython", "Run Python file")]
        public ScriptScope RunPython(IGingerAction GA, string PythonFile)
        {
            Console.WriteLine("start RunPython");
            ScriptScope scope = null;
            if (PythonFile != null)
            {
                var pythonEngine = Python.CreateEngine();
                scope = pythonEngine.CreateScope();

                Console.WriteLine("Run filename- " + PythonFile);
                ScriptSource source = pythonEngine.CreateScriptSourceFromFile(PythonFile);
                object result = source.Execute(scope);
                // need to get the prints from the python script
                // GA.AddOutput(string param, object value, string path = null);

         //       pythonEngine.Runtime.Globals.SetVariable("property_value", "TB Test");
         //       scope.SetVariable("name","value");


            }
            else
                Console.WriteLine("Please provide python file name");

            Console.WriteLine("End RunPython");


            return scope;
        }


        [GingerAction("RunPython", "Run Python script")]
        public ScriptScope RunPythonScript(IGingerAction GA, string script)
        {
            ScriptScope scope = null;
            Console.WriteLine("Start RunPythonScript");

            var pythonEngine = Python.CreateEngine();
            ScriptSource source = pythonEngine.CreateScriptSourceFromString(script);
            source.Execute();

            Console.WriteLine("End RunPythonScript");
            return scope;
        }


/*
        [GingerAction("TestScope", "Run Python script")]
        public ScriptScope TestScope(IGingerAction GA, string script)
        {
            try
            {
                var engine = Python.CreateEngine();
                var scope = engine.CreateScope();
                scope.SetVariable("A", 42);
                engine.Execute("print Sum; bar=A+11", scope);
                Console.WriteLine(scope.GetVariable("bar"));
            }
            catch(Exception e
            {
                e.send
            }
        }


        [GingerAction("setVariable", "Set variable value")]
               public ScriptScope SetVariable(IGingerAction GA, ScriptScope scope, String variableName, object variableValue)
               {
                   Console.WriteLine("Start SetVariable");
                   if (scope != null)
                   {
                       scope.SetVariable(variableName, variableValue);
                   }
                   Console.WriteLine("End SetVariable");
                   return scope;
               }
          

    */






    }
}
