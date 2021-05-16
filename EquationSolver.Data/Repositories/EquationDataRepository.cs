using EquationSolver.Data.Context;
using EquationSolver.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EquationSolver.Data.Repositories
{
    public class EquationDataRepository : IEquationDataRepository
    {
        private readonly EquationSolverContext _context;

        public EquationDataRepository(EquationSolverContext context)
        {
            _context = context;
        }

        public async Task Add(EquationData equationData)
        {
            await _context.EquationData.AddAsync(equationData);
            await _context.SaveChangesAsync();
        }

        public async Task<List<EquationData>> GetAllAsync() => await _context.EquationData.Where(x => x.IsValidEquation).AsNoTracking().ToListAsync();

        public async Task<bool> IsAlreadySolvedForCoefficients(double a, double b, double c) => await _context.EquationData.AnyAsync(SameEquationFunc(a, b, c));

        private static Expression<Func<EquationData, bool>> SameEquationFunc(double a, double b, double c)
        {
            return x => x.CoefficientA == a && x.CoefficientB == b && x.CoefficientC == c;
        }
    }
}
