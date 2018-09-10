using Microsoft.VisualStudio.TestTools.UnitTesting;
using GingerPythonPlugin;
using Amdocs.Ginger.Plugin.Core;
using System;
using System.IO;

namespace GingerPythonPluginTest
{
    [TestClass]
    public class GingerPythonPluginUnitTest
    {
        [TestMethod]
        public void TestGingerPythonPlugin_RunPythonFile()
        {
            GingerPythonService service = new GingerPythonService();
            GingerAction GA = new GingerAction();

            Console.WriteLine("start TestGingerPythonPlugin_RunPythonFile");

            String fileName = "c:\\Ronen\\Robot\\red\\workspace\\ginger-robot\\test\\openFile.py";
            service.RunPython(GA, fileName);
            StreamReader sr = new StreamReader(fileName);

            //Assert
            Assert.IsNotNull( sr, "No Errors");
            Assert.IsNull(sr, "Python file was not executed successfully");


        }


        [TestMethod]
        public void TestGingerPythonPlugin_RunPythonScript()
        {
            GingerPythonService service = new GingerPythonService();
            GingerAction GA = new GingerAction();
            String fileName = "c:\\Ronen\\Robot\\red\\workspace\\ginger-robot\\test\\openFile.py";
            Console.WriteLine("start TestGingerPythonPlugin_RunPythonFile");

            String script =
                    "#!/usr/bin/python" +
                    "import os" +
                    "def createFile():" +
                    "  filenName = 'testfile.txt'" +
                    "  if os.path.exists(filenName):" +
                    "    os.remove(filenName)" +
                    "  f = open(filenName, 'w+')" +
                    "  f.write('Now the file has one more line!')" +
                    "createFile();";
            
            service.RunPythonScript(GA, script);
            StreamReader sr = new StreamReader(fileName);

            //Assert
            Assert.IsNotNull(sr, "No Errors");
            Assert.IsNull(sr, "Python script was not executed successfully");


        }
    }
}
