using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doxygen.DB.Table
{
    [Table("member")]
    public class MemberModel
    {
        [Key]
        [Column("RowId")]
        public int RowId { get; set; }

        [Required]
        [Column("scope_rowid")]
        public int ScopeRowId { get; set; }

        [Required]
        [Column("memeberdef_rowdi")]
        public int MemberDefRowId { get; set; }

        [Required]
        [Column("prot")]
        public int Prot { get; set; }

        [Required]
        [Column("virt")]
        public int Virt { get; set; }
    }
}
