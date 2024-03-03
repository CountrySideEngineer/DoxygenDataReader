using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doxygen.DTO
{
    public class ParamDto : ParamDtoBase
    {
#nullable enable
        /// <summary>
        /// Default constructor.
        /// </summary>
        public ParamDto() : base() { }

        /// <summary>
        /// Parameter array declare.
        /// </summary>
        public string? Array { get; set; }

        /// <summary>
        /// Scope of parameter.
        /// </summary>
        public string? Scope { get; set; }
    }
}
