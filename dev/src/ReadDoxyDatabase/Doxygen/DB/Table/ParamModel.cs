using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Doxygen.DB.Table
{
    [Table("param")]
    public class ParamModel
    {
        [Key]
        [Column("rowid")]
        public int RowId { get; set; }

        [Column("attributes")]
        public string Attributes { get; set; } = string.Empty;

        [Column("type")]
        public string Type { get; set; } = string.Empty;

        [Column("declname")]
        public string DeclName { get; set; } = string.Empty;

        [Column("defname")]
        public string DefName { get; set; } = string.Empty;

        [Column("array")]
        public string Array { get; set; } = string.Empty;

        [Column("defval")]
        public string DefVal { get; set; } = string.Empty;

        [Column("briefdescription")]
        public string BriefDescription { get; set; } = string.Empty;
    }
}
