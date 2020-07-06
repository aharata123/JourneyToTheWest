using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace JourneyToTheWestAPI.Entities
{
    public partial class journeytothewestContext : DbContext
    {
        public journeytothewestContext()
        {
        }

        public journeytothewestContext(DbContextOptions<journeytothewestContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Actor> Actors { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<RolesInScenario> RolesInScenarios { get; set; }
        public virtual DbSet<Scenario> Scenarios { get; set; }
        public virtual DbSet<Tool> Tools { get; set; }
        public virtual DbSet<ToolsInScenario> ToolsInScenarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=JourneyToTheWest");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Actor>(entity =>
            {
                entity.HasKey(e => e.IdActor)
                    .HasName("PK_Cast");

                entity.ToTable("Actor");

                entity.HasIndex(e => e.Username)
                    .HasName("IX_Actor")
                    .IsUnique();

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Image)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.IdRole);

                entity.ToTable("Role");

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.RoleName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.IdActorNavigation)
                    .WithMany(p => p.Roles)
                    .HasForeignKey(d => d.IdActor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Role_Actor1");
            });

            modelBuilder.Entity<RolesInScenario>(entity =>
            {
                entity.HasKey(e => new { e.IdScenario, e.IdRole });

                entity.ToTable("RolesInScenario");

                entity.HasOne(d => d.ActorNavigation)
                    .WithMany(p => p.RolesInScenarios)
                    .HasForeignKey(d => d.Actor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RolesInScenario_Actor");

                entity.HasOne(d => d.IdRoleNavigation)
                    .WithMany(p => p.RolesInScenarios)
                    .HasForeignKey(d => d.IdRole)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RolesInScenario_Role");

                entity.HasOne(d => d.IdScenarioNavigation)
                    .WithMany(p => p.RolesInScenarios)
                    .HasForeignKey(d => d.IdScenario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RolesInScenario_Scenario");
            });

            modelBuilder.Entity<Scenario>(entity =>
            {
                entity.HasKey(e => e.IdScenario);

                entity.ToTable("Scenario");

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.Location)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.ScenarioName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.StartDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Tool>(entity =>
            {
                entity.HasKey(e => e.IdTool);

                entity.ToTable("Tool");

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.Image)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<ToolsInScenario>(entity =>
            {
                entity.HasKey(e => new { e.IdTool, e.IdScenario });

                entity.ToTable("ToolsInScenario");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.HasOne(d => d.IdScenarioNavigation)
                    .WithMany(p => p.ToolsInScenarios)
                    .HasForeignKey(d => d.IdScenario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ToolsInScenario_Scenario");

                entity.HasOne(d => d.IdToolNavigation)
                    .WithMany(p => p.ToolsInScenarios)
                    .HasForeignKey(d => d.IdTool)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ToolsInScenario_Tool");
            });
        }
    }
}
