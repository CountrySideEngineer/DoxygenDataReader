using Doxygen.DB.Table;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doxygen.DB
{
    public class DoxygenDbContext : DbContext
    {
        public DbSet<PathModel> PathModels { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=.\\doxygen_sqlite3.db");
        }
    }
}
