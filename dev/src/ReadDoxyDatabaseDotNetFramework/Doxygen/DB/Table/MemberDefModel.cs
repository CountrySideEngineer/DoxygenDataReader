using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Doxygen.DB.Table
{
    [Table("memberdef")]
    public class MemberDefModel
    {
#nullable enable
        [Key]
        [Column("rowid")]
        public int RowId { get; set; }

        [Required]
        [Column("name")]
        public string Name { get; set; } = string.Empty;

        [Column("definition")]
        public string? Definition { get; set; } = string.Empty;

        [Column("type")]
        public string? Type { get; set; } = string.Empty;

        [Column("argsstring")]
        public string? ArgsString { get; set; } = string.Empty;

        [Column("scope")]
        public string? Scope { get; set; } = string.Empty;

        [Column("initializer")]
        public string? Initializer { get; set; } = string.Empty;

        [Column("bitfield")]
        public string? BitField { get; set; } = string.Empty;

        [Column("read")]
        public string? Read { get; set; } = string.Empty;

        [Column("write")]
        public string? Write { get; set; } = string.Empty;

        [Column("prot")]
        public int? Prot { get; set; } = 0;

        [Column("static")]
        public int? Static { get; set; } = 0;

        [Column("extern")]
        public int? Extern { get; set; } = 0;

        [Column("const")]
        public int? Const { get; set; } = 0;

        [Column("explicit")]
        public int? Explicit { get; set; } = 0;

        [Column("inline")]
        public int? Inline { get; set; } = 0;

        [Column("final")]
        public int? Final { get; set; } = 0;

        [Column("sealed")]
        public int? Sealed { get; set; } = 0;

        [Column("new")]
        public int? New { get; set; } = 0;

        [Column("optional")]
        public int? Optional { get; set; } = 0;

        [Column("required")]
        public int? Required { get; set; } = 0;

        [Column("volatile")]
        public int? Volatile { get; set; } = 0;

        [Column("virt")]
        public int? Virt { get; set; } = 0;

        [Column("mutable")]
        public int? Mutable { get; set; } = 0;

        [Column("initonly")]
        public int? InitOnly { get; set; } = 0;

        [Column("attribute")]
        public int? Attribute { get; set; } = 0;

        [Column("property")]
        public int? Property { get; set; } = 0;

        [Column("readonly")]
        public int? ReadOnly { get; set; } = 0;

        [Column("bound")]
        public int? Bound { get; set; } = 0;

        [Column("constrained")]
        public int? Constrained { get; set;} = 0;

        [Column("Transient")]
        public int? Transient { get; set; } = 0;

        [Column("maybevoid")]
        public int? MaybeVoid { get; set; } = 0;

        [Column("maybedefault")]
        public int? MaybeDefault { get; set; } = 0;

        [Column("maybeambiguous")]
        public int? MaybeAmbiguous { get; set; } = 0;

        [Column("readable")]
        public int? Readable { get; set; } = 0;

        [Column("Writable")]
        public int? Writable { get; set;} = 0;

        [Column("gettable")]
        public int? Gettable { get; set; } = 0;

        [Column("privategettable")]
        public int? PrivateGettable { get; set; } = 0;

        [Column("protectedgettable")]
        public int? ProtectedGettable { get; set; } = 0;

        [Column("settable")]
        public int? Settable { get; set; } = 0;

        [Column("privatesettable")]
        public int? PrivateSettable { get; set;} = 0;

        [Column("protectedsettable")]
        public int? ProtectedSettable { get; set;} = 0;

        [Column("accessor")]
        public int? Accessor { get; set; } = 0;

        [Column("addable")]
        public int? Addable { get; set;} = 0;

        [Column("removable")]
        public int? Removable { get; set; } = 0;

        [Column("raisable")]
        public int? Raisable { get; set; } = 0;

        [Required]
        [Column("kind")]
        public string Kind { get; set; } = string.Empty;

        [Column("bodystart")]
        public int? BodyStart { get; set; } = 0;

        [Column("bodyend")]
        public int? BodyEnd { get; set; } = 0;

        [Column("bodyfile_id")]
        public int? BodyFileId { get; set; } = 0;

        [Required]
        [Column("file_id")]
        public int FileId { get; set; } = 0;

        [Required]
        [Column("line")]
        public int Line { get; set; } = 0;

        [Required]
        [Column("column")]
        public int Column { get; set; } = 0;

        [Column("detaileddescription")]
        public string? DetailedDescription { get; set; } = string.Empty;

        [Column("briefdescription")]
        public string? BriefDescription { get; set;} = string.Empty;

        [Column("inbodydescription")]
        public string? InbodyDescription { get; set;} = string.Empty;

        [ForeignKey(nameof(BodyFileId))]
        public PathModel? PathModelBodyFileId { get; set; } = null;

        [ForeignKey(nameof(FileId))]
        public PathModel? PathModelFileId { get; set; } = null;
    }
}
