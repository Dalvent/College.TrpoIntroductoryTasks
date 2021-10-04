using System;
using Trpo_task_1.Core;

namespace Trpo_task_1.Equation
{
    public class LinearEquation : ILinearEquation
    {
        public double CashedLinearEquationX { get; set; }

        public double Solve(double a, double b)
        {
            if (a == 0)
                throw new ArgumentException("a can't be zero!");

            CashedLinearEquationX = -b / a;
            return CashedLinearEquationX;
        }
    }
}