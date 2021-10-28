using System.Collections.Generic;

namespace Lab.Drozdov
{
    public class LinearEquation : ILinearEquation
    {
        public float CashedLinearEquationX { get; set; }

        public float Solve(float a, float b)
        {
            if (a == 0)
                throw new DrozdovException("a can't be zero!");

            CashedLinearEquationX = -b / a;
            return CashedLinearEquationX;
        }
    }
}