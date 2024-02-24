using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doxygen.DTO
{
    public class VariableDto : ParamDto
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public VariableDto() : base() { }

        /// <summary>
        /// Global variable definition.
        /// </summary>
        public string Definition { get; set; } = string.Empty;

        /// <summary>
        /// Codes to initialize the variable.
        /// </summary>
        public string? Initialize { get; set; }
    }
}
