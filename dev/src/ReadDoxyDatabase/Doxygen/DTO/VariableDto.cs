﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doxygen.DTO
{
    public class VariableDto : ParamDtoBase
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public VariableDto() : base() { }

        /// <summary>
        /// Global variable definition.
        /// </summary>
        public string Definition { get; set; } = string.Empty;

        /// <summary>
        /// Scope of the varlable.
        /// </summary>
        public string? Scope { get; set; }

        /// <summary>
        /// String about variable definition as array.
        /// </summary>
        public string? ArrayString { get; set; }

        /// <summary>
        /// Codes to initialize the variable.
        /// </summary>
        public string? Initialize { get; set; }
    }
}