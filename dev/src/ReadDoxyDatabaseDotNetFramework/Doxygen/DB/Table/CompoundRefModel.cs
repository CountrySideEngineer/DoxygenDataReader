using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Doxygen.DB.Table
{
    [Table("compoundref")]
    public class CompoundRefModel
    {
#nullable enable
        [Key]
        [Column("rowid")]
        public int Rowid { get; set; }

        [Required]
        [Column("base_rowid")]
        public int BaseRowId { get; set; }

        [Required]
        [Column("derived_rowid")]
        public int DerivedRowId { get; set; }

        [Required]
        [Column("prot")]
        public int Prot { get; set; }

        [Required]
        [Column("virt")]
        public int Virt { get; set; }

        [ForeignKey(nameof(BaseRowId))]
        public CompoundDefModel? CompoundDefModelBase { get; set; } = null;

        [ForeignKey(nameof(DerivedRowId))]
        public CompoundDefModel? CompoundDefModelDerived { get; set; } = null;
    }
}
