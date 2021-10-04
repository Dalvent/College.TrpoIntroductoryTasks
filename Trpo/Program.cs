using System;
using System.Collections;
using System.Collections.Generic;

namespace Trpo_task_1
{
    public class A
    {
        public double CashedLinearEquationX { get; set; }

        public double LinearEquation(double a, double b)
        {
            if (a == 0)
                throw new ArgumentException("a can't be zero!");

            CashedLinearEquationX = -b / a;
            return CashedLinearEquationX;
        }
    }

    public class B : A
    {
        public double[] CashedSquareEquationXs { get; set; }

        public double[] SquareEquation(double a, double b, double c)
        {
            CashedSquareEquationXs = CalculateSquareEquitation(a, b, c);
            return CashedSquareEquationXs;
        }

        private double[] CalculateSquareEquitation(double a, double b, double c)
        {
            if (a == 0)
                return new[] { LinearEquation(b, c) };

            double discriminant = Discriminant(a, b, c);

            if (discriminant < 0)
                return Array.Empty<double>();

            if (discriminant == 0)
                return new[] { (-b) / (2 * a) };

            var sqrtDiscriminant = Math.Sqrt(discriminant);
            return new[] { (-b + sqrtDiscriminant) / (2 * a), (-b - sqrtDiscriminant) / (2 * a) };
        }


        protected double Discriminant(double a, double b, double c)
        {
            return b * b - 4 * a * c;
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            var a = new B();

            double linearEquationResult = a.LinearEquation(1.0, 2.0);
            var squareEquationResult = a.SquareEquation(1.0, 2.2, 3.2);
        }
    }
}