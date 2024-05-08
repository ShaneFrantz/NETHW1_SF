using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using QuartetScoreManager.Models;

namespace QuartetScoreManager.Databases
{
    public class QuartetScoreDbContext :DbContext
    {
        public DbSet<QuartetScore> QuartetScores { get; set;}
        public QuartetScoreDbContext (DbContextOptions<QuartetScoreDbContext> options) : base(options) { }
    }
}
