using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PayrollSoftware.Core.Models.TaskManagement
{
    public partial class TaskManagementContext : DbContext
    {
        private readonly string _connectionString = @"Data Source=DESKTOP-9A503Q7\\SQLEXPRESS;Initial Catalog=TaskManagement;Integrated Security=True;Trust Server Certificate=True";
        public TaskManagementContext(string connectionString)
        {
        }
        public TaskManagementContext()
        {
        }

        public TaskManagementContext(DbContextOptions<TaskManagementContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ActivityLog> ActivityLogs { get; set; } = null!;
        public virtual DbSet<Comment> Comments { get; set; } = null!;
        public virtual DbSet<Project> Projects { get; set; } = null!;
        public virtual DbSet<ProjectAssigned> ProjectAssigneds { get; set; } = null!;
        public virtual DbSet<Task> Tasks { get; set; } = null!;
        public virtual DbSet<TaskAssigned> TaskAssigneds { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ActivityLog>(entity =>
            {
                entity.ToTable("ActivityLog");

                entity.Property(e => e.ActivityLogId).HasColumnName("ActivityLogID");

                entity.Property(e => e.Action).HasMaxLength(200);

                entity.Property(e => e.FromStatus).HasMaxLength(100);

                entity.Property(e => e.TaskId).HasColumnName("TaskID");

                entity.Property(e => e.ToStatus).HasMaxLength(100);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Task)
                    .WithMany(p => p.ActivityLogs)
                    .HasForeignKey(d => d.TaskId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ActivityL__TaskI__47DBAE45");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ActivityLogs)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ActivityL__UserI__48CFD27E");
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.ToTable("Comment");

                entity.Property(e => e.CommentId).HasColumnName("CommentID");

                entity.Property(e => e.CommentContent).HasMaxLength(1000);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ProjectId).HasColumnName("ProjectID");

                entity.Property(e => e.TaskId).HasColumnName("TaskID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Comment__Project__44FF419A");

                entity.HasOne(d => d.Task)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.TaskId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Comment__TaskID__440B1D61");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Comment__UserID__4316F928");
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.ToTable("Project");

                entity.Property(e => e.ProjectId).HasColumnName("ProjectID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Descriptions).HasColumnType("ntext");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.ProjectCode).HasMaxLength(100);

                entity.Property(e => e.ProjectName).HasMaxLength(200);

                entity.Property(e => e.Status).HasMaxLength(100);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<ProjectAssigned>(entity =>
            {
                entity.HasKey(e => new { e.ProjectId, e.UserId })
                    .HasName("PK__ProjectA__A762321A1F4159E2");

                entity.ToTable("ProjectAssigned");

                entity.Property(e => e.ProjectId).HasColumnName("ProjectID");

                entity.Property(e => e.UserId)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("UserID")
                    .IsFixedLength();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.Role).HasMaxLength(100);

                entity.Property(e => e.Status).HasMaxLength(100);
            });

            modelBuilder.Entity<Task>(entity =>
            {
                entity.ToTable("Task");

                entity.Property(e => e.TaskId).HasColumnName("TaskID");

                entity.Property(e => e.CompletionDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasColumnType("ntext");

                entity.Property(e => e.DueDate).HasColumnType("datetime");

                entity.Property(e => e.Priority).HasMaxLength(100);

                entity.Property(e => e.ProjectId).HasColumnName("ProjectID");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.Status).HasMaxLength(100);

                entity.Property(e => e.TaskCode).HasMaxLength(100);

                entity.Property(e => e.TaskName).HasMaxLength(100);

                entity.Property(e => e.Type).HasMaxLength(100);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.Tasks)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Task__ProjectID__3D5E1FD2");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Tasks)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Task__UserID__3E52440B");
            });

            modelBuilder.Entity<TaskAssigned>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.TaskId })
                    .HasName("PK__TaskAssi__104E58311E615DDA");

                entity.ToTable("TaskAssigned");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.TaskId).HasColumnName("TaskID");

                entity.Property(e => e.Comment).HasColumnType("ntext");

                entity.Property(e => e.CompletionDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Rate).HasMaxLength(100);

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.Status).HasColumnType("datetime");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.Address).HasMaxLength(200);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DateOfBirth).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(200);

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.FirstName).HasMaxLength(100);

                entity.Property(e => e.IdentificationCard).HasMaxLength(100);

                entity.Property(e => e.JobPosition).HasMaxLength(100);

                entity.Property(e => e.LastName).HasMaxLength(100);

                entity.Property(e => e.Phone).HasMaxLength(200);

                entity.Property(e => e.Role).HasMaxLength(100);

                entity.Property(e => e.UserCode).HasMaxLength(100);
                entity.Property(e => e.Status).HasMaxLength(100);
                entity.Property(e => e.Password).HasMaxLength(100);
                entity.Property(e => e.Username).HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
