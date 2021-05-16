using System;
using System.Collections.Generic;
using System.Text;

namespace EquationSolver.Services.Dto
{
    public class EquationInfoDto
    {
        public double CoefficientA { get; set; }

        public double CoefficientB { get; set; }

        public double CoefficientC { get; set; }

        public double Discriminant { get; set; }

        public double FirstRoot { get; set; }

        public double SecondRoot { get; set; }

        public DateTime SolvedAt { get; set; }
    }
}
