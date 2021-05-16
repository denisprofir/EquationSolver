using System;
using System.Collections.Generic;
using System.Text;

namespace EquationSolver.Services.Dto
{
    public class CalculateEquationRequestDto
    {
        public double CoefficientA { get; set; }

        public double CoefficientB { get; set; }

        public double CoefficientC { get; set; }
    }
}
