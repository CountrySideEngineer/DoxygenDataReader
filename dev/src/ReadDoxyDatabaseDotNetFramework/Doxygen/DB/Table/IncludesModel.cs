using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doxygen.DB.Table
{
    [Table("includes")]
    public class IncludesModel
    {
#nullable enable
        [Key]
        [Column("rowid")]
        public int RowId { get; set; }

        [Required]
        [Column("local")]
        public int Local { get; set; }

        [Required]
        [Column("src_id")]
        public int SrcId { get; set; }

        [Required]
        [Column("dst_id")]
        public int DstId { get; set; }

        [ForeignKey(nameof(SrcId))]
        public PathModel? PathModelSrc { get; set; }

        [ForeignKey(nameof(DstId))]
        public PathModel? PathModelDst { get; set; }
    }
}
