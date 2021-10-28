using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab.Drozdov;

namespace Lab
{
    class Program
    {
        private const string RootDirectoryPath = @"../../../../";
        private const string Version = "version";
        
        private static async Task InitApp()
        {
            AppInfo.Version = (await File.ReadAllTextAsync(($"{RootDirectoryPath}{Version}"))).Trim();
        }
        
        static async Task Main(string[] args)
        {
            ApplyRuConsole();
            await InitApp();

            DrozdovLog.Instance.InitLogDirectory(GetProjectRootPath());
            
            DrozdovLog.Instance.Log("Введите a, b и c");
            float a = Convert.ToSingle(DrozdovLog.Instance.ReadLine(), CultureInfo.InvariantCulture);
            float b = Convert.ToSingle(DrozdovLog.Instance.ReadLine(), CultureInfo.InvariantCulture);
            float c = Convert.ToSingle(DrozdovLog.Instance.ReadLine(), CultureInfo.InvariantCulture);

            try
            {
                bool isSquare = a != 0;
                string aPartOfEquation = isSquare ? $"{a}a^2 + " : "";
                DrozdovLog.Instance.Log($"{(isSquare ? "Квадратное уравнение" : "Линейное уравнение")} {aPartOfEquation}{b}b + {c}c = 0");

                var squareEquation = new SquareEquation();
                DrozdovLog.Instance.Log(SquareEquationResultToString(squareEquation.Solve(a, b, c)));
            }
            catch (DrozdovException ex)
            {
                DrozdovLog.Instance.Log("Уравнение не существует");
            }
            
            DrozdovLog.Instance.Write();
            Console.ReadLine();
        }

        private static string SquareEquationResultToString(List<float> results)
        {
            int i = 0;
            return String.Join("\n", results.Select(x => $"x{++i} {x}"));
         }
        
        private static void ApplyRuConsole()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            var enc1251 = Encoding.GetEncoding(1251);

            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = enc1251;
        }

        private static string GetProjectRootPath()
        {
            return $"{RootDirectoryPath}Log";
        }
        
        private static string GetRoamingPath()
        {
            return Environment.ExpandEnvironmentVariables("%appdata%/Log");
        }
    }
}