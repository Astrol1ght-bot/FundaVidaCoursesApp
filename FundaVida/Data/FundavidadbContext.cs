using System;
using System.Collections.Generic;
using FundaVida.Models;
using Microsoft.EntityFrameworkCore;

namespace FundaVida.Data;

public partial class FundavidadbContext : DbContext
{
    public FundavidadbContext()
    {
    }

    public FundavidadbContext(DbContextOptions<FundavidadbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Administrador> Administradors { get; set; }

    public virtual DbSet<Curso> Cursos { get; set; }

    public virtual DbSet<Estudiante> Estudiantes { get; set; }

    public virtual DbSet<Grupo> Grupos { get; set; }

    public virtual DbSet<Horario> Horarios { get; set; }

    public virtual DbSet<Profesor> Profesors { get; set; }

    public virtual DbSet<Vacante> Vacantes { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Administrador>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Administrador");

            entity.Property(e => e.AdministradorHashpassword)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("administradorHashpassword");
            entity.Property(e => e.AdministradorId)
                .ValueGeneratedOnAdd()
                .HasColumnName("administradorID");
            entity.Property(e => e.AdministradorNombre)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("administradorNombre");
        });

        modelBuilder.Entity<Curso>(entity =>
        {
            entity.HasKey(e => e.CursoId).HasName("pk_Curso_cursoID");

            entity.ToTable("Curso");

            entity.Property(e => e.CursoId).HasColumnName("cursoID");
            entity.Property(e => e.CursoImagen)
                .HasMaxLength(1)
                .HasColumnName("cursoImagen");
            entity.Property(e => e.CursoNombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("cursoNombre");
        });

        modelBuilder.Entity<Estudiante>(entity =>
        {
            entity.HasKey(e => e.EstudianteId).HasName("pk_Estudiante_estudianteID");

            entity.ToTable("Estudiante");

            entity.Property(e => e.EstudianteId).HasColumnName("estudianteID");
            entity.Property(e => e.EstudianteApellidos)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("estudianteApellidos");
            entity.Property(e => e.EstudianteCorreo)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("estudianteCorreo");
            entity.Property(e => e.EstudianteNombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("estudianteNombre");
        });

        modelBuilder.Entity<Grupo>(entity =>
        {
            entity.HasKey(e => e.GrupoId).HasName("pk_Grupo_grupoID");

            entity.ToTable("Grupo");

            entity.Property(e => e.GrupoId).HasColumnName("grupoID");
            entity.Property(e => e.GrupoNombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("grupoNombre");
        });

        modelBuilder.Entity<Horario>(entity =>
        {
            entity.HasKey(e => e.HorarioId).HasName("pk_Horario_horarioID");

            entity.ToTable("Horario");

            entity.Property(e => e.HorarioId).HasColumnName("horarioID");
            entity.Property(e => e.CursoId).HasColumnName("cursoID");
            entity.Property(e => e.GrupoId).HasColumnName("grupoID");
            entity.Property(e => e.ProfesorId).HasColumnName("profesorID");
            entity.Property(e => e.VacanteId).HasColumnName("vacanteID");

            entity.HasOne(d => d.Curso).WithMany(p => p.Horarios)
                .HasForeignKey(d => d.CursoId)
                .HasConstraintName("fk_Horario_horarioID");

            entity.HasOne(d => d.Grupo).WithMany(p => p.Horarios)
                .HasForeignKey(d => d.GrupoId)
                .HasConstraintName("fk_Grupo_grupoID");

            entity.HasOne(d => d.Profesor).WithMany(p => p.Horarios)
                .HasForeignKey(d => d.ProfesorId)
                .HasConstraintName("fk_Profesor_profesorID");

            entity.HasOne(d => d.Vacante).WithMany(p => p.Horarios)
                .HasForeignKey(d => d.VacanteId)
                .HasConstraintName("fk_Horario_vacanteID");

            entity.HasMany(d => d.Estudiantes).WithMany(p => p.Horarios)
                .UsingEntity<Dictionary<string, object>>(
                    "HorarioEstudiante",
                    r => r.HasOne<Estudiante>().WithMany()
                        .HasForeignKey("EstudianteId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_HorarioEstudiante_estudianteID"),
                    l => l.HasOne<Horario>().WithMany()
                        .HasForeignKey("HorarioId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_HorarioEstudiante_horarioID"),
                    j =>
                    {
                        j.HasKey("HorarioId", "EstudianteId").HasName("pk_HorarioEstudianteID");
                        j.ToTable("HorarioEstudiante");
                    });
        });

        modelBuilder.Entity<Profesor>(entity =>
        {
            entity.HasKey(e => e.ProfesorId).HasName("pk_Profesor_profesorID");

            entity.ToTable("Profesor");

            entity.Property(e => e.ProfesorId).HasColumnName("profesorID");
            entity.Property(e => e.Apellidos)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("apellidos");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Vacante>(entity =>
        {
            entity.HasKey(e => e.VacanteId).HasName("pk_Vacante_vacanteID");

            entity.ToTable("Vacante");

            entity.Property(e => e.VacanteId).HasColumnName("vacanteID");
            entity.Property(e => e.Dia)
                .HasColumnType("date")
                .HasColumnName("dia");
            entity.Property(e => e.EnEspera).HasColumnName("enEspera");
            entity.Property(e => e.HoraFin).HasColumnName("horaFin");
            entity.Property(e => e.HoraInicio).HasColumnName("horaInicio");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
