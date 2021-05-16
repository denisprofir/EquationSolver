using EquationSolver.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EquationSolver.Data.Repositories
{
    public interface IEquationDataRepository
    {
        Task<bool> IsAlreadySolvedForCoefficients(double a, double b, double c);

        Task Add(EquationData equationData);

        Task<List<EquationData>> GetAllAsync();
    }
}
