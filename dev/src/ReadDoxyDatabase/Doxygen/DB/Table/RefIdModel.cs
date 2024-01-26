using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doxygen.DB.Table
{
    [Table("refid")]
    public class RefIdModel
    {
        [Key]
        [Column("rowid")]
        public int RowId { get; set; }

        [Required]
        [Column("refid")]
        public string RefId { get; set; } = string.Empty;
    }
}
