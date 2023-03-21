using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ResumeBuilder.Models;

public partial class TupContext : DbContext
{
    public TupContext()
    {
    }

    public TupContext(DbContextOptions<TupContext> options)
        : base(options)
    {
    }

    public virtual DbSet<EmergencyContact> EmergencyContacts { get; set; }

    public virtual DbSet<Experience> Experiences { get; set; }

    public virtual DbSet<Link> Links { get; set; }

    public virtual DbSet<School> Schools { get; set; }

    public virtual DbSet<Skill> Skills { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<Training> Training { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EmergencyContact>(entity =>
        {
            entity.ToTable("EmergencyContact");

            entity.Property(e => e.EmergencyContact1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("EmergencyContact");
            entity.Property(e => e.EmergencyName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Relationship)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Student).WithMany(p => p.EmergencyContacts)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK_EmergencyContact_Student");
        });

        modelBuilder.Entity<Experience>(entity =>
        {
            entity.ToTable("Experience");

            entity.Property(e => e.ExperienceName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Location)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Role)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Student).WithMany(p => p.Experiences)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK_Experience_Student");
        });

        modelBuilder.Entity<Link>(entity =>
        {
            entity.ToTable("Link");

            entity.Property(e => e.Facebook)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Github)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LinkedIn)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Portfolio)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Student).WithMany(p => p.Links)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK_Link_Student");
        });

        modelBuilder.Entity<School>(entity =>
        {
            entity.ToTable("School");

            entity.Property(e => e.Course)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.EndDate)
                .HasColumnType("date")
                .HasColumnName("endDate");
            entity.Property(e => e.Location)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Schoolname)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.StartDate).HasColumnType("date");

            entity.HasOne(d => d.Student).WithMany(p => p.Schools)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK_School_Student");
        });

        modelBuilder.Entity<Skill>(entity =>
        {
            entity.ToTable("Skill");

            entity.Property(e => e.Skillname)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Student).WithMany(p => p.Skills)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK_Skill_Student");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.ToTable("Student");

            entity.Property(e => e.Address)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Firstname)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Lastname)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Middlename)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Objectives)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Training>(entity =>
        {
            entity.Property(e => e.EndDate).HasColumnType("date");
            entity.Property(e => e.Location)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.StartDate).HasColumnType("date");
            entity.Property(e => e.TrainingName)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Student).WithMany(p => p.Training)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK_Training_Student");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
