using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
namespace plants.Models;

//DB context class
public partial class PlantContext : DbContext
{
    public PlantContext()
    {
    }
    public PlantContext(DbContextOptions<PlantContext> options)
        : base(options)
    {
    }
    public virtual DbSet<PlantDb> PlanteDbs { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Plante;Trusted_Connection=True;");
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PlantDb>(entity =>
        {
            entity.ToTable("PlanteDB");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.References)
                .IsUnicode(false)
                .HasColumnName("references");
            entity.Property(e => e.ScientificName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("scientificName");
            entity.Property(e => e.TherapeuticEffects)
                .IsUnicode(false)
                .HasColumnName("therapeuticEffects");
        });

        OnModelCreatingPartial(modelBuilder);
    }
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
