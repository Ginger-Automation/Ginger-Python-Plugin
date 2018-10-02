using Amdocs.Ginger.Plugin.Core;
using GingerPythonPlugin;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
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
            String BasePath = "c:/Ronen/development/python/GingerPythonPlugin/";
            List<String> LibList = new List<String>();
            LibList.Add("c:/Python27/Lib/");

            Console.WriteLine("start TestGingerPythonPlugin_RunPythonFile");

            String fileName = BasePath + "openFile.py";
            service.RunPython(GA, fileName, LibList);

            String testFile = BasePath + "testfile.txt";
            StreamReader sr = new StreamReader(testFile);

            //Assert
            Assert.IsNotNull( sr, "No Errors");
  

        }


        [TestMethod]
        public void TestGingerPythonPlugin_RunPythonScript()
        {
            GingerPythonService service = new GingerPythonService();
            GingerAction GA = new GingerAction();
            Console.WriteLine("start TestGingerPythonPlugin_RunPythonFile");
            List<String> LibList = new List<String>();
            LibList.Add("c:/Python27/Lib/");

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
            
            service.RunPythonScript(GA, script, LibList);


            String testFile = "c:\\Ronen\\development\\python\\GingerPythonPlugin\\testfile.txt";
            StreamReader sr = new StreamReader(testFile);

            //Assert
            Assert.IsNotNull(sr, "No Errors");
 

        }


        [TestMethod]
        public void RunScript2()
        {
            // Arrange
            GingerPythonService service = new GingerPythonService();
            GingerAction GA = new GingerAction();

            //Act
            service.RunScript2(GA, "a=1;b=2;sum=a+b");

            //Assert
            Assert.AreEqual(1, GA.Output["a"]);
            Assert.AreEqual(2, GA.Output["b"]);
            Assert.AreEqual(3, GA.Output["sum"]);
        }

        [TestMethod]
        public void RunScript3()
        {
            // Arrange
            GingerPythonService service = new GingerPythonService();
            GingerAction GA = new GingerAction();

            //Act
            service.RunScript2(GA, "a='hello';b=' world';str=a+b");

            //Assert
            Assert.AreEqual("hello", GA.Output["a"]);
            Assert.AreEqual(" world", GA.Output["b"]);
            Assert.AreEqual("hello world", GA.Output["str"]);
        }


        [TestMethod]
        public void RunScript4()
        {
            // Arrange
            GingerPythonService service = new GingerPythonService();
            GingerAction GA = new GingerAction();

            //Act
            service.RunScript2(GA, "a=3;b=4;c=max(a,b)");

            //Assert
            Assert.AreEqual(3, GA.Output["a"]);
            Assert.AreEqual(4, GA.Output["b"]);
            Assert.AreEqual(4, GA.Output["c"]);
        }


    }
}
