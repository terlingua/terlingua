using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Contexts.Models
{
    [Table("CATEGORY", Schema = "TERLINGUA")]
    public partial class Category
    {
        public Category()
        {
            Item = new HashSet<Item>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Required]
        [Column("TITLE")]
        [StringLength(255)]
        public string Title { get; set; }
        [Required]
        [Column("ROW_VERSION")]
        public byte[] RowVersion { get; set; }

        [InverseProperty("CategoryNavigation")]
        public virtual ICollection<Item> Item { get; set; }
    }
}
