﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PayrollSoftware.Core.Models.TaskManagement;

#nullable disable

namespace PayrollSoftware.Core.Migrations
{
    [DbContext(typeof(TaskManagementContext))]
    partial class TaskManagementContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("PayrollSoftware.Core.Models.TaskManagement.ActivityLog", b =>
                {
                    b.Property<long>("ActivityLogId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("ActivityLogID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ActivityLogId"), 1L, 1);

                    b.Property<string>("Action")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("FromStatus")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<long>("TaskId")
                        .HasColumnType("bigint")
                        .HasColumnName("TaskID");

                    b.Property<string>("ToStatus")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("UserID");

                    b.HasKey("ActivityLogId");

                    b.HasIndex(new[] { "TaskId" }, "IX_ActivityLog_TaskID");

                    b.HasIndex(new[] { "UserId" }, "IX_ActivityLog_UserID");

                    b.ToTable("ActivityLog", (string)null);
                });

            modelBuilder.Entity("PayrollSoftware.Core.Models.TaskManagement.Comment", b =>
                {
                    b.Property<long>("CommentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("CommentID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("CommentId"), 1L, 1);

                    b.Property<long?>("CommentCode")
                        .HasColumnType("bigint");

                    b.Property<string>("CommentContent")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int")
                        .HasColumnName("ProjectID");

                    b.Property<long>("TaskId")
                        .HasColumnType("bigint")
                        .HasColumnName("TaskID");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("UserID");

                    b.HasKey("CommentId");

                    b.HasIndex(new[] { "ProjectId" }, "IX_Comment_ProjectID");

                    b.HasIndex(new[] { "TaskId" }, "IX_Comment_TaskID");

                    b.HasIndex(new[] { "UserId" }, "IX_Comment_UserID");

                    b.ToTable("Comment", (string)null);
                });

            modelBuilder.Entity("PayrollSoftware.Core.Models.TaskManagement.Project", b =>
                {
                    b.Property<int>("ProjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ProjectID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProjectId"), 1L, 1);

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Descriptions")
                        .HasColumnType("ntext");

                    b.Property<bool>("Disable")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime");

                    b.Property<string>("ProjectCode")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ProjectName")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Status")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime");

                    b.HasKey("ProjectId");

                    b.ToTable("Project", (string)null);
                });

            modelBuilder.Entity("PayrollSoftware.Core.Models.TaskManagement.ProjectAssigned", b =>
                {
                    b.Property<int>("ProjectId")
                        .HasColumnType("int")
                        .HasColumnName("ProjectID");

                    b.Property<string>("UserId")
                        .HasMaxLength(1)
                        .IsUnicode(false)
                        .HasColumnType("char(1)")
                        .HasColumnName("UserID")
                        .IsFixedLength();

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Role")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Status")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("ProjectId", "UserId")
                        .HasName("PK__ProjectA__A762321A1F4159E2");

                    b.ToTable("ProjectAssigned", (string)null);
                });

            modelBuilder.Entity("PayrollSoftware.Core.Models.TaskManagement.Task", b =>
                {
                    b.Property<long>("TaskId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("TaskID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("TaskId"), 1L, 1);

                    b.Property<DateTime?>("CompletionDate")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Description")
                        .HasColumnType("ntext");

                    b.Property<DateTime?>("DueDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Priority")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int")
                        .HasColumnName("ProjectID");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Status")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("TaskCode")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("TaskName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Type")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("UserID");

                    b.HasKey("TaskId");

                    b.HasIndex(new[] { "ProjectId" }, "IX_Task_ProjectID");

                    b.HasIndex(new[] { "UserId" }, "IX_Task_UserID");

                    b.ToTable("Task", (string)null);
                });

            modelBuilder.Entity("PayrollSoftware.Core.Models.TaskManagement.TaskAssigned", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("UserID");

                    b.Property<long>("TaskId")
                        .HasColumnType("bigint")
                        .HasColumnName("TaskID");

                    b.Property<string>("Comment")
                        .HasColumnType("ntext");

                    b.Property<DateTime?>("CompletionDate")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Rate")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("Status")
                        .HasColumnType("datetime");

                    b.Property<long?>("TaskParent")
                        .HasColumnType("bigint");

                    b.HasKey("UserId", "TaskId")
                        .HasName("PK__TaskAssi__104E58311E615DDA");

                    b.ToTable("TaskAssigned", (string)null);
                });

            modelBuilder.Entity("PayrollSoftware.Core.Models.TaskManagement.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("UserID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"), 1L, 1);

                    b.Property<string>("Address")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("datetime");

                    b.Property<string>("Email")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime");

                    b.Property<string>("FirstName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("IdentificationCard")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JobPosition")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool?>("LockAccount")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Role")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Status")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasDefaultValueSql("(N'')");

                    b.Property<string>("UserCode")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("PayrollSoftware.Core.Models.TaskManagement.ActivityLog", b =>
                {
                    b.HasOne("PayrollSoftware.Core.Models.TaskManagement.Task", "Task")
                        .WithMany("ActivityLogs")
                        .HasForeignKey("TaskId")
                        .IsRequired()
                        .HasConstraintName("FK__ActivityL__TaskI__47DBAE45");

                    b.HasOne("PayrollSoftware.Core.Models.TaskManagement.User", "User")
                        .WithMany("ActivityLogs")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("FK__ActivityL__UserI__48CFD27E");

                    b.Navigation("Task");

                    b.Navigation("User");
                });

            modelBuilder.Entity("PayrollSoftware.Core.Models.TaskManagement.Comment", b =>
                {
                    b.HasOne("PayrollSoftware.Core.Models.TaskManagement.Project", "Project")
                        .WithMany("Comments")
                        .HasForeignKey("ProjectId")
                        .IsRequired()
                        .HasConstraintName("FK__Comment__Project__44FF419A");

                    b.HasOne("PayrollSoftware.Core.Models.TaskManagement.Task", "Task")
                        .WithMany("Comments")
                        .HasForeignKey("TaskId")
                        .IsRequired()
                        .HasConstraintName("FK__Comment__TaskID__440B1D61");

                    b.HasOne("PayrollSoftware.Core.Models.TaskManagement.User", "User")
                        .WithMany("Comments")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("FK__Comment__UserID__4316F928");

                    b.Navigation("Project");

                    b.Navigation("Task");

                    b.Navigation("User");
                });

            modelBuilder.Entity("PayrollSoftware.Core.Models.TaskManagement.Task", b =>
                {
                    b.HasOne("PayrollSoftware.Core.Models.TaskManagement.Project", "Project")
                        .WithMany("Tasks")
                        .HasForeignKey("ProjectId")
                        .IsRequired()
                        .HasConstraintName("FK__Task__ProjectID__3D5E1FD2");

                    b.HasOne("PayrollSoftware.Core.Models.TaskManagement.User", "User")
                        .WithMany("Tasks")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("FK__Task__UserID__3E52440B");

                    b.Navigation("Project");

                    b.Navigation("User");
                });

            modelBuilder.Entity("PayrollSoftware.Core.Models.TaskManagement.Project", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("PayrollSoftware.Core.Models.TaskManagement.Task", b =>
                {
                    b.Navigation("ActivityLogs");

                    b.Navigation("Comments");
                });

            modelBuilder.Entity("PayrollSoftware.Core.Models.TaskManagement.User", b =>
                {
                    b.Navigation("ActivityLogs");

                    b.Navigation("Comments");

                    b.Navigation("Tasks");
                });
#pragma warning restore 612, 618
        }
    }
}
