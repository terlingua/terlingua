using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Contexts.Models
{
    [Table("PERSON", Schema = "TERLINGUA")]
    public partial class Person
    {
        public Person()
        {
            Child = new HashSet<Child>();
            ItemAccessPlannerNavigation = new HashSet<Item>();
            ItemCreatedByNavigation = new HashSet<Item>();
            ItemProjectManagerNavigation = new HashSet<Item>();
            ItemSwitchedPlannerNavigation = new HashSet<Item>();
            ItemSwitchedProjectManagerNavigation = new HashSet<Item>();
            Territory = new HashSet<Territory>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Required]
        [Column("CORPORATE_IDENTIFIER")]
        [StringLength(255)]
        public string CorporateIdentifier { get; set; }
        [Required]
        [Column("ROW_VERSION")]
        public byte[] RowVersion { get; set; }

        [InverseProperty("CreatedByNavigation")]
        public virtual ICollection<Child> Child { get; set; }
        [InverseProperty(nameof(Item.AccessPlannerNavigation))]
        public virtual ICollection<Item> ItemAccessPlannerNavigation { get; set; }
        [InverseProperty(nameof(Item.CreatedByNavigation))]
        public virtual ICollection<Item> ItemCreatedByNavigation { get; set; }
        [InverseProperty(nameof(Item.ProjectManagerNavigation))]
        public virtual ICollection<Item> ItemProjectManagerNavigation { get; set; }
        [InverseProperty(nameof(Item.SwitchedPlannerNavigation))]
        public virtual ICollection<Item> ItemSwitchedPlannerNavigation { get; set; }
        [InverseProperty(nameof(Item.SwitchedProjectManagerNavigation))]
        public virtual ICollection<Item> ItemSwitchedProjectManagerNavigation { get; set; }
        [InverseProperty("ContactNavigation")]
        public virtual ICollection<Territory> Territory { get; set; }
    }
}
