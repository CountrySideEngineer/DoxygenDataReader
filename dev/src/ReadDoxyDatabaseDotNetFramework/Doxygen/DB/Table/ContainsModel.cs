using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doxygen.DB.Table
{
    [Table("contains")]
    public class ContainsModel
    {
#nullable enable
        [Key]
        [Column("rowid")]
        public int RowId { get; set; }

        [Required]
        [Column("inner_rowid")]
        public int InnerRowId { get; set; }

        [Required]
        [Column("outer_rowid")]
        public int OuterRowId { get; set; }

        [ForeignKey(nameof(InnerRowId))]
        public CompoundDefModel? CompoundDefInner { get; set; }

        [ForeignKey(nameof(OuterRowId))]
        public CompoundDefModel? CompoundDefOuter { get; set; }
    }
}
