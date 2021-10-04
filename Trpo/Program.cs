using System;
using System.Globalization;
using System.Linq;
using System.Text;
using Trpo_task_1.Drozdov;

namespace Trpo_task_1
{
    class Program
    {   
        static void Main(string[] args)
        {
            ApplyRuConsole();

            MyLog.Instance.Log("Введите a, b и c");
            double a = Convert.ToDouble(MyLog.Instance.ReadLine(), CultureInfo.InvariantCulture);
            double b = Convert.ToDouble(MyLog.Instance.ReadLine(), CultureInfo.InvariantCulture);
            double c = Convert.ToDouble(MyLog.Instance.ReadLine(), CultureInfo.InvariantCulture);

            try
            {
                bool isSquare = a != 0;
                string aPartOfEquation = isSquare ? $"{a}a^2 + " : "";
                MyLog.Instance.Log($"{(isSquare ? "Квадратное уравнение" : "Линейное уравнение")} {aPartOfEquation}{b}b + {c}c = 0");

                var squareEquation = new SquareEquation();
                MyLog.Instance.Log(SquareEquationResultToString(squareEquation.Solve(a, b, c)));
            }
            catch (DrozdovException ex)
            {
                MyLog.Instance.Log("Уравнение не существует");
            }
            
            MyLog.Instance.Write();
            Console.ReadLine();
        }

        private static string SquareEquationResultToString(double[] results)
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
    }
}