using Doxygen.DB;
using Doxygen.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace Doxygen.DAO
{
    public class FunctionCalledByDao : FunctionDao
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public FunctionCalledByDao() : base() { }

        /// <summary>
        /// Get all method.
        /// This method is not supported in this DAO.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotSupportedException"></exception>
        public override IEnumerable<ParamDtoBase> GetAll()
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Get all method.
        /// This method is not supported in this DAO.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        /// <exception cref="NotSupportedException"></exception>
        public override IEnumerable<ParamDtoBase> GetAll(DbContext context)
        {
            throw new NotSupportedException();
        }

        public override IEnumerable<ParamDtoBase> GetById(int callerId, DbContext context)
        {
            IEnumerable<dynamic> functions = GetFunction(callerId, context);
            IEnumerable<ParamDtoBase> dtos = ConvertToDto(functions);

            SetupParameters(ref dtos, context);

            return dtos;
        }

        protected virtual IEnumerable<dynamic> GetFunction(int callerId, DbContext context)
        {
            var doxygenDbContext = (DoxygenDbContext)context;
            var xRefsModels = doxygenDbContext.XRefsModels;
            var memberDefModels = doxygenDbContext.MemberDefModels;

            var functions = xRefsModels.GroupJoin(
                memberDefModels,
                xRefModel => xRefModel.DstRowId,
                memberDefModel => memberDefModel.RowId,
                (xRefModel, memberDefModelCollection) => new
                {
                    xRefModel,
                    MemberDefModels = memberDefModelCollection
                })
                .SelectMany(
                xRefModel => xRefModel.MemberDefModels,
                (inputModel, memberDefModel) => new
                {
                    inputModel.xRefModel.RowId,
                    inputModel.xRefModel.SrcRowId,
                    inputModel.xRefModel.DstRowId,
                    memberDefModel.Type,
                    memberDefModel.Name,
                    memberDefModel.Definition,
                    memberDefModel.ArgsString,
                    memberDefModel.Scope,
                    memberDefModel.Kind,
                    memberDefModel.FileId,
                    memberDefModel.BodyFileId
                })
                .Where(_ =>
                    _.SrcRowId.Equals(callerId) &&
                    (_.FileId.Equals(_.BodyFileId)) &&
                    (_.Kind.ToLower().Equals("function")))
                .ToList();

            return functions;
        }

        protected override void SetupParameters(ref IEnumerable<ParamDtoBase> dtos, DbContext context)
        {
            var doxygenContext = (DoxygenDbContext)context;

            foreach (var item in dtos)
            {
                IEnumerable<ParamDtoBase> arguments = GetArgumentsByIdOfFunc(item.Id, doxygenContext);
                ((FunctionDto)item).Arguments = arguments;
            }
        }
    }
}
