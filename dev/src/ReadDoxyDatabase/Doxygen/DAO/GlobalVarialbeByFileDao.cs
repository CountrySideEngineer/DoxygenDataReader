using Doxygen.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doxygen.DAO
{
    public class GlobalVarialbeByFileDao : GlobalVarialbeDao
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public GlobalVarialbeByFileDao() : base() { }

        /// <summary>
        /// Get global variable information refered from a file specified by id.
        /// </summary>
        /// <param name="id">File id.</param>
        /// <param name="context">Data base context.</param>
        /// <returns>Collection of global variable a file refers.</returns>
        public override IEnumerable<ParamDtoBase> GetById(int id, DbContext context)
        {
            IEnumerable<dynamic> globalVarialbles = GetGlobalVariable(context);
            IEnumerable<dynamic> specifiedGlobalVariables = globalVarialbles.Where(_ => _.FileId.Equals(id));
            IEnumerable<ParamDtoBase> dtos = ConvertToDto(specifiedGlobalVariables);

            return dtos;
        }
    }
}
