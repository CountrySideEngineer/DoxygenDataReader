using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doxygen.DTO
{
    public class ParamDto : ParamDtoBase
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public ParamDto() : base() { }

        /// <summary>
        /// Parameter array devlare.
        /// </summary>
        public string? Array { get; set; }
    }
}
