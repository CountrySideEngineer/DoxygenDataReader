using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using Doxygen.DB;
using Doxygen.DTO;

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
        public abstract IEnumerable<ParamDtoBase> GetAll(DbContext context);

        /// <summary>
        /// Get all information specified by id from data base.
        /// </summary>
        /// <param name="id">id in int type to specify item in the data base.</param>
        /// <param name="context">Data base context.</param>
        /// <returns>Collection of object read from data base.</returns>
        public virtual IEnumerable<ParamDtoBase> GetById(int id, DbContext context)
        {
            IEnumerable<ParamDtoBase> objects = GetAll(context);
            IEnumerable<ParamDtoBase> objectsSpecById = objects.Where(_ => _.Id.Equals(id));

            return objectsSpecById;
        }

        /// <summary>
        /// Get All informatin from data base.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<ParamDtoBase> GetAll()
        {
            using (var context = new DoxygenDbContext())
            {
                IEnumerable<ParamDtoBase> objects = GetAll(context);

                return objects; ;
            }
        }

        /// <summary>
        /// Get all information specified by id from data base.
        /// </summary>
        /// <param name="id">id in int type to specify item in the data base.</param>
        /// <returns>Collection of object read from data base.</returns>
        public virtual IEnumerable<ParamDtoBase> GetById(int id)
        {
            using (var context = new DoxygenDbContext())
            {
                var objects = GetById(id, context);

                return objects; ;
            }
        }
    }
}
