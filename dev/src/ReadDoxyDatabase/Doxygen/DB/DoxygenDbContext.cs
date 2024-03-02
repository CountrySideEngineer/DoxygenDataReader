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
        /// <summary>
        /// Path to data base.
        /// </summary>
        public string Path { get; set; } = @".\doxygen_sqlite3.db";

        /// <summary>
        /// Default constructor.
        /// </summary>
        public DoxygenDbContext() : base()
        {
            Path = ".\\doxygen_sqlite3.db";
        }

        /// <summary>
        /// Retunrs string used when connecting to data base.
        /// </summary>
        /// <returns>String to connect data base.</returns>
        protected string GetConenctionString()
        {
            string connectionString =
                $"Data Source ={Path}";
            return connectionString;
        }

        public DbSet<CompoundDefModel> CompoundDefModels { get; set; }
        public DbSet<CompoundRefModel> CompoundRefModels { get; set; }
        public DbSet<ContainsModel> ContainsModels { get; set; }
        public DbSet<IncludesModel> IncludesModels { get; set; }
        public DbSet<MemberModel> MemberModels { get; set; }
        public DbSet<MemberDefModel> MemberDefModels { get; set; }
        public DbSet<MemberDefParamModel> MemberDefParamModels { get; set; }
        public DbSet<MetaModel> MetaModels { get; set; }
        public DbSet<ParamModel> ParamModels { get; set; }
        public DbSet<PathModel> PathModels { get; set; }
        public DbSet<RefIdModel> RefIdModels { get; set; }
        public DbSet<ReimplementsModel> ReimplementsModels { get; set; }
        public DbSet<XRefsModel> XRefsModels { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = GetConenctionString();
            optionsBuilder.UseSqlite(connectionString);
        }
    }
}
