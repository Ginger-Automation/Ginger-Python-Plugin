using Amdocs.Ginger.Plugin.Core;
using GingerPythonPlugin;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;

namespace GingerIronPythonPluginTest
{
    [TestClass]
    public class GingerPythonPluginUnitTest
    {

       
        
        [TestMethod]
        public void RunScript1()
        {
            // Arrange
            GingerPythonService service = new GingerPythonService();
            GingerAction GA = new GingerAction();

String script1 =
@"a=2
b=3
print  'a=' + str(a)
print  'b=' + str(b)
sum=a+b
print 'sum=' + str(sum)";
            //Act
            service.RunScript(GA,"sum", script1);
           

            //Assert
            Assert.AreEqual("2", GA.Output["a"]);
            Assert.AreEqual("3", GA.Output["b"]);
            Assert.AreEqual("5", GA.Output["sum"]);
        }

        [TestMethod]
        public void RunScript2()
        {
            // Arrange
            GingerPythonService service = new GingerPythonService();
            GingerAction GA = new GingerAction();

String script2 =
@"a = 'hello'
b = ' world' 
str = a + b
print 'str=' + 'hello world'
";

            //Act
            service.RunScript(GA,"concut", script2,null);

            //Assert
             Assert.AreEqual("hello world", GA.Output["str"]);
        }


        [TestMethod]
        public void RunScript3()
        {
            // Arrange
            GingerPythonService service = new GingerPythonService();
            GingerAction GA = new GingerAction();

String script3 =
@"a = 3
b = 4
c = max(a, b)
print 'a=' + str(a)
print 'b=' + str(b)
print 'c=' + str(c)
";
            //Act
            service.RunScript(GA,"max", script3,null);

            //Assert
            Assert.AreEqual("3", GA.Output["a"]);
            Assert.AreEqual("4", GA.Output["b"]);
            Assert.AreEqual("4", GA.Output["c"]);
        }
    

    [TestMethod]
    public void RunScript4()
    {
        // Arrange
        GingerPythonService service = new GingerPythonService();
        GingerAction GA = new GingerAction();

String script4 =
@"a = 3
b = 4
c = min(a, b)
print 'a=' + str(a)
print 'b=' + str(b)
print 'c=' + str(c)
";
        //Act
        service.RunScript(GA, "min", script4,null);

        //Assert
        Assert.AreEqual("3", GA.Output["a"]);
        Assert.AreEqual("4", GA.Output["b"]);
        Assert.AreEqual("3", GA.Output["c"]);
    }

        [TestMethod]
        public void RunScript5()
        {
            // Arrange
            GingerPythonService service = new GingerPythonService();
            GingerAction GA = new GingerAction();

String script5 =
@"a=2
b=3
print  str(a)
print  str(b)
sum=a+b
print 'sum=' + str(sum)";
            //Act
            service.RunScript(GA, "sum1", script5,null);


            //Assert
            Assert.AreEqual("2", GA.Output["Param1"]);
            Assert.AreEqual("3", GA.Output["Param2"]);
            Assert.AreEqual("5", GA.Output["sum"]);
        }


        [TestMethod]
        public void RunScript6()
        {
            // Arrange
            GingerPythonService service = new GingerPythonService();
            GingerAction GA = new GingerAction();

String script6 =
@"import sys
a = sys.argv[1]
b = sys.argv[2]
print  'a=' + a
print  'b=' + b
sum = int(a) + int(b)
print 'sum=' + str(sum)";
            //Act
            String[] args = new string[2];
            args[0] = "4";
            args[1] = "7";
            service.RunScript(GA, "sum", script6, args);


            //Assert
            Assert.AreEqual("4", GA.Output["a"]);
            Assert.AreEqual("7", GA.Output["b"]);
            Assert.AreEqual("11", GA.Output["sum"]);
        }
//======================  Script file  ==================
        [TestMethod]
        public void RunScript7()
        {
            // Arrange
            GingerPythonService service = new GingerPythonService();
            GingerAction GA = new GingerAction();


            //Act
            String[] args = new string[2];
            args[0] = "5";
            args[1] = "6";
 
            service.RunScriptFile(GA, "./sum-file.py", args);


            //Assert
            Assert.AreEqual("5", GA.Output["a"]);
            Assert.AreEqual("6", GA.Output["b"]);
            Assert.AreEqual("11", GA.Output["sum"]);
        }
        
    

    }
   




}




/*
               [TestMethod]
               public void TestGingerPythonPlugin_RunPythonFile()
               {
                   GingerPythonService service = new GingerPythonService();
                   GingerAction GA = new GingerAction();
                 //  String BasePath = "c:/Ronen/development/python/GingerPythonPlugin/";
                   String BasePath = "";
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
       */
