using Doxygen.DB;
using Doxygen.DTO;
#if USING_DOT_NET
using System.Data.Entity;
#else
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
#endif
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doxygen.DAO
{
    public class GlobalVarialbeByFunctionDao : GlobalVarialbeDao
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public GlobalVarialbeByFunctionDao() : base() { }

        /// <summary>
        /// This method is not supported in this class.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotSupportedException"></exception>
        public override IEnumerable<ParamDtoBase> GetAll()
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// This method is not supported in this class.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        /// <exception cref="NotSupportedException"></exception>
        public override IEnumerable<ParamDtoBase> GetAll(DbContext context)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Get global variables a function specified by id refers.
        /// </summary>
        /// <param name="funcId">Function id</param>
        /// <param name="context">Data base context.</param>
        /// <returns>Collection of </returns>
        protected virtual IEnumerable<dynamic> GetGlobalVariable(int funcId, DbContext context)
        {
            var doxygenDbContext = (DoxygenDbContext)context;
            var xRefsModels = doxygenDbContext.XRefsModels;
            var memberDefModels = doxygenDbContext.MemberDefModels;

            var globalVariables = xRefsModels.GroupJoin(
                memberDefModels,
                xRefModel => xRefModel.DstRowId,
                memberDefModel => memberDefModel.RowId,
                (xRefModel, memberDefModelCollection) => new
                {
                    xRefModel,
                    memberDefModelCollection
                })
                .SelectMany(
                xRefModel => xRefModel.memberDefModelCollection,
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
                    memberDefModel.Initializer,
                    memberDefModel.Kind,
                    memberDefModel.FileId,
                    memberDefModel.BodyFileId
                })
                .Where(_ => _.SrcRowId.Equals(funcId) &&
                    _.Kind.ToLower().Equals("variables"));

            return globalVariables;
        }

        /// <summary>
        /// Get collection of global variables a function specified by id refers.
        /// </summary>
        /// <param name="funcId">Function id.</param>
        /// <param name="context">Data base context.</param>
        /// <returns>Collection of global variables in ParamDtoBase object.</returns>
        public override IEnumerable<ParamDtoBase> GetById(int funcId, DbContext context)
        {
            IEnumerable<dynamic> globalVariables = GetGlobalVariable(funcId, context);
            IEnumerable<ParamDtoBase> dtos = ConvertToDto(globalVariables);

            return dtos;
        }
    }
}
