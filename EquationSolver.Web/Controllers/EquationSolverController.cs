using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EquationSolver.Services.Dto;
using EquationSolver.Services.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EquationSolver.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EquationSolverController : ControllerBase
    {
        private readonly ILogger<EquationSolverController> _logger;
        private readonly IEquationSolverService _equationSolverService;

        public EquationSolverController(ILogger<EquationSolverController> logger, IEquationSolverService equationSolverService)
        {
            _logger = logger;
            _equationSolverService = equationSolverService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var results = await _equationSolverService.GetAllValidEquationResults();

            return Ok(results);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CalculateEquationRequestDto request)
        {
            if (request == null)
            {
                return BadRequest();
            }

            await _equationSolverService.CalculateAndStoreEquationResult(request.CoefficientA, request.CoefficientB, request.CoefficientC);

            return Ok();
        }
    }
}
