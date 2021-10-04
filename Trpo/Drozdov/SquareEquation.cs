using System;
using Trpo_task_1.Core;

namespace Trpo_task_1.Equation
{
    public class SquareEquation : LinearEquation, IEquation
    {
        public double[] CashedSquareEquationXs { get; set; }
        
        public double[] Solve(double a, double b, double c)
        {
            CashedSquareEquationXs = CalculateSquareEquitation(a, b, c);
            return CashedSquareEquationXs;
        }

        private double[] CalculateSquareEquitation(double a, double b, double c)
        {
            if (a == 0) 
                return new[] { base.Solve(b, c) };

            double discriminant = Discriminant(a, b, c);

            if (discriminant < 0)
                return Array.Empty<double>();

            if (discriminant == 0)
                return new[] { (-b) / (2 * a) };

            var sqrtDiscriminant = Math.Sqrt(discriminant);
            return new[] {( -b + sqrtDiscriminant) / (2 * a), (-b - sqrtDiscriminant) / (2 * a) };
        }
        

        protected double Discriminant(double a, double b,  double c)
        {
            return b * b - 4 * a * c;
        }
    }
}