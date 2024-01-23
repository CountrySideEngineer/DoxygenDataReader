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
        [Key]
        [Column("rowid")]
        public int Rowid { get; set; }

        [ForeignKey("rowid")]
        [Column("base_rowid")]
        public int BaseRowId { get; set; }

        [ForeignKey("rowid")]
        [Column("derived_rowid")]
        public int DerivedRowId { get; set; }

        [Column("prot")]
        public int Prot { get; set; }

        [Column("virt")]
        public int Virt { get; set; }

        public CompoundDefModel CompoundDef { get; set; }
    } 
}
