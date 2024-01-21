using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doxygen
{
    public class FileInfo
    {
        /// <summary>
        /// Id value in data base.
        /// </summary>
        public int Id { get; internal set; } = -1;

        /// <summary>
        /// Reference id vaule in data base.
        /// </summary>
        public string RefId { get; internal set; } = string.Empty;

        /// <summary>
        /// File name read.
        /// </summary>
        public string Name { get; internal set; } = string.Empty;

        /// <summary>
        /// File path.
        /// </summary>
        public string Path { get; internal set; } = string.Empty;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public FileInfo() { }
    }
}
