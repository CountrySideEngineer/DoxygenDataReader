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
            optionsBuilder.UseSqlite("Data Source=.\\doxygen_sqlite3.db");
        }
    }
}
