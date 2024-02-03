using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doxygen.DTO
{
    public class FunctionDto : ParamDtoBase
    {
        /// <summary>
        /// Default Constructor.
        /// </summary>
        public FunctionDto() : base() { }

        /// <summary>
        /// Function definition in string.
        /// </summary>
        public string? Definition { get; set; } = string.Empty;

        public IEnumerable<ParamDtoBase>? Arguments { get; set; } 
    }
}
