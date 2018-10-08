using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;

namespace PythonLib
{
   

    class Scope
    {
        String[] args;
        String scriptPath;
        String baseDir = "./";
 
         public static Scope Builder(String sciptName, String content)
         {
            Scope Scope = new Scope();
            Scope.CreateScope(sciptName, content);
            return Scope;
         }


        private Scope CreateScope(String sciptName, String content)
        {
            try
            {
                scriptPath = baseDir + sciptName + ".py";
                StreamWriter sw = new StreamWriter(scriptPath);
                sw.Write(content); 
                sw.Close();


            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to create python scope");
                throw e;
            }
            return this;
        }

        public Scope AddVariable(String Var)
        {
            String[] TempArgs;
            try
            {
               if (args != null && args.Length > 0){
                    TempArgs = new string[args.Length];
                    for (int i = 0; i < args.Length; i++)
                        TempArgs[i] = args[i];
                    args = new string[TempArgs.Length + 1];
                    for (int i = 0; i < TempArgs.Length; i++)
                        args[i] = TempArgs[i];
                }
                else
                    args = new string[1];
                args[args.Length - 1] = Var;

            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to add variable to scope");
                throw e;
            }
            return this;
        }


        public String getExecuteArgs()
        {
            String argStr = null;
            try
            {
                argStr = scriptPath;
                if (args != null && args.Length > 0)
                {
                    for (int i = 0; i < args.Length; i++)
                    {
                        argStr += " " + args[i];
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to get execute arguments");
                throw e;
            }
            return argStr;
        }
        

    }
}
