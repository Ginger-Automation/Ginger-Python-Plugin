using System;
using GingerPythonPlugin;
using Amdocs.Ginger.Plugin.Core;


namespace GingerPythonPluginConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("start GingerPythonPluginConsole");

            GingerPythonService service = new GingerPythonService();
            GingerAction GA = new GingerAction();

            service.RunPython(GA, "c:\\Ronen\\Robot\\red\\workspace\\ginger-robot\\test\\hello.py");
     //       service.RunPythonScript(GA, "print('hello from python script')");


            Console.WriteLine("End GingerPythonPluginConsole");

        }
    }
}
