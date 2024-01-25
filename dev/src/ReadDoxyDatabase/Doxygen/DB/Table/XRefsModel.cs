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
        [Key]
        [Column("rowid")]
        public int RowId { get; set; }

        [Column("src_rowid")]
        public int SrcRowId { get; set; }

        [Column("dst_rowid")]
        public int DstRowId { get; set; }

        [Column("context")]
        public string Context { get; set; } = string.Empty;
    }
}
