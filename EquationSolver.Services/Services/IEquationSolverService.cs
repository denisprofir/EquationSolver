using EquationSolver.Data.Models;
using EquationSolver.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EquationSolver.Services.Services
{
    public interface IEquationSolverService    
    {
        public Task<List<EquationInfoDto>> GetAllValidEquationResults();

        public Task CalculateAndStoreEquationResult(double a, double b, double c);
    }
}
