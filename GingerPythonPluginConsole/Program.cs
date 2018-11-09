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

     /*       GingerPythonService service = new GingerPythonService();
            GingerAction GA = new GingerAction();

            String script1 =
            @"a=2
b=3
print  'a=' + str(a)
print  'b=' + str(b)
sum=a+b
print 'sum=' + str(sum)";
            //Act
            service.RunScript(GA, script1);
            */


                    GingerNodeStarter.StartNode(new GingerPythonService(), "Python Service 1");
                    Console.ReadKey();

            

            Console.WriteLine("End GingerPythonPluginConsole");

        }
    }
}
