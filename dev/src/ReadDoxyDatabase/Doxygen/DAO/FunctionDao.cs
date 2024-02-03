using Doxygen.DB;
using Doxygen.DB.Table;
using Doxygen.DTO;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doxygen.DAO
{
    public class FunctionDao
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public FunctionDao() { }

        public IEnumerable<FunctionDto> GetAll()
        {
            using (var context = new DoxygenDbContext())
            {
                context.Database.EnsureCreated();

                var memberDefParamModels = context.MemberDefParamModels;
                var memberDefModels = context.MemberDefModels;

                var functions = memberDefParamModels.Join(
                    memberDefModels,
                    memberDefParamModel => memberDefParamModel.MemberDefId,
                    memberDefModel => memberDefModel.RowId,
                    (memberDefParam, memberDefModel) => new
                    {
                        Id = memberDefParam.RowId,
                        MemberId = memberDefParam.MemberDefId,
                        ParmaId = memberDefParam.ParamId,
                        Name = memberDefModel.Name,
                        Definition = memberDefModel.Definition,
                        Type = memberDefModel.Type,
                        Kind = memberDefModel.Kind,
                    }
                    )
                    .Where(_ => _.Kind.Equals("function"))
                    .ToList()
                    .DistinctBy(_ => _.MemberId);

                var dtos = new List<FunctionDto>();
                foreach (var item in functions)
                {
                    var dto = new FunctionDto()
                    {
                        Id = item.Id,
                        Name = item.Name,
                        Type = item.Type,
                        Definition = item.Definition
                    };
                    dtos.Add(dto);
                }

                return dtos;
            }
        }
    }
}
