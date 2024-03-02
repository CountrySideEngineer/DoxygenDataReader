using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doxygen.DTO
{
    public class FileDto : ParamDtoBase
    {
#nullable enable
        /// <summary>
        /// Default constructor.
        /// </summary>
        public FileDto() { }

        /// <summary>
        /// File full path.
        /// </summary>
        public string Path { get; set; } = string.Empty;

        /// <summary>
        /// Collection of function information implemented in the file, as FunctionDto object.
        /// </summary>
        public IEnumerable<FunctionDto>? Functions { get; set; } = null;
    }
}
