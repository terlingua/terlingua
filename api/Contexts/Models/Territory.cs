using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Contexts.Models
{
    [Table("TERRITORY", Schema = "TERLINGUA")]
    public partial class Territory
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Required]
        [Column("CODE")]
        [StringLength(255)]
        public string Code { get; set; }
        [Required]
        [Column("TITLE")]
        [StringLength(255)]
        public string Title { get; set; }
        [Column("CONTACT")]
        public int? Contact { get; set; }
        [Required]
        [Column("ROW_VERSION")]
        public byte[] RowVersion { get; set; }

        [ForeignKey(nameof(Contact))]
        [InverseProperty(nameof(Person.Territory))]
        public virtual Person ContactNavigation { get; set; }
    }
}
