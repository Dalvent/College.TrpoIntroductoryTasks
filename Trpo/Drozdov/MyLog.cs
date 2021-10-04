using System;
using Trpo_task_1.Core;

namespace Trpo_task_1.Drozdov
{
    public class MyLog : LogAbstract, ILog
    {
        public static MyLog Instance { get; } = new MyLog();
        private MyLog()
        {
        }
        
        public override void _write()
        {
            foreach (var logLine in log)
            {
                Console.WriteLine(logLine);
            }
        }

        public override void _log(string str)
        {
            log.Add(str);
        }

        public void Log(string str) 
            => Log(str);

        public void Write() 
            => _write();
    }
}