using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doxygen.DB.Table
{
    [Table("meta")]
    public class MetaModel
    {
#nullable enable
        [Key]
        [Column("doxygen_version")]
        public string DoxygenVersion { get; set; } = string.Empty;

        [Required]
        [Column("schema_version")]
        public string SchemaVersion { get; set; } = string.Empty;

        [Required]
        [Column("generated_at")]
        public string GeneratedAt { get; set; } = string.Empty;

        [Required]
        [Column("generated_on")]
        public string GeneratedOn { get; set; } = string.Empty;

        [Required]
        [Column("project_on")]
        public string ProjectName { get; set; } = string.Empty;

        [Column("project_number")]
        public string? ProjectNumber { get; set; } = string.Empty;

        [Column("project brief")]
        public string? ProjectBrief { get; set; } = string.Empty;
    }
}
