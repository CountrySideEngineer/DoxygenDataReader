using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doxygen.DTO
{
    public class ParamDtoBase
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public ParamDtoBase() { }

        /// <summary>
        /// ID of the parameter.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Attribute of the parameter
        /// </summary>
        public string? Attribute { get; set; }

        /// <summary>
        /// Name of parameter
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Data type of parameter.
        /// </summary>
        public string? Type { get; set; }

        /// <summary>
        /// Default name of parameter.
        /// </summary>
        public string? DefaultName { get; set; }

        /// <summary>
        /// The parameter is array.
        /// </summary>
        public int? IsArray { get; set; }

        /// <summary>
        /// Default value of the parameter.
        /// </summary>
        public string? DefaultValue { get; set; }

        /// <summary>
        /// Brief description of the parameter.
        /// </summary>
        public string? BriefDescription { get; set; }
    }
}
