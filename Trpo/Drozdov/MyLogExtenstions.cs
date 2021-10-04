using System;

namespace Trpo_task_1.Drozdov
{
    public static class MyLogExtenstions
    {
        public static string ReadLine(this MyLog myLog)
        {
            var line = Console.ReadLine();
            myLog.Log(line);
            return line;
        }
    }
}