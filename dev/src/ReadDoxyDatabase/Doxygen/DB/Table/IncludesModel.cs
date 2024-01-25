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
        [Key]
        [Column("rowid")]
        public int RowId { get; set; }

        [Column("local")]
        public int Local { get; set; }

        [Column("src_id")]
        public int SrcId { get; set; }

        [Column("dst_id")]
        public int DstId { get; set; }
    }
}
