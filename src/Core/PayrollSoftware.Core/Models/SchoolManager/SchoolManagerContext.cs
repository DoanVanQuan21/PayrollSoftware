using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PayrollSoftware.Core.Models.SchoolManager
{
    public partial class SchoolManagerContext : DbContext
    {
        private string connectionString;
        public SchoolManagerContext()
        {

        }
        public SchoolManagerContext(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public SchoolManagerContext(DbContextOptions<SchoolManagerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AcademicTranscript> AcademicTranscripts { get; set; } = null!;
        public virtual DbSet<Assignment> Assignments { get; set; } = null!;
        public virtual DbSet<Classroom> Classrooms { get; set; } = null!;
        public virtual DbSet<Course> Courses { get; set; } = null!;
        public virtual DbSet<Department> Departments { get; set; } = null!;
        public virtual DbSet<Shecdule> Shecdules { get; set; } = null!;
        public virtual DbSet<Student> Students { get; set; } = null!;
        public virtual DbSet<Subject> Subjects { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AcademicTranscript>(entity =>
            {
                entity.ToTable("AcademicTranscript");

                entity.Property(e => e.AcademicTranscriptId).HasColumnName("AcademicTranscriptID");

                entity.Property(e => e.AcademicTranscriptCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.StudentId).HasColumnName("StudentID");

                entity.Property(e => e.SubjectId).HasColumnName("SubjectID");
            });

            modelBuilder.Entity<Assignment>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.ClassroomId })
                    .HasName("PK__Assignme__A69ED444416EF59A");

                entity.ToTable("Assignment");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.ClassroomId).HasColumnName("ClassroomID");

                entity.Property(e => e.CourseId).HasColumnName("CourseID");

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.Position).HasMaxLength(10);

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.Property(e => e.Status).HasMaxLength(100);
            });

            modelBuilder.Entity<Classroom>(entity =>
            {
                entity.ToTable("Classroom");

                entity.Property(e => e.ClassroomId).HasColumnName("ClassroomID");

                entity.Property(e => e.ClassroomCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ClassroomName).HasMaxLength(100);
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.ToTable("Course");

                entity.Property(e => e.CourseId).HasColumnName("CourseID");

                entity.Property(e => e.CourseCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CourseContent).HasColumnType("ntext");

                entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

                entity.Property(e => e.SubjectId).HasColumnName("SubjectID");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.ToTable("Department");

                entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

                entity.Property(e => e.DepartmentCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DepartmentName).HasMaxLength(100);
            });

            modelBuilder.Entity<Shecdule>(entity =>
            {
                entity.ToTable("Shecdule");

                entity.Property(e => e.ShecduleId).HasColumnName("ShecduleID");

                entity.Property(e => e.ShecduleCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("Student");

                entity.Property(e => e.StudentId).HasColumnName("StudentID");

                entity.Property(e => e.ClassroomId).HasColumnName("ClassroomID");

                entity.Property(e => e.StudentAddress).HasMaxLength(100);

                entity.Property(e => e.StudentBirthday).HasColumnType("date");

                entity.Property(e => e.StudentCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.StudentFullname).HasMaxLength(100);

                entity.Property(e => e.StudentPhone)
                    .HasMaxLength(11)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.ToTable("Subject");

                entity.Property(e => e.SubjectId).HasColumnName("SubjectID");

                entity.Property(e => e.SubjectCode).HasMaxLength(10);

                entity.Property(e => e.SubjectName).HasMaxLength(100);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.Address).HasMaxLength(100);

                entity.Property(e => e.Birthday).HasColumnType("date");

                entity.Property(e => e.Cartificate).HasMaxLength(150);

                entity.Property(e => e.DateOff).HasColumnType("date");

                entity.Property(e => e.DateStartWork).HasColumnType("date");

                entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.Role)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SpecializedIn).HasMaxLength(150);

                entity.Property(e => e.State).HasMaxLength(100);

                entity.Property(e => e.Surname).HasMaxLength(100);

                entity.Property(e => e.UserCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
