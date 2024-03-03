using Doxygen.DB;
using Doxygen.DTO;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Doxygen.DAO
{
    public class ParamDao : ADao
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public ParamDao() : base() { }

        public override IEnumerable<ParamDtoBase> GetAll(DbContext context)
        {
            DoxygenDbContext doxygenContext = (DoxygenDbContext)context;

            var paramModels = doxygenContext.ParamModels;
            var parameters = paramModels.ToList();

            var dtos = new List<ParamDto>();
            foreach (var item in parameters)
            {
                var dto = new ParamDto()
                {
                    Id = item.RowId,
                    Attribute = item.Attributes,
                    Type = item.Type,
                    Name = item.DeclName,
                    DefaultName = item.DefName,
                    IsArray = Convert.ToInt32(item.Array),
                    DefaultValue = item.DefVal,
                    BriefDescription = item.BriefDescription
                };
                dtos.Add(dto);
            }
            return dtos;
        }
    }
}
