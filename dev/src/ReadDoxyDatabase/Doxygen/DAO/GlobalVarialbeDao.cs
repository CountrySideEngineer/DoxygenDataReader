using Doxygen.DB;
using Doxygen.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doxygen.DAO
{
    public class GlobalVarialbeDao : ADao
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public GlobalVarialbeDao() { }

        /// <summary>
        /// Get global variable informations from data base.
        /// </summary>
        /// <param name="dbContext">Data base context.</param>
        /// <returns>Collection of global varilable informations.</returns>
        protected virtual IEnumerable<dynamic> GetGlobalVariable(DbContext dbContext)
        {
            DoxygenDbContext doxygenContext = (DoxygenDbContext)dbContext;
            var memberDefModels = doxygenContext.MemberDefModels
                .Where(_ => _.Kind.Equals("variable") && _.Scope == null)
                .ToList();

            return memberDefModels;
        }

        /// <summary>
        /// Convert collection of global variable read from data base into VariableDto object, inherits ParamDtoBase class.
        /// </summary>
        /// <param name="globalVariables">Collection of global variable information.</param>
        /// <returns>Collection of VariableDto object contains </returns>
        protected virtual IEnumerable<ParamDtoBase> ConvertToDto(IEnumerable<dynamic> globalVariables)
        {
            var dtos = new List<ParamDtoBase>();
            foreach (var variable in globalVariables)
            {
                var dto = new VariableDto()
                {
                    Id = variable.RowId,
                    Name = variable.Name,
                    Type = variable.Type,
                    Definition = variable.Definition,
                    ArrayString = variable.ArgsString,
                    Initialize = variable.Initializer,
                };
                dtos.Add(dto);
            }
            return dtos;
        }

        /// <summary>
        /// Get all global variable information.
        /// </summary>
        /// <param name="context">Data base context.</param>
        /// <returns>Colleciotn of global variable information</returns>
        public override IEnumerable<ParamDtoBase> GetAll(DbContext context)
        {
            IEnumerable<dynamic> globalVarialbles = GetGlobalVariable(context);
            IEnumerable<ParamDtoBase> dtos = ConvertToDto(globalVarialbles);

            return dtos;
        }
    }
}
