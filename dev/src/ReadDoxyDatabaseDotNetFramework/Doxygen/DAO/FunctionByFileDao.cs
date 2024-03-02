using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using Doxygen.DTO;

namespace Doxygen.DAO
{
    public class FunctionByFileDao : FunctionDao
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public FunctionByFileDao() : base() { }

        /// <summary>
        /// Get functions specified by an id the functions are implemeted in.\
        /// </summary>
        /// <param name="fileId">Id of file the functions are implemented.</param>
        /// <param name="context">Data base context.</param>
        /// <returns>Collection of functions implemented source code file specified by argument fileId.</returns>
        public override IEnumerable<ParamDtoBase> GetById(int fileId, DbContext context)
        {
            IEnumerable<dynamic> allFunctions = GetFunction(context);
            IEnumerable<dynamic> specifiedFunctions = allFunctions.Where(_ => _.BodyFileId.Equals(fileId));
            IEnumerable<ParamDtoBase> dtos = ConvertToDto(specifiedFunctions);

            SetupParameters(ref dtos, context);

            return dtos;
        }
    }
}
