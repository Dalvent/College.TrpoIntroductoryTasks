﻿using Trpo_task_1.Core;

namespace Trpo_task_1.Drozdov
{
    public class LinearEquation : ILinearEquation
    {
        public double CashedLinearEquationX { get; set; }

        public double Solve(double a, double b)
        {
            if (a == 0)
                throw new DrozdovException("a can't be zero!");

            CashedLinearEquationX = -b / a;
            return CashedLinearEquationX;
        }
    }
}