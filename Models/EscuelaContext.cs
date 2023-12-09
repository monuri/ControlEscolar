using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ControlEscolar.Models;

public partial class EscuelaContext : DbContext
{
    public EscuelaContext()
    {
    }

    public EscuelaContext(DbContextOptions<EscuelaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblAlumno> TblAlumnos { get; set; }

    public virtual DbSet<TblCalificacione> TblCalificaciones { get; set; }

    public virtual DbSet<TblCiclo> TblCiclos { get; set; }

    public virtual DbSet<TblCicloGrupoMaterium> TblCicloGrupoMateria { get; set; }

    public virtual DbSet<TblGrupo> TblGrupos { get; set; }

    public virtual DbSet<TblGrupoProfAlumno> TblGrupoProfAlumnos { get; set; }

    public virtual DbSet<TblMaterium> TblMateria { get; set; }

    public virtual DbSet<TblProfesor> TblProfesors { get; set; }

    public virtual DbSet<TblTipoCalificacion> TblTipoCalificacions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblAlumno>(entity =>
        {
            entity.HasKey(e => e.IdAlumno);

            entity.ToTable("tblAlumno");

            entity.Property(e => e.Apellidos).HasMaxLength(100);
            entity.Property(e => e.Correo).HasMaxLength(100);
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.Telefono).HasMaxLength(100);
        });

        modelBuilder.Entity<TblCalificacione>(entity =>
        {
            entity.HasKey(e => e.IdCalificaciones);

            entity.ToTable("tblCalificaciones");

            entity.HasOne(d => d.FidGrupoProfAlumnoNavigation).WithMany(p => p.TblCalificaciones)
                .HasForeignKey(d => d.FidGrupoProfAlumno)
                .HasConstraintName("FK_tblCalificaciones_tblGrupoProfAlumno");

            entity.HasOne(d => d.FidTipoCalificacionNavigation).WithMany(p => p.TblCalificaciones)
                .HasForeignKey(d => d.FidTipoCalificacion)
                .HasConstraintName("FK_tblCalificaciones_tblTipoCalificacion");
        });

        modelBuilder.Entity<TblCiclo>(entity =>
        {
            entity.HasKey(e => e.IdCiclo);

            entity.ToTable("tblCiclo");

            entity.Property(e => e.CveCiclo).HasColumnName("cve_ciclo");
            entity.Property(e => e.NombreCiclo).HasMaxLength(100);
        });

        modelBuilder.Entity<TblCicloGrupoMaterium>(entity =>
        {
            entity.HasKey(e => e.IdCicloxGrupoxMateria);

            entity.ToTable("tblCicloGrupoMateria");

            entity.Property(e => e.FidCiclo).HasColumnName("fidCiclo");
            entity.Property(e => e.FidGrupo).HasColumnName("fidGrupo");
            entity.Property(e => e.FidMateria).HasColumnName("fidMateria");

            entity.HasOne(d => d.FidCicloNavigation).WithMany(p => p.TblCicloGrupoMateria)
                .HasForeignKey(d => d.FidCiclo)
                .HasConstraintName("FK_tblCicloGrupoMateria_tblCiclo");

            entity.HasOne(d => d.FidGrupoNavigation).WithMany(p => p.TblCicloGrupoMateria)
                .HasForeignKey(d => d.FidGrupo)
                .HasConstraintName("FK_tblCicloGrupoMateria_tblGrupo");

            entity.HasOne(d => d.FidMateriaNavigation).WithMany(p => p.TblCicloGrupoMateria)
                .HasForeignKey(d => d.FidMateria)
                .HasConstraintName("FK_tblCicloGrupoMateria_tblMateria");
        });

        modelBuilder.Entity<TblGrupo>(entity =>
        {
            entity.HasKey(e => e.IdGrupo);

            entity.ToTable("tblGrupo");

            entity.Property(e => e.NombreGrupo).HasMaxLength(100);
        });

        modelBuilder.Entity<TblGrupoProfAlumno>(entity =>
        {
            entity.HasKey(e => e.IdGrupoProfAlumno);

            entity.ToTable("tblGrupoProfAlumno");

            entity.HasOne(d => d.FidAlumnoNavigation).WithMany(p => p.TblGrupoProfAlumnos)
                .HasForeignKey(d => d.FidAlumno)
                .HasConstraintName("FK_tblGrupoProfAlumno_tblAlumno");

            entity.HasOne(d => d.FidGrupoNavigation).WithMany(p => p.TblGrupoProfAlumnos)
                .HasForeignKey(d => d.FidGrupo)
                .HasConstraintName("FK_tblGrupoProfAlumno_tblGrupo");

            entity.HasOne(d => d.FidProfesorNavigation).WithMany(p => p.TblGrupoProfAlumnos)
                .HasForeignKey(d => d.FidProfesor)
                .HasConstraintName("FK_tblGrupoProfAlumno_tblProfesor");
        });

        modelBuilder.Entity<TblMaterium>(entity =>
        {
            entity.HasKey(e => e.IdMateria);

            entity.ToTable("tblMateria");

            entity.Property(e => e.NombreMateria)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TblProfesor>(entity =>
        {
            entity.HasKey(e => e.IdProfesor);

            entity.ToTable("tblProfesor");

            entity.Property(e => e.Apellidos).HasMaxLength(100);
            entity.Property(e => e.Correo).HasMaxLength(100);
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.Telefono).HasMaxLength(100);
        });

        modelBuilder.Entity<TblTipoCalificacion>(entity =>
        {
            entity.HasKey(e => e.IdTipoCal);

            entity.ToTable("tblTipoCalificacion");

            entity.Property(e => e.DescripcionCal).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
