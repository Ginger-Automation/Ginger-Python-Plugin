using Amdocs.Ginger.Plugin.Core;
using System;

namespace GingerPythonPlugin
{
    [GingerService("SHELL", "Shell Server")]
    public class GingerPythonService : IGingerService, IStandAloneAction
    {

        [GingerAction("RunPython", "Run Python Command")]
        public void RunPython(IGingerAction GA, string PythonFile)
        {
            string retOutput;

        }
    }
}
