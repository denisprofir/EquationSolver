using EquationSolver.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EquationSolver.Data.Context
{
    public class EquationSolverContext : DbContext
    {
        public EquationSolverContext(DbContextOptions<EquationSolverContext> dbContextOptions) : base(dbContextOptions)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=EquationSolverDb;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

        public DbSet<EquationData> EquationData { get; set; }
    }
}
