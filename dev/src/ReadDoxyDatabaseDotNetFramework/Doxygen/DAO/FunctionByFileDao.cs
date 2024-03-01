﻿using Doxygen.DTO;
#if USING_DOT_NET
using System.Data.Entity;
#else
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
#endif
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doxygen.DAO
{
    public class FunctionByFileDao : FunctionDao
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public FunctionByFileDao() : base() { }

        /// <summary>
        /// Get functions specified by an id the functions are implemeted in.\
        /// </summary>
        /// <param name="fileId">Id of file the functions are implemented.</param>
        /// <param name="context">Data base context.</param>
        /// <returns>Collection of functions implemented source code file specified by argument fileId.</returns>
        public override IEnumerable<ParamDtoBase> GetById(int fileId, DbContext context)
        {
            IEnumerable<dynamic> allFunctions = GetFunction(context);
            IEnumerable<dynamic> specifiedFunctions = allFunctions.Where(_ => _.BodyFileId.Equals(fileId));
            IEnumerable<ParamDtoBase> dtos = ConvertToDto(specifiedFunctions);

            SetupParameters(ref dtos, context);

            return dtos;
        }
    }
}
