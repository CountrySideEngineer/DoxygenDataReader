using Doxygen.DB;
using Doxygen.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doxygen.DAO
{
    public class ParamDao
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public ParamDao() { }

        public IEnumerable<ParamDto> GetAll()
        {
            using (var context = new DoxygenDbContext())
            {
                context.Database.EnsureCreated();

                var memberDefParamModels = context.MemberDefParamModels;
                var paramModels = context.ParamModels;
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
}
