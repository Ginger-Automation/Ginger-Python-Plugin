using System;
using System.Diagnostics;
using System.IO;



//using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace PythonLib
{
    class Program
    {



        static void Main(string[] args)
        {
            PythonProcess p;
String script1 =
@"import sys
print 'Hello World'
a=2
b=3
print  'a=' + str(a)
print  'b=' + str(b)
sum=a+b
print 'sum=' + str(sum)";

String script2 =
@"import sys
a = sys.argv[1]
b = sys.argv[2]
print  'a=' + a
print  'b=' + b
sum = int(a) + int(b)
print 'sum=' + str(sum)";

            p = PythonProcess.Builder();
            Scope Scope1 = Scope.Builder("sum2num", script1);
            p.Execute(Scope1);
            var OutputItems1 = p.getOutput();
            foreach (var v in OutputItems1)
            {
                Console.WriteLine(v);
            }

            p = PythonProcess.Builder();
            Scope Scope2 = Scope.Builder("sum2arg", script2)
                 .AddVariable("88")
                 .AddVariable("2");
            p.Execute(Scope2);
            var OutputItems = p.getOutput();
            foreach (var v in OutputItems)
            {
                Console.WriteLine(v);
            }


            p = PythonProcess.Builder();
            Scope Scope3 = Scope.Builder("./sum2num.py");
                
            p.Execute(Scope3);
            var OutputItems3 = p.getOutput();
            foreach (var v in OutputItems3)
            {
                Console.WriteLine(v);
            }


        }





}

    
}
