using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using API.Contexts.Models;

namespace API.Contexts
{
    public partial class TerlinguaContext : DbContext
    {
        public TerlinguaContext()
        {
        }

        public TerlinguaContext(DbContextOptions<TerlinguaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Child> Child { get; set; }
        public virtual DbSet<Item> Item { get; set; }
        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<Territory> Territory { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // optionsBuilder.UseSqlServer("Data Source=localhost;Database=Terlingua;Trusted_Connection=true;");
                optionsBuilder.UseSqlServer(ConnectionStrings.DefaultConnection);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasIndex(e => e.Title)
                    .HasName("UQ__CATEGORY__475DFD2FB06D734C")
                    .IsUnique();

                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();
            });

            modelBuilder.Entity<Child>(entity =>
            {
                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.Child)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.ParentNavigation)
                    .WithMany(p => p.Child)
                    .HasForeignKey(d => d.Parent)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CHILD_ITEM");
            });

            modelBuilder.Entity<Item>(entity =>
            {
                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.AccessPlannerNavigation)
                    .WithMany(p => p.ItemAccessPlannerNavigation)
                    .HasForeignKey(d => d.AccessPlanner)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ITEM_PERSON");

                entity.HasOne(d => d.CategoryNavigation)
                    .WithMany(p => p.Item)
                    .HasForeignKey(d => d.Category)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ITEM_CATEGORY");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.ItemCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.ProjectManagerNavigation)
                    .WithMany(p => p.ItemProjectManagerNavigation)
                    .HasForeignKey(d => d.ProjectManager)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.SwitchedPlannerNavigation)
                    .WithMany(p => p.ItemSwitchedPlannerNavigation)
                    .HasForeignKey(d => d.SwitchedPlanner)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.SwitchedProjectManagerNavigation)
                    .WithMany(p => p.ItemSwitchedProjectManagerNavigation)
                    .HasForeignKey(d => d.SwitchedProjectManager)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.HasIndex(e => e.CorporateIdentifier)
                    .HasName("UQ__PERSON__79784FA8648D8889")
                    .IsUnique();

                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();
            });

            modelBuilder.Entity<Territory>(entity =>
            {
                entity.HasIndex(e => e.Code)
                    .HasName("UQ__TERRITOR__AA1D4379FC86854B")
                    .IsUnique();

                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.ContactNavigation)
                    .WithMany(p => p.Territory)
                    .HasForeignKey(d => d.Contact)
                    .HasConstraintName("FK_TERRITORY_PERSON");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
