using System;
using System.Diagnostics;
using System.IO;


using IronPython.Hosting;
using IronPython.Runtime;
using IronPython;
using Microsoft.Scripting.Hosting;
using Microsoft.Scripting;


//using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
//using System.Diagnostics; // Process
//using System.IO; // StreamWriter


namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            // RunPython("c:\\Ronen\\development\\python\\GingerPythonPlugin\\sum.py");
            // RunPythonScript();
            // CallPythonFunc();
            RunNativePython2(args);

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
            int sum = scope.GetVariable("sum");
            // Console.WriteLine();

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
 //====================================    Native Python  ===========================================   

        static void RunNativePython1(string[] args)
        {
            String baseDir = "./";

          

            Process p = new Process(); // create process (i.e., the python program
            p.StartInfo.FileName = "python.exe";
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.UseShellExecute = false; // make sure we can read the output from stdout
            p.StartInfo.Arguments = baseDir + "hello.py "; // start the python program with two parameters
            p.Start(); // start the process (the python program)
            StreamReader s = p.StandardOutput;
            String output = s.ReadToEnd();
            string[] r = output.Split(new char[] { ' ' }); // get the parameter
            Console.WriteLine(r[0]);
            p.WaitForExit();

            Console.ReadLine(); // wait for a key press
        }

        static void RunNativePython2(string[] args)
        {
          //  String baseDir = "c:/Ronen/development/python/GingerPythonPlugin/";
            String baseDir = "./";

            // the python program as a string. Note '@' which allow us to have a multiline string
            String prg =
@"import sys
print 'Hello World'
a=2
b=3
print  a
print  b
sum=a+b
print sum";

            
//@"import sys
//print 'hello world'";
           


            StreamWriter sw = new StreamWriter(baseDir + "sum2arg.py");
            sw.Write(prg); // write this program to a file
            sw.Close();

            int a = 5;
            int b = 3;

            Process p = createProcess();

           
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.UseShellExecute = false; 
            p.StartInfo.Arguments = baseDir + "sum2arg.py "; // + a + " " + b; 
            p.Start(); 
            StreamReader s = p.StandardOutput;
            String output = s.ReadToEnd();

          //  string[] result = output.Split(new char[] { ' ' }); 
            
            Console.WriteLine(output);
            p.WaitForExit();

          //  Console.ReadLine(); 
        }

        private static Process  createProcess()
        {
            Process p = new Process();

            try
            {
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                    p.StartInfo.FileName = "python";
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                    p.StartInfo.FileName = "python.exe";
            }
            catch(Exception e)
            {
                Console.WriteLine("Failed to create process");
                throw e;
            }

            return p;
        }

    }




}





