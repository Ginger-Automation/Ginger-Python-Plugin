using System;
using System.Diagnostics;
using System.IO;


using IronPython.Hosting;
using IronPython.Runtime;
using IronPython;
using Microsoft.Scripting.Hosting;
using Microsoft.Scripting;


namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            RunPython("c:\\Ronen\\development\\python\\GingerPythonPlugin\\sum.py");
            RunPythonScript();
            CallPythonFunc();
        }


        static public void RunPython(string PythonFile)
        {
            Console.WriteLine("start RunPython");
            ScriptScope scope = null;
            if (PythonFile != null)
            {
                var engine = Python.CreateEngine();
                scope = engine.CreateScope();

                Console.WriteLine("Run filename- " + PythonFile);
                ScriptSource source = engine.CreateScriptSourceFromFile(PythonFile);

                scope.SetVariable("A", 4);
                scope.SetVariable("B", 3);
                object result = source.Execute(scope);
                Console.WriteLine(scope.GetVariable("sum"));

            }
            else
                Console.WriteLine("Please provide python file name");

            Console.WriteLine("End RunPython");


            
        }

        static public void RunPythonScript()
        {
            Console.WriteLine("start RunPythonScript");
            ScriptScope scope = null;
            
            var engine = Python.CreateEngine();
            scope = engine.CreateScope();


            scope.SetVariable("A", 4);
            scope.SetVariable("B", 3);
            engine.Execute("print A;print B; sum=A+B", scope);
            Console.WriteLine(scope.GetVariable("sum"));

            Console.WriteLine("End RunPythonScript");


        }

        static public void CallPythonFunc()
        {
            Console.WriteLine("start CallPythonFunc");
            ScriptScope scope = null;

            var engine = Python.CreateEngine();
            scope = engine.CreateScope();


            var pySrc =
                @"def sum(A, B):
                return A + B";
            engine.Execute(pySrc, scope);

            // get function and dynamically invoke
            var sum = scope.GetVariable("sum");
            var result = sum(34, 8); // returns 42 (Int32)

            // get function with a strongly typed signature
            var sumTyped = scope.GetVariable<Func<decimal, decimal, decimal>>("sum");
            var resultTyped = sumTyped(5, 7);

            Console.WriteLine("End CallPythonFunc");


        }


       



    }
}





