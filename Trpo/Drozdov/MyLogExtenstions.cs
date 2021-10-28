using System;

namespace Trpo.Drozdov
{
    public static class MyLogExtenstions
    {
        public static string ReadLine(this DrozdovLog drozdovLog)
        {
            var line = Console.ReadLine();
            drozdovLog.Log(line);
            return line;
        }
    }
}