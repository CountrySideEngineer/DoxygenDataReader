using Doxygen.DB;
using Doxygen.DTO;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;

namespace Doxygen.DAO
{
    public abstract class AFileDao : ADao
    {
        /// <summary>
        /// Abstract method which returns file extension.
        /// </summary>
        /// <returns>File extension.</returns>
        protected abstract string GetFileExtension();

        /// <summary>
        /// Default constructor.
        /// </summary>
        public AFileDao() { }

        protected virtual IQueryable<dynamic> GetFiles(DbContext context)
        {
            DoxygenDbContext doxygenContext = (DoxygenDbContext)context;

            string fileExt = GetFileExtension();
            int fileExtLen = fileExt.Length;

            var pathModels = doxygenContext.PathModels;
            var compoundDefModels = doxygenContext.CompoundDefModels;
            var files = compoundDefModels.Join(
                pathModels,
                compound => compound.FileId,
                path => path.RowId,
                (compound, path) => new
                {
                    Id = compound.RowId,
                    Name = compound.Name,
                    Path = path.Name,
                    Kind = compound.Kind,
                    FileId = compound.FileId,
                })
                .Where(_ =>
                    _.Kind.Equals("file") &&
                    _.Path.Substring(
                        _.Path.Length - fileExtLen,
                        fileExtLen).ToLower().Equals(fileExt));

            return files;
        }

        protected virtual IEnumerable<ParamDtoBase> ConvertToDto(dynamic files)
        {
            var fileDtos = new List<ParamDtoBase>();
            foreach (var item in files)
            {
                FileDto dto = new FileDto()
                {
                    Id = item.FileId,
                    Name = item.Name,
                    Path = item.Path
                };
                fileDtos.Add(dto);
            }
            return fileDtos;
        }

        /// <summary>
        /// Read all file informatino from data base.
        /// </summary>
        /// <param name="context">Data base context.</param>
        /// <returns>Collection of file information from data base.</returns>
        public override IEnumerable<ParamDtoBase> GetAll(DbContext context)
        {
#if !USING_DOT_NET
            context.Database.EnsureCreated();
#endif
            var files = GetFiles(context);

            IEnumerable<ParamDtoBase> fileDtos = ConvertToDto(files);

            return fileDtos;
        }
    }
}
