using Trpo_task_1.Core;

namespace Trpo_task_1.Drozdov
{
    public class LinearEquationToEquationAdapter : IEquation
    {
        private readonly ILinearEquation _linearEquation;

        public LinearEquationToEquationAdapter(ILinearEquation linearEquation)
        {
            _linearEquation = linearEquation;
        }

        public double[] Solve(double a, double b, double c = 0)
        {
            return new [] { _linearEquation.Solve(a, b) };
        }
    }
}