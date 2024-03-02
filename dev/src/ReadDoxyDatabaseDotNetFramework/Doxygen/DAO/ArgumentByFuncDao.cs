using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using Doxygen.DB;
using Doxygen.DTO;

namespace Doxygen.DAO
{
    public class ArgumentByFuncDao : ArgumentDao
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public ArgumentByFuncDao() : base() { }

        protected virtual IQueryable<dynamic> GetArguments(int callerFuncId, DbContext context)
        {
            DoxygenDbContext doxyenContext = (DoxygenDbContext)context;

            var memberDefParamModels = doxyenContext.MemberDefParamModels;
            var paramModels = doxyenContext.ParamModels;

            var argumentsModels = memberDefParamModels.GroupJoin(
                paramModels,
                memberDefParamModel => memberDefParamModel.ParamId,
                paramModel => paramModel.RowId,
                (memberDefParamModel, paramModel) => new
                {
                    memberDefParamModel.RowId,
                    memberDefParamModel.MemberDefId,
                    paramModel
                })
                .SelectMany(
                    memberDefParamModel => memberDefParamModel.paramModel,
                    (memberDefParamModel, paramModelItem) => new
                    {
                        memberDefParamModel.RowId,
                        memberDefParamModel.MemberDefId,
                        ParamId = paramModelItem.RowId,
                        paramModelItem.Type,
                        Name = paramModelItem.DeclName,
                        DefaultName = paramModelItem.DefName,
                        Array = paramModelItem.Array,
                        DefaultValue = paramModelItem.DefVal,
                        paramModelItem.BriefDescription
                    }
                )
                .Where(_ => _.MemberDefId.Equals(callerFuncId));

            return argumentsModels;
        }

        protected virtual IEnumerable<ParamDtoBase> ConvertToDto(dynamic argumentsModels)
        {
            var arguments = new List<ParamDto>();
            foreach (var item in argumentsModels)
            {
                var dto = new ParamDto()
                {
                    Id = item.RowId,
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

        public override IEnumerable<ParamDtoBase> GetById(int callerFuncId, DbContext context)
        {
            IQueryable<dynamic> argumentsModel = GetArguments(callerFuncId, context);
            IEnumerable<ParamDtoBase> arguments = ConvertToDto(argumentsModel);

            return arguments;
        }
    }
}
