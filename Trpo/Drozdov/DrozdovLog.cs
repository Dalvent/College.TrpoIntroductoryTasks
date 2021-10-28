using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Lab.Core;

namespace Lab.Drozdov
{
    public class DrozdovLog : LogAbstract, LogInterface
    {
        public static DrozdovLog Instance { get; } = new();

        private List<string> logHistory = new();
        private string _directoryPath;
        private string _versionPath;
        
        private DrozdovLog()
        {
        }

        public void InitLogDirectory(string directoryPath)
        {
            _directoryPath = directoryPath;
            CreateFolderIfNotExist(directoryPath);
        }
        
        public LogInterface Write()
        {
            WriteLogsToConsole();
            WriteLogsToFileAsync();
            
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

        private async Task WriteLogsToFileAsync()
        {
            await using StreamWriter writer = new(CreateLogFile());

            await writer.WriteLineAsync($"Версия программы {AppInfo.Version}");
            foreach (string log in logHistory)
            {
                await writer.WriteLineAsync($"{log}");
            }
        }

        private FileStream CreateLogFile()
        {
            return File.Create($"{_directoryPath}/{GenerateLogFileName()}");
        }

        private static void CreateFolderIfNotExist(string directoryPath)
        {
            if (Directory.Exists(directoryPath))
                return;

            Directory.CreateDirectory(directoryPath);
        }

        private static string GenerateLogFileName()
        {
            return $"{GetFormattedNowDate()}.log";
        }

        private static string GetFormattedNowDate()
        {
            var nowDate = DateTime.Now;
            return $"{nowDate:dd.MM.yyyy_hh.mm.ss.ffffff}";
        }
    }
}