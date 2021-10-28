using System;
using System.Collections.Generic;
using Trpo.Core;

namespace Trpo.Drozdov
{
    public class SquareEquation : LinearEquation, EquationInterface
    {
        public List<float> CashedSquareEquationXs { get; set; }
        
        public List<float> Solve(float a, float b, float c)
        {
            var squareEquitation = CalculateSquareEquitation(a, b, c);
            if (squareEquitation.Count == 0)
                throw new DrozdovException("Equation not exist");
            
            CashedSquareEquationXs = squareEquitation;
            return squareEquitation;
        }
        
        private List<float> CalculateSquareEquitation(float a, float b, float c)
        {
            if (a == 0) 
                return new List<float>() { base.Solve(b, c) };

            float discriminant = Discriminant(a, b, c);

            if (discriminant < 0)
                return new List<float>();

            if (discriminant == 0)
                return new List<float>() { (-b) / (2 * a) };

            float sqrtDiscriminant = (float)Math.Sqrt(discriminant);
            return new List<float>() {( -b + sqrtDiscriminant) / (2 * a), (-b - sqrtDiscriminant) / (2 * a) };
        }


        private float Discriminant(float a, float b, float c)
        {
            return b * b - 4 * a * c;
        }
    }
}