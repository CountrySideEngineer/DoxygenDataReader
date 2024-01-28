using Doxygen.DB;
using Doxygen.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;

namespace Doxygen.DAO
{
    public abstract class AFileDao
    {
        protected abstract string GetFileExtension();

        /// <summary>
        /// Default constructor.
        /// </summary>
        public AFileDao() { }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public IEnumerable<FileDto> GetAll()
        {
            using (var context = new DoxygenDbContext())
            {
                context.Database.EnsureCreated();

                var pathModels = context.PathModels;
                var compoundDefModels = context.CompoundDefModels;
                var files = compoundDefModels.Join(
                    pathModels,
                    compound => compound.FileId,
                    path => path.RowId,
                    (compound, path) => new
                    {
                        Id = compound.RowId,
                        Name = compound.Name,
                        Path = path.Name,
                        Kind = compound.Kind
                    }
                    )
                    .Where(_ =>
                        _.Kind.Equals("file") &&
                        _.Path
                            .Substring(_.Path.Length - GetFileExtension().Length,
                                GetFileExtension().Length)
                            .ToLower()
                            .Equals(GetFileExtension()));

                var fileDtos = new List<FileDto>();
                foreach (var item in files)
                {
                    var dto = new FileDto()
                    {
                        Id = item.Id,
                        Name = item.Name,
                        Path = item.Path
                    };
                    fileDtos.Add(dto);
                }
                return fileDtos;
            }
        }
    }
}
