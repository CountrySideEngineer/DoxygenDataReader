using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doxygen.DB.Table
{
    [Table("memberdef_param")]
    public class MemberDefParamModel
    {
        [Key]
        [Column("rowid")]
        public int RowId { get; set; }

        [Required]
        [Column("memberdef_id")]
        public int MemberDefId { get; set; }

        [Required]
        [Column("param_id")]
        public int ParamId { get; set; }
    }
}
