using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doxygen.DTO
{
    public class FileDto
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public FileDto() { }

        /// <summary>
        /// ID in the table.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// File name.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// File full path.
        /// </summary>
        public string Path { get; set; } = string.Empty;
    }
}
