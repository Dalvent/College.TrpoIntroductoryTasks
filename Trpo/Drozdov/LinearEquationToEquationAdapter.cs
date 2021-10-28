using System.Collections.Generic;
using Lab.Core;

namespace Lab.Drozdov
{
    public class LinearEquationToEquationAdapter : EquationInterface
    {
        private readonly ILinearEquation _linearEquation;

        public LinearEquationToEquationAdapter(ILinearEquation linearEquation)
        {
            _linearEquation = linearEquation;
        }

        public List<float> Solve(float a, float b, float c = 0)
        {
            return new() { _linearEquation.Solve(a, b) };
        }
    }
}