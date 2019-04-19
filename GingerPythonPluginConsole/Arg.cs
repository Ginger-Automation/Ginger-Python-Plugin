using System;
using System.Collections.Generic;
using System.Text;

namespace GingerPythonPluginConsole
{
    public class Arg
    {
        public string Param { get; set; }
        public string Value { get; set; }
        public Arg(String param, String value)
        {
            Param = param;
            Value = value;
        }
    }
}
