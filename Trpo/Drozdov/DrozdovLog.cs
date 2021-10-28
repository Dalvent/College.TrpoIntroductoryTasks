using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Trpo.Core;

namespace Trpo.Drozdov
{
    public class DrozdovLog : LogAbstract, LogInterface
    {
        public static DrozdovLog Instance { get; } = new();

        private List<string> logHistory = new();
        private string _directoryPath;
        
        private DrozdovLog()
        {
        }

        public LogInterface Write()
        {
            WriteLogsToConsole();
            
            return this;
        }

        public LogInterface Log(string str)
        {
            logHistory.Add(str);
            return this;
        }
        
        private void WriteLogsToConsole()
        {
            foreach (string log in logHistory)
            {
                Console.WriteLine(log);
            }
        }
    }
}