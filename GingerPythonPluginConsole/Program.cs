using System;
using GingerPythonPlugin;
using Amdocs.Ginger.Plugin.Core;
using System.Collections.Generic;

namespace GingerPythonPluginConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("start GingerPythonPluginConsole");

            GingerPythonService service = new GingerPythonService();
            GingerAction GA = new GingerAction();
            String BasePath = "c:/Ronen/development/python/GingerPythonPlugin/";
            List<String> LibList = new List<String>();
            LibList.Add("c:/Python27/Lib/");


            // Run python file
            service.RunPython(GA, BasePath + "hello.py", LibList);
            service.RunPython(GA, BasePath + "openFile.py", LibList);
            // Run python script
            service.RunPythonScript(GA, "print('hello from python script')", LibList);


            Console.WriteLine("End GingerPythonPluginConsole");

        }
    }
}
