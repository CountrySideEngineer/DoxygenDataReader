using Doxygen.DB;
using Doxygen.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doxygen.DAO
{
    public class TypeDefDao : ADao
    {
        public override IEnumerable<ParamDtoBase> GetAll(DbContext context)
        {
            DoxygenDbContext doxygenContext = (DoxygenDbContext)context;
            var memberDefModels = doxygenContext.MemberDefModels
                .Where(_ => _.Kind.ToLower() == "typedef")
                .ToList();

            var dtos = new List<ParamDtoBase>();
            foreach (var item in memberDefModels)
            {
                var dto = new ParamDto()
                {
                    Id = item.RowId,
                    Name = item.Name,
                    Type = item.Type
                };
                dtos.Add(dto);
            }

            return dtos;
        }
    }
}
