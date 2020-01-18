using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Contexts.Models
{
    [Table("ITEM", Schema = "TERLINGUA")]
    public partial class Item
    {
        public Item()
        {
            Child = new HashSet<Child>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("ITEM_ID")]
        public int ItemId { get; set; }
        [Required]
        [Column("PROJECT_ID")]
        [StringLength(255)]
        public string ProjectId { get; set; }
        [Column("PROJECT_MANAGER")]
        public int ProjectManager { get; set; }
        [Column("PROJECT_MANAGER_NOTE")]
        [StringLength(255)]
        public string ProjectManagerNote { get; set; }
        [Column("ACCESS_PLANNER")]
        public int AccessPlanner { get; set; }
        [Column("ACCESS_PLANNER_NOTE")]
        public string AccessPlannerNote { get; set; }
        [Column("SWITCHED_PROJECT_MANAGER")]
        public int SwitchedProjectManager { get; set; }
        [Required]
        [Column("SWITCHED_PROJECT_MANAGER_NOTE")]
        public string SwitchedProjectManagerNote { get; set; }
        [Column("SWITCHED_PLANNER")]
        public int SwitchedPlanner { get; set; }
        [Required]
        [Column("SWITCHED_PLANNER_NOTE")]
        public string SwitchedPlannerNote { get; set; }
        [Column("PARENT_PROJECT_ID")]
        [StringLength(255)]
        public string ParentProjectId { get; set; }
        [Column("CATEGORY")]
        public int Category { get; set; }
        [Column("MONTHLY_RECURRING_COST_SAVING", TypeName = "decimal(19, 4)")]
        public decimal? MonthlyRecurringCostSaving { get; set; }
        [Column("MONTHLY_RECURRING_REVENUE", TypeName = "decimal(19, 4)")]
        public decimal? MonthlyRecurringRevenue { get; set; }
        [Column("NOTE")]
        public string Note { get; set; }
        [Column("CREATED_BY")]
        public int CreatedBy { get; set; }
        [Column("CREATED_DATE")]
        public DateTime CreatedDate { get; set; }
        [Required]
        [Column("ROW_VERSION")]
        public byte[] RowVersion { get; set; }

        [ForeignKey(nameof(AccessPlanner))]
        [InverseProperty(nameof(Person.ItemAccessPlannerNavigation))]
        public virtual Person AccessPlannerNavigation { get; set; }
        [ForeignKey(nameof(Category))]
        [InverseProperty("Item")]
        public virtual Category CategoryNavigation { get; set; }
        [ForeignKey(nameof(CreatedBy))]
        [InverseProperty(nameof(Person.ItemCreatedByNavigation))]
        public virtual Person CreatedByNavigation { get; set; }
        [ForeignKey(nameof(ProjectManager))]
        [InverseProperty(nameof(Person.ItemProjectManagerNavigation))]
        public virtual Person ProjectManagerNavigation { get; set; }
        [ForeignKey(nameof(SwitchedPlanner))]
        [InverseProperty(nameof(Person.ItemSwitchedPlannerNavigation))]
        public virtual Person SwitchedPlannerNavigation { get; set; }
        [ForeignKey(nameof(SwitchedProjectManager))]
        [InverseProperty(nameof(Person.ItemSwitchedProjectManagerNavigation))]
        public virtual Person SwitchedProjectManagerNavigation { get; set; }
        [InverseProperty("ParentNavigation")]
        public virtual ICollection<Child> Child { get; set; }
    }
}
