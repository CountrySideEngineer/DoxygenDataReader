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

        protected IEnumerable<FunctionDto> GetSubFunctionsById(int callerId, DoxygenDbContext context)
        {
            var xRefsModels = context.XRefsModels;
            var memberDefModels = context.MemberDefModels;
            var refIdModels = context.RefIdModels;

            var subFunctions = xRefsModels.Join(
                memberDefModels,
                xRefModel => xRefModel.SrcRowId,
                memberDefModel => memberDefModel.RowId,
                (xRef, memberDef) => new
                {
                    Id = xRef.RowId,
                    xRef.SrcRowId,
                    xRef.DstRowId,
                    memberDef.Type,
                    memberDef.Name,
                    memberDef.FileId,
                    memberDef.BodyFileId
                }
                )
                .Where(_ => _.FileId == _.BodyFileId);




            return null;
        }

        public IEnumerable<FunctionDto> GetAll()
        {
            using (var context = new DoxygenDbContext())
            {
                context.Database.EnsureCreated();

                var memberDefParamModels = context.MemberDefParamModels;
                var memberDefModels = context.MemberDefModels;

                var functions = memberDefParamModels.GroupJoin(
                    memberDefModels,
                    memberDefParamModel => memberDefParamModel.MemberDefId,
                    memberDefModel => memberDefModel.RowId,
                    (memberDefParamModel, memberDefModelCollection) => new
                    {
                        memberDefParamModel.RowId,
                        memberDefParamModel.MemberDefId,
                        memberDefParamModel.ParamId,
                        memeberDefs = memberDefModelCollection
                    })
                    .SelectMany(x => x.memeberDefs, (x, memberDefs) => new
                    {
                        Id = x.RowId,
                        MemberId = x.MemberDefId,
                        ParamId = x.ParamId,
                        Type = memberDefs.Type,
                        Name = memberDefs.Name,
                        DeclName = memberDefs.ArgsString,
                        Definition = memberDefs.Definition,
                        Kind = memberDefs.Kind
                    })
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

                    //    GetSubFunctionsById(dto.Id, context);

                    //}



                return dtos;
            }
        }
    }
}
