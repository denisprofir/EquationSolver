using System;
using System.Collections.Generic;
using System.Text;

namespace EquationSolver.Data.Models
{
    public class EquationData
    {
        public long Id { get; set; }

        public double CoefficientA { get; set; }

        public double CoefficientB { get; set; }

        public double CoefficientC { get; set; }

        public double Discriminant { get; set; }

        public double? FirstRoot { get; set; }

        public double? SecondRoot { get; set; }

        public bool IsValidEquation { get; set; }

        public DateTime SolvedAt { get; set; }
    }
}
