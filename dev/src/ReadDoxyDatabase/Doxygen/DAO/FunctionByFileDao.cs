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
    public class FunctionByFileDao : FunctionDao
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public FunctionByFileDao() : base() { }

        protected virtual IEnumerable<dynamic> GetFunction(int fileId, DbContext context)
        {
            IEnumerable<dynamic> functions = base.GetFunction(context).Where(_ => _.BodyFileId.Equals(fileId));

            return functions;
        }

        public override IEnumerable<ParamDtoBase> GetById(int fileId, DbContext context)
        {
            IEnumerable<dynamic> functions = GetFunction(fileId, context);
            IEnumerable<ParamDtoBase> dtos = ConvertToDto(functions);

            SetupParameters(ref dtos, context);

            return dtos;
        }
    }
}
