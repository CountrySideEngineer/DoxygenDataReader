using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using Doxygen.DTO;

namespace Doxygen.DAO
{
    public class ArgumentDao : ParamDao
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public ArgumentDao() : base() { }

        /// <summary>
        /// This method is not supported in this DAO.
        /// </summary>
        /// <returns>NONE</returns>
        /// <exception cref="NotSupportedException"></exception>
        public override IEnumerable<ParamDtoBase> GetAll()
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// This method is not supported in this DAO.
        /// </summary>
        /// <returns>NONE</returns>
        /// <exception cref="NotSupportedException"></exception>
        public override IEnumerable<ParamDtoBase> GetAll(DbContext context)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Returns collection of arguments specified by id.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public override IEnumerable<ParamDtoBase> GetById(int id, DbContext context)
        {
            IEnumerable<ParamDtoBase> parameters = base.GetAll();
            IEnumerable<ParamDtoBase> arguments = parameters.Where(_ => _.Id.Equals(id));

            return arguments;
        }
    }
}
