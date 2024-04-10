using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace QuartetDBAppEFCore
{
    internal class QuartetScoreDBContext : DbContext
    {
        public DbSet<QuartetScore> QuartetScores { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=ShanePC;Initial Catalog=QuartetScoreDBHW;Integrated Security=True;Pooling=False;Encrypt=False;");
        }
    }
}
