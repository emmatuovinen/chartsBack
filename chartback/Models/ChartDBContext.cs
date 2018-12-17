using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace chartback.Models
{
    public partial class ChartDBContext : DbContext
    {
        public ChartDBContext()
        {
        }

        public ChartDBContext(DbContextOptions<ChartDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Chart> Chart { get; set; }
        public virtual DbSet<Content> Content { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=localhost;Database=ChartDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Chart>(entity =>
            {
                entity.Property(e => e.ChartId).HasColumnName("chart_id");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(100);

                entity.Property(e => e.Headline)
                    .IsRequired()
                    .HasColumnName("headline")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Content>(entity =>
            {
                entity.Property(e => e.ContentId).HasColumnName("content_id");

                entity.Property(e => e.ChartId).HasColumnName("chart_id");

                entity.Property(e => e.ValueX)
                    .IsRequired()
                    .HasColumnName("valueX")
                    .HasMaxLength(50);

                entity.Property(e => e.ValueY)
                    .IsRequired()
                    .HasColumnName("valueY")
                    .HasMaxLength(50);

                entity.Property(e => e.ValueZ)
                    .HasColumnName("valueZ")
                    .HasMaxLength(50);

                entity.HasOne(d => d.Chart)
                    .WithMany(p => p.Content)
                    .HasForeignKey(d => d.ChartId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Chart_Content");
            });
        }
    }
}
