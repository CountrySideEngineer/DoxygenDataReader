using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doxygen.DB.Table
{
    [Table("reimplements")]
    public class ReimplementsModel
    {
        [Key]
        [Column("rowid")]
        public int RowId { get; set; }

        [Required]
        [Column("memberdef_rowid")]
        public int MemberDefRowId { get; set; }

        [Required]
        [Column("reimplemented_rowid")]
        public int ReimplementedRowId { get; set; }
    }
}
