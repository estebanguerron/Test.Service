using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Test.Service.Data.Models;

public partial class TestContext : DbContext
{
    public TestContext()
    {
    }

    public TestContext(DbContextOptions<TestContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Calificacione> Calificaciones { get; set; }

    public virtual DbSet<Colegio> Colegios { get; set; }

    public virtual DbSet<Materium> Materia { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

  //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
         //=> optionsBuilder.UseSqlServer(Configuration.GetConnectionString("conexion"));
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
       //=> optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=TEST;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Calificacione>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CALIFICA__3214EC077635512E");

            entity.ToTable("CALIFICACIONES");

            entity.Property(e => e.Calificacion).HasColumnType("numeric(18, 2)");

            entity.HasOne(d => d.IdColegioNavigation).WithMany(p => p.Calificaciones)
                .HasForeignKey(d => d.IdColegio)
                .HasConstraintName("fk_ColegioCal");

            entity.HasOne(d => d.IdMateriaNavigation).WithMany(p => p.Calificaciones)
                .HasForeignKey(d => d.IdMateria)
                .HasConstraintName("fk_Materia");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Calificaciones)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("fk_Usuario");
        });

        modelBuilder.Entity<Colegio>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__COLEGIO__3214EC070E2D8440");

            entity.ToTable("COLEGIO");

            entity.HasIndex(e => e.Nombre, "UQ__COLEGIO__75E3EFCFD8BB4563").IsUnique();

            entity.Property(e => e.Nombre)
                .HasMaxLength(256)
                .IsUnicode(false);
            entity.Property(e => e.TipoColegio)
                .HasMaxLength(64)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Materium>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__MATERIA__3214EC07E3B224E4");

            entity.ToTable("MATERIA");

            entity.HasIndex(e => e.Nombre, "UQ__MATERIA__75E3EFCFDB4AF4A8").IsUnique();

            entity.Property(e => e.Area)
                .HasMaxLength(128)
                .IsUnicode(false);
            entity.Property(e => e.Curso)
                .HasMaxLength(64)
                .IsUnicode(false);
            entity.Property(e => e.DocenteAsignado)
                .HasMaxLength(512)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(256)
                .IsUnicode(false);
            entity.Property(e => e.Paralelo)
                .HasMaxLength(16)
                .IsUnicode(false);

            entity.HasOne(d => d.IdColegioNavigation).WithMany(p => p.Materia)
                .HasForeignKey(d => d.IdColegio)
                .HasConstraintName("fk_Colegio");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__USUARIO__3214EC07175ACB69");

            entity.ToTable("USUARIO");

            entity.HasIndex(e => e.Username, "UQ__USUARIO__536C85E434507CDB").IsUnique();

            entity.Property(e => e.CorreoElectronico)
                .HasMaxLength(256)
                .IsUnicode(false);
            entity.Property(e => e.NombreCompleto)
                .HasMaxLength(256)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(128)
                .IsUnicode(false);
            entity.Property(e => e.Rol)
                .HasMaxLength(32)
                .IsUnicode(false);
            entity.Property(e => e.Username)
                .HasMaxLength(128)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
