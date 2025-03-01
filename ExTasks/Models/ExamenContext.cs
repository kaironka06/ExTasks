using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ExTasks.Models;

public partial class ExamenContext : DbContext
{
    public ExamenContext()
    {
    }

    public ExamenContext(DbContextOptions<ExamenContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CCategorium> CCategoria { get; set; }

    public virtual DbSet<CPrioridad> CPrioridads { get; set; }

    public virtual DbSet<CTarea> CTareas { get; set; }

    public virtual DbSet<CUsuario> CUsuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CCategorium>(entity =>
        {
            entity.HasKey(e => e.NidCategoria);

            entity.ToTable("C_Categoria");

            entity.Property(e => e.NidCategoria)
                .ValueGeneratedNever()
                .HasColumnName("NIdCategoria");
            entity.Property(e => e.Bactivo).HasColumnName("BActivo");
            entity.Property(e => e.Vcategoria)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("VCategoria");
        });

        modelBuilder.Entity<CPrioridad>(entity =>
        {
            entity.HasKey(e => e.NidPrioridad);

            entity.ToTable("C_Prioridad");

            entity.Property(e => e.NidPrioridad)
                .ValueGeneratedNever()
                .HasColumnName("NIdPrioridad");
            entity.Property(e => e.Bactivo).HasColumnName("BActivo");
            entity.Property(e => e.Vprioridad)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("VPrioridad");
        });

        modelBuilder.Entity<CTarea>(entity =>
        {
            entity.HasKey(e => e.NidTarea);

            entity.ToTable("C_Tarea");

            entity.Property(e => e.NidTarea)
                .ValueGeneratedNever()
                .HasColumnName("NIdTarea").UseIdentityColumn();
            entity.Property(e => e.Bactivo).HasColumnName("BActivo");
            entity.Property(e => e.NidCategoria).HasColumnName("NIdCategoria");
            entity.Property(e => e.NidPrioridad).HasColumnName("NIdPrioridad");
            entity.Property(e => e.Vtarea)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("VTarea");

            entity.HasOne(d => d.ocategoria).WithMany(p => p.CTareas)
                .HasForeignKey(d => d.NidCategoria)
                .HasConstraintName("FK_C_Tarea_C_Categoria");

            entity.HasOne(d => d.oprioridad).WithMany(p => p.CTareas)
                .HasForeignKey(d => d.NidPrioridad)
                .HasConstraintName("FK_C_Tarea_C_Prioridad");
        });

        modelBuilder.Entity<CUsuario>(entity =>
        {
            entity.HasKey(e => e.VidUsuario);

            entity.ToTable("C_Usuarios");

            entity.Property(e => e.VidUsuario)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("VIdUsuario");
            entity.Property(e => e.VapPaterno)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("VApPaterno");
            entity.Property(e => e.Vapmaterno)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("VAPMaterno");
            entity.Property(e => e.Vnombre)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("VNombre");
            entity.Property(e => e.Vpassword)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("VPassword");
            entity.Property(e => e.VsegundoNombre)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("VSegundoNombre");
        });

        OnModelCreatingPartial(modelBuilder);
        modelBuilder.UseIdentityColumns();
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
