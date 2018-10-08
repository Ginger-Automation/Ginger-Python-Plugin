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

String script1 =
@"import sys
print 'Hello World'
a=2
b=3
print  a
print  b
sum=a+b
print sum";

String script2 =
@"import sys
a = sys.argv[1]
b = sys.argv[2]
print  'a = ' + a
print  'b = ' + b
sum = int(a) + int(b)
print 'sum= ' + str(sum)";

            PythonProcess p = PythonProcess.Builder();
            Scope Scope1 = Scope.Builder("sum2num", script1);
            p.Execute(Scope1);

            Scope Scope2 = Scope.Builder("sum2arg", script2)
                 .AddVariable("1")
                 .AddVariable("2");
            p.Execute(Scope2);


        }





}

    
}
