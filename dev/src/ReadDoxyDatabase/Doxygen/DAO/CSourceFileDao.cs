using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doxygen.DAO
{
    public class CSourceFileDao : AFileDao
    {
        /// <summary>
        /// Returns supporting file type specified by that of extension.
        /// </summary>
        /// <returns>Supporting file extension.</returns>
        protected override string GetFileExtension()
        {
            return "c";
        }
    }
}
