using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doxygen.DAO
{
    public class CppSourceFileDao : AFileDao
    {
        protected override string GetFileExtension()
        {
            return "cpp";
        }
    }
}
