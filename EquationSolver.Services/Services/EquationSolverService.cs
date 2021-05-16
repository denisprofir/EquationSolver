using EquationSolver.Data.Models;
using EquationSolver.Data.Repositories;
using EquationSolver.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquationSolver.Services.Services
{
    public class EquationSolverService : IEquationSolverService
    {
        private readonly IEquationDataRepository _equationDataRepository;

        public EquationSolverService(IEquationDataRepository equationDataRepository)
        {
            _equationDataRepository = equationDataRepository;
        }

        public async Task CalculateAndStoreEquationResult(double a, double b, double c)
        {
            var isAlreadySolvedForCoefficients = await _equationDataRepository.IsAlreadySolvedForCoefficients(a, b, c);

            if (isAlreadySolvedForCoefficients)
            {
                return;
            }

            var discriminant = Math.Pow(b, 2) - (4 * a * c);
            var roots = CalculateRoots(discriminant, a, b);

            var equationData = MapResultsToEquationData(a, b, c, discriminant, roots);
            await _equationDataRepository.Add(equationData);
        }

        public async Task<List<EquationInfoDto>> GetAllValidEquationResults()
        {
            var equationsData = await _equationDataRepository.GetAllAsync();
            var equationInfoDtos = equationsData.Select(x => new EquationInfoDto
            {
                CoefficientA = x.CoefficientA,
                CoefficientB = x.CoefficientB,
                CoefficientC = x.CoefficientC,
                Discriminant = x.Discriminant,
                FirstRoot = x.FirstRoot.GetValueOrDefault(),
                SecondRoot = x.SecondRoot.GetValueOrDefault(),
                SolvedAt = x.SolvedAt
            }).ToList();

            return equationInfoDtos;
        }

        private (double? FirstRoot, double? SecondRoot) CalculateRoots(double discriminant, double a, double b)
        {
            if (discriminant < 0)
            {
                return (null, null);
            }

            var x1 = (-b - Math.Sqrt(discriminant)) / (2 * a);
            var x2 = (-b + Math.Sqrt(discriminant)) / (2 * a);

            return (FirstRoot: Math.Round(x1, 2), SecondRoot: Math.Round(x2, 2));
        }

        private static EquationData MapResultsToEquationData(double a, double b, double c, double discriminant, (double? FirstRoot, double? SecondRoot) roots)
        {
            return new EquationData
            {
                CoefficientA = a,
                CoefficientB = b,
                CoefficientC = c,
                Discriminant = discriminant,
                FirstRoot = roots.FirstRoot,
                SecondRoot = roots.SecondRoot,
                IsValidEquation = !(roots.FirstRoot == null || roots.SecondRoot == null),
                SolvedAt = DateTime.Now
            };
        }
    }
}
