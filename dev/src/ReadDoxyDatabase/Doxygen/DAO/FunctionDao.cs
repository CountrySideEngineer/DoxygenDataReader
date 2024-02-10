﻿using Doxygen.DB;
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

        /// <summary>
        /// Returns collection of arguments of a function specified by id.
        /// </summary>
        /// <param name="memberDefId">Function id</param>
        /// <param name="context">Data base context.</param>
        /// <returns>Collection of argument datas in ParamDto pbject.</returns>
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

        /// <summary>
        /// Returns collection of sub functions 
        /// </summary>
        /// <param name="callerId">Caller function id.</param>
        /// <param name="context">Data base context.</param>
        /// <returns>Collection of function in FunctionDto object.</returns>
        protected IEnumerable<FunctionDto> GetSubFunctionsById(int callerId, DoxygenDbContext context)
        {
            var xRefsModels = context.XRefsModels;
            var memberDefModels = context.MemberDefModels;
            var refIdModels = context.RefIdModels;

            var subFunctions = xRefsModels.GroupJoin(
                memberDefModels,
                xRefsModel => xRefsModel.SrcRowId,
                memberDefModel => memberDefModel.RowId,
                (xRefsModel, memberDefModelCollection) => new
                {
                    xRefsModel.RowId,
                    xRefsModel.SrcRowId,
                    xRefsModel.DstRowId,
                    MemerDefModel = memberDefModelCollection
                })
                .SelectMany(
                refModel => refModel.MemerDefModel,
                (refModel, memberDefModel) => new
                {
                    Id = refModel.RowId,
                    refModel.SrcRowId,
                    refModel.DstRowId,
                    memberDefModel.Type,
                    memberDefModel.Name,
                    memberDefModel.Definition,
                    memberDefModel.ArgsString,
                    memberDefModel.Scope,
                    memberDefModel.Kind,
                    memberDefModel.FileId,
                    memberDefModel.BodyFileId
                })
                .Where(_ => _.SrcRowId.Equals(callerId) && (_.FileId.Equals(_.BodyFileId)))
                .ToList();

            var dtos = new List<FunctionDto>();
            foreach (var item in subFunctions)
            {
                var arguments = GetArgumentsByIdOfFunc(item.DstRowId, context);
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

        /// <summary>
        /// Returns all function registered in data base.
        /// </summary>
        /// <returns>Collection of function data in FunctinoDto object.</returns>
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
                    var subFunctions = GetSubFunctionsById(item.MemberId, context);

                    var dto = new FunctionDto()
                    {
                        Id = item.Id,
                        Name = item.Name,
                        Type = item.Type,
                        Definition = item.Definition,
                        Arguments = arguments,
                        SubFunctions = subFunctions
                    };
                    dtos.Add(dto);
                }

                return dtos;
            }
        }
    }
}