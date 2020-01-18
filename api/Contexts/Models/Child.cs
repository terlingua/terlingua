using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Contexts.Models
{
    [Table("CHILD", Schema = "TERLINGUA")]
    public partial class Child
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("CHILD_ID")]
        public int ChildId { get; set; }
        [Column("PARENT")]
        public int Parent { get; set; }
        [Column("NOTE")]
        public string Note { get; set; }
        [Column("CREATED_BY")]
        public int CreatedBy { get; set; }
        [Column("CREATED_DATE")]
        public DateTime CreatedDate { get; set; }
        [Required]
        [Column("ROW_VERSION")]
        public byte[] RowVersion { get; set; }

        [ForeignKey(nameof(CreatedBy))]
        [InverseProperty(nameof(Person.Child))]
        public virtual Person CreatedByNavigation { get; set; }
        [ForeignKey(nameof(Parent))]
        [InverseProperty(nameof(Item.Child))]
        public virtual Item ParentNavigation { get; set; }
    }
}
