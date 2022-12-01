using System;
using System.Collections.Generic;
using FundaVida.Entity.Models;
using Microsoft.EntityFrameworkCore;

namespace FundaVida.Entity.Data;

public partial class FundavidadbContext : DbContext
{
    public FundavidadbContext()
    {
    }

    public FundavidadbContext(DbContextOptions<FundavidadbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<Enrollment> Enrollments { get; set; }

    public virtual DbSet<Group> Groups { get; set; }

    public virtual DbSet<Modality> Modalities { get; set; }

    public virtual DbSet<Module> Modules { get; set; }

    public virtual DbSet<Professor> Professors { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:defaultconnectionstring");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.CourseId).HasName("pk_courseId");

            entity.Property(e => e.CourseId).HasColumnName("courseId");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.ImageData).HasColumnName("imageData");
            entity.Property(e => e.ModalityId).HasColumnName("modalityId");
            entity.Property(e => e.Name)
                .HasMaxLength(150)
                .HasColumnName("name");
            entity.Property(e => e.ProfessorId).HasColumnName("professorId");

            entity.HasOne(d => d.Modality).WithMany(p => p.Courses)
                .HasForeignKey(d => d.ModalityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_course_modalityId");

            entity.HasOne(d => d.Professor).WithMany(p => p.Courses)
                .HasForeignKey(d => d.ProfessorId)
                .HasConstraintName("fk_course_professorId");

            entity.Property(e => e.MaxEnrollments).HasColumnName("maxEnrollments");
        });

        modelBuilder.Entity<Enrollment>(entity =>
        {
            entity.HasKey(e => e.EnrollmentId).HasName("pk_enrollmentId");

            entity.Property(e => e.EnrollmentId).HasColumnName("enrollmentId");
            entity.Property(e => e.CourseId).HasColumnName("courseId");
            entity.Property(e => e.EnEspera).HasColumnName("enEspera");
            entity.Property(e => e.GroupId).HasColumnName("groupId");
            entity.Property(e => e.StudentId).HasColumnName("studentId");

            entity.HasOne(d => d.Course).WithMany(p => p.Enrollments)
                .HasForeignKey(d => d.CourseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_enrollment_courseId");

            entity.HasOne(d => d.Group).WithMany(p => p.Enrollments)
                .HasForeignKey(d => d.GroupId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_enrollment_groupId");

            entity.HasOne(d => d.Student).WithMany(p => p.Enrollments)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_enrollment_studentId");
        });

        modelBuilder.Entity<Group>(entity =>
        {
            entity.HasKey(e => e.GroupId).HasName("pk_groupId");

            entity.Property(e => e.GroupId).HasColumnName("groupId");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Modality>(entity =>
        {
            entity.HasKey(e => e.ModalityId).HasName("pk_modalityId");

            entity.ToTable("Modality");

            entity.Property(e => e.ModalityId).HasColumnName("modalityId");
            entity.Property(e => e.Name)
                .HasMaxLength(15)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Module>(entity =>
        {
            entity.HasKey(e => e.ModuleId).HasName("pk_moduleId");

            entity.Property(e => e.ModuleId).HasColumnName("moduleId");
            entity.Property(e => e.CourseId).HasColumnName("courseId");
            entity.Property(e => e.DateFin)
                .HasColumnType("date")
                .HasColumnName("dateFin");
            entity.Property(e => e.DateIni)
                .HasColumnType("date")
                .HasColumnName("dateIni");
            entity.Property(e => e.Name)
                .HasMaxLength(200)
                .HasColumnName("name");
            entity.Property(e => e.Schedule)
                .HasMaxLength(100)
                .HasColumnName("schedule");
            entity.Property(e => e.TotalHours).HasColumnName("totalHours");
            entity.Property(e => e.Weeks).HasColumnName("weeks");

            entity.HasOne(d => d.Course).WithMany(p => p.Modules)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("fk_module_courseId");
        });

        modelBuilder.Entity<Professor>(entity =>
        {
            entity.HasKey(e => e.ProfessorId).HasName("pk_professorId");

            entity.Property(e => e.ProfessorId).HasColumnName("professorId");
            entity.Property(e => e.LastName)
                .HasMaxLength(200)
                .HasColumnName("lastName");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("pk_studentId");

            entity.Property(e => e.StudentId).HasColumnName("studentId");
            entity.Property(e => e.Email)
                .HasMaxLength(200)
                .HasColumnName("email");
            entity.Property(e => e.LastName)
                .HasMaxLength(200)
                .HasColumnName("lastName");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(12)
                .HasColumnName("phoneNumber");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("pk_userId");

            entity.Property(e => e.UserId).HasColumnName("userId");
            entity.Property(e => e.Hashedpassword)
                .HasMaxLength(50)
                .HasColumnName("hashedpassword");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Role)
                .HasMaxLength(20)
                .HasColumnName("role");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
