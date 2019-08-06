using System;
using GingerPythonPlugin;
using Amdocs.Ginger.Plugin.Core;
using System.Collections.Generic;

namespace GingerIronPythonPluginConsole
{
    class GingerIronPythonPlugin
    {
        static void Main(string[] args)
        {
            Console.WriteLine("start GingerPythonPluginConsole");

            using (GingerNodeStarter gingerNodeStarter = new GingerNodeStarter())
            {
                if (args.Length > 0)
                {
                    gingerNodeStarter.StartFromConfigFile(args[0]);  
                }
                else
                {
                    gingerNodeStarter.StartNode("Python Service 1", new GingerPythonService());
                }                
                gingerNodeStarter.Listen();
            }

            Console.WriteLine("End GingerPythonPluginConsole");

        }
    }
}
