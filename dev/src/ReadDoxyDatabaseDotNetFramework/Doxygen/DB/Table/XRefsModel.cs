using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doxygen.DB.Table
{
    [Table("xrefs")]
    public class XRefsModel
    {
#nullable enable
        [Key]
        [Column("rowid")]
        public int RowId { get; set; }

        [Required]
        [Column("src_rowid")]
        public int SrcRowId { get; set; }

        [Required]
        [Column("dst_rowid")]
        public int DstRowId { get; set; }

        [Required]
        [Column("context")]
        public string Context { get; set; } = string.Empty;

        [ForeignKey(nameof(SrcRowId))]
        public RefIdModel? RefIdModelSrc { get; set; }

        [ForeignKey(nameof(DstRowId))]
        public RefIdModel? RefIdModelDst { get; set; }
    }
}
