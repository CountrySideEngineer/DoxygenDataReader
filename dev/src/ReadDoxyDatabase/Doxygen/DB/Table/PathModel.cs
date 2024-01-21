using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doxygen.DB.Table
{
    [Table("path")]
    public class PathModel
    {
        [Key]
        [Column("rowid")]
        public int RowId { get; set; }

        [Column("type")]
        public int Type { get; set; }

        [Column("local")]
        public int Local { get; set; }

        [Column("found")]
        public int Found { get; set; }

        [Column("name")]
        public string Name { get; set; } = string.Empty;

    }
}
