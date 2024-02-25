using Doxygen.DB;
using Doxygen.DB.Table;
using Doxygen.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace Doxygen.DAO
{
    public class FunctionDao : ADao
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public FunctionDao() { }

        /// <summary>
        /// Returns collection of function read from data base.
        /// </summary>
        /// <param name="context">Data base conext.</param>
        /// <returns>Collection of function read from data base.</returns>
        protected virtual IEnumerable<dynamic> GetFunction(DbContext context)
        {
            DoxygenDbContext doxygenContext = (DoxygenDbContext)context;
            var memberDefModels = doxygenContext.MemberDefModels
                .Where(
                    _ => _.Kind.ToLower().Equals("function"))
                .ToList();

            return memberDefModels;
        }

        /// <summary>
        /// Convert collection of function read from data base into that of FunctionDto, inherits ParamDtoBase class.
        /// </summary>
        /// <param name="functions">Collection of function read from data base.</param>
        /// <returns>Collection of ParamDtoBase object which contains function information.</returns>
        protected virtual IEnumerable<ParamDtoBase> ConvertToDto(IEnumerable<dynamic> functions)
        {
            var dtos = new List<FunctionDto>();
            foreach (var item in functions)
            {
                var dto = new FunctionDto()
                {
                    Id = item.RowId,
                    Name = item.Name,
                    Type = item.Type,
                    Definition = item.Definition,
                };
                dtos.Add(dto);
            }

            return dtos;
        }

        /// <summary>
        /// Returns collection of arguments of a function specified by id.
        /// </summary>
        /// <param name="memberDefId">Function id</param>
        /// <param name="context">Data base context.</param>
        /// <returns>Collection of argument datas in ParamDto pbject.</returns>
        internal virtual IEnumerable<ParamDto> GetArgumentsByIdOfFunc(int memberDefId, DoxygenDbContext context)
        {
            var dao = new ArgumentByFuncDao();
            var arguemnts = (IEnumerable<ParamDto>)dao.GetById(memberDefId, context);

            return arguemnts;
        }

        /// <summary>
        /// Returns collection of global variable a function refers.
        /// </summary>
        /// <param name="referId">Function id</param>
        /// <param name="context">Data base context.</param>
        /// <returns>Collection of global varialbe the function refers.</returns>
        internal virtual IEnumerable<ParamDto> GetGlobalVariablesByIdOfFunc(int referId, DoxygenDbContext context)
        {
            var dao = new GlobalVarialbeByFunctionDao();
            var variables = (IEnumerable<ParamDto>)dao.GetById(referId);

            return variables;
        }

        /// <summary>
        /// Returns collection of sub functions 
        /// </summary>
        /// <param name="callerId">Caller function id.</param>
        /// <param name="context">Data base context.</param>
        /// <returns>Collection of function in FunctionDto object.</returns>
        internal virtual IEnumerable<ParamDtoBase> GetSubFunctionsById(int callerId, DoxygenDbContext context)
        {
            var dao = new FunctionCalledByDao();
            var functions = dao.GetById(callerId, context);

            return functions;
        }

        /// <summary>
        /// Returns arguments, subfunctions, and global variables a function specified by an id refers.
        /// </summary>
        /// <param name="referId">Function id</param>
        /// <param name="context">Data base context.</param>
        /// <returns>Arguments, sub functions, and global varialbe information in tuple.</returns>
        protected virtual
            (IEnumerable<ParamDtoBase> arguments, 
            IEnumerable<ParamDtoBase> subFunctions, 
            IEnumerable<ParamDtoBase> globalVariables) 
            GetParameters(int referId, DoxygenDbContext context)
        {
            var arguments = GetArgumentsByIdOfFunc(referId, context);
            var subFunctions = GetSubFunctionsById(referId, context);
            var globalVariables = GetGlobalVariablesByIdOfFunc(referId, context);

            return (arguments, subFunctions, globalVariables);
        }

        /// <summary>
        /// Setup parameters to a functin in the collection.
        /// </summary>
        /// <param name="dtos">Collection of function information in ParamDtoBase object.</param>
        /// <param name="context">Data base context.</param
        protected virtual void SetupParameters(ref IEnumerable<ParamDtoBase> dtos, DbContext context)
        {
            var doxygenContext = (DoxygenDbContext)context;

            foreach (var item in dtos)
            {
                (IEnumerable<ParamDtoBase> arguments,
                IEnumerable<ParamDtoBase> subFunctions,
                IEnumerable<ParamDtoBase> globalVariables) = GetParameters(item.Id, doxygenContext);

                ((FunctionDto)item).Arguments = arguments;
                ((FunctionDto)item).SubFunctions = (IEnumerable<FunctionDto>)subFunctions;
                ((FunctionDto)item).GlobalVariables = globalVariables;
            }
        }

        /// <summary>
        /// Returns all function registered in data base.
        /// </summary>
        /// <returns>Collection of function data in FunctinoDto object.</returns>
        public override IEnumerable<ParamDtoBase> GetAll(DbContext context)
        {
            IEnumerable<dynamic> functions = GetFunction(context);
            IEnumerable<ParamDtoBase> dtos = ConvertToDto(functions);

            SetupParameters(ref dtos, context);

            return dtos;
        }
    }
}
