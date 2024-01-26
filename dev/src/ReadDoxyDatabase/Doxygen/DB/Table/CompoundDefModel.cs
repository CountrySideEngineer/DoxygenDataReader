using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doxygen.DB.Table
{
    [Table("compounddef")]
    public class CompoundDefModel
    {
        [Key]
        [Column("rowid")]
        public int RowId { get; set; }

        [Required]
        [Column("name")]
        public string Name { get; set; } = string.Empty;

        [Column("type")]
        public string Title { get; set; } = string.Empty;

        [Required]
        [Column("kind")]
        public string Kind { get; set; } = string.Empty;

        [Column("prot")]
        public int Prot { get; set; } = 0;

        [Required]
        [Column("field_id")]
        public int FiedId { get; set; } = 0;

        [Required]
        [Column("line")]
        public int Line { get; set; } = 0;

        [Required]
        [Column("column")]
        public int Column { get; set; } = 0;

        [Column("header_id")]
        public int HeaderId { get; set; } = 0;

        [Column("detaileddescription")]
        public string DetaildDescription { get; set; } = string.Empty;

        [Column("briefdescription")]
        public string BriefDescription { get; set; } = string.Empty;
    }
}
