#if USING_DOT_NET
using System.Data.Entity;
#else
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
#endif
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
#nullable enable
        [Key]
        [Column("rowid")]
        public int RowId { get; set; }

        [Required]
        [Column("memberdef_id")]
        public int MemberDefId { get; set; }

        [Required]
        [Column("param_id")]
        public int ParamId { get; set; }

        [ForeignKey(nameof(MemberDefId))]
        public MemberDefModel? MemberDefModelId { get; set; } = null;

        [ForeignKey(nameof(ParamId))]
        public ParamModel? ParamModelId { get; set; } = null;
    }
}
