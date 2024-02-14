using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doxygen.DTO
{
    public class FunctionDto : ParamDto
    {
        /// <summary>
        /// Default Constructor.
        /// </summary>
        public FunctionDto() : base() { }

        /// <summary>
        /// Function definition in string.
        /// </summary>
        public string? Definition { get; set; } = string.Empty;

        /// <summary>
        /// Arguments in generics.
        /// </summary>
        public IEnumerable<ParamDtoBase>? Arguments { get; set; } 

        /// <summary>
        /// Sub functions in generics.
        /// </summary>
        public IEnumerable<FunctionDto>? SubFunctions { get; set; }

        /// <summary>
        /// Global variables the function, method refers.
        /// </summary>
        public IEnumerable<ParamDtoBase>? GlobalVariables { get; set; }
    }
}
