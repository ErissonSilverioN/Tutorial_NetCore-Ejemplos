using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Tutorial_.NetCore_Ejemplos.Models
{
    public partial class SchoolDBContext : DbContext
    {
        //public SchoolDBContext(DbContextOptions<SchoolDBContext> options)
        //    : base(options)
        //{
        //}

        public virtual DbSet<Course> Course { get; set; }
        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<StudentAddress> StudentAddress { get; set; }
        public virtual DbSet<StudentCourse> StudentCourse { get; set; }
        public virtual DbSet<Teacher> Teacher { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=SchoolDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>(entity =>
            {
                entity.Property(e => e.CourseId).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.Schedule)
                    .HasColumnName("schedule")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.Property(e => e.StudentId).ValueGeneratedNever();

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<StudentAddress>(entity =>
            {
                entity.Property(e => e.StudentAddressId).ValueGeneratedNever();

                entity.Property(e => e.Direccion).IsUnicode(false);

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.StudentAddress)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK__StudentAd__Stude__4D94879B");
            });

            modelBuilder.Entity<StudentCourse>(entity =>
            {
                entity.HasKey(e => e.StudentCourse1)
                    .HasName("PK__StudentC__8A11E474995DF83B");

                entity.Property(e => e.StudentCourse1)
                    .HasColumnName("StudentCourse")
                    .ValueGeneratedNever();

                entity.Property(e => e.StudentName)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.StudentCourse)
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("FK__StudentCo__Cours__5070F446");
            });

            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.HasKey(e => e.Teacher1)
                    .HasName("PK__Teacher__65E3C00BA850CAD5");

                entity.Property(e => e.Teacher1)
                    .HasColumnName("Teacher")
                    .ValueGeneratedNever();

                entity.Property(e => e.FirstName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Telephone)
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
