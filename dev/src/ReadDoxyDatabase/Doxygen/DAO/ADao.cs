using Doxygen.DB;
using Doxygen.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doxygen.DAO
{
    public abstract class ADao
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public ADao() { }

        /// <summary>
        /// Get All informatin from data base.
        /// </summary>
        /// <param name="context">Data base context.</param>
        /// <returns>Collection of object read from data base.</returns>
        public abstract IEnumerable<ParamDtoBase> GetAll(DoxygenDbContext context);

        /// <summary>
        /// Get All informatin from data base.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<ParamDtoBase> GetAll()
        {
            using (var context = new DoxygenDbContext())
            {
                var objects = GetAll(context);

                return objects; ;
            }
        }
    }
}
