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

        protected IEnumerable<ParamDto> GetArgumentsByIdOfFunc(int memberDefId, DoxygenDbContext context)
        {
            var memberDerParamModels = context.MemberDefParamModels;
            var paramModels = context.ParamModels;

            var argumentsModels = memberDerParamModels.Join(
                paramModels,
                memberDefParamModel => memberDefParamModel.ParamId,
                paramModel => paramModel.RowId,
                (memberDefParamModel, paramModel) => new
                {
                    Id = memberDefParamModel.RowId,
                    memberDefParamModel.MemberDefId,
                    memberDefParamModel.ParamId,
                    paramModel.Attributes,
                    paramModel.Type,
                    Name = paramModel.DeclName,
                    DefaultName = paramModel.DefName,
                    paramModel.Array,
                    DefaultValue = paramModel.DefVal,
                    paramModel.BriefDescription
                })
                .Where(_ => _.MemberDefId == memberDefId);

            var arguments = new List<ParamDto>();
            foreach (var item in argumentsModels)
            {
                var dto = new ParamDto()
                {
                    Id = item.ParamId,
                    Type = item.Type,
                    Name = item.Name,
                    DefaultName = item.DefaultName,
                    Array = item.Array,
                    DefaultValue = item.DefaultValue,
                    BriefDescription = item.BriefDescription
                };
                arguments.Add(dto);
            }

            return arguments;
        }

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
                    var arguments = GetArgumentsByIdOfFunc(item.MemberId, context);

                    var dto = new FunctionDto()
                    {
                        Id = item.Id,
                        Name = item.Name,
                        Type = item.Type,
                        Definition = item.Definition,
                        Arguments = arguments
                    };
                    dtos.Add(dto);
                }

                return dtos;
            }
        }
    }
}
