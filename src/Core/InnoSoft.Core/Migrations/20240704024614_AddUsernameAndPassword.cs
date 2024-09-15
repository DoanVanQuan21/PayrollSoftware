using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InnoSoft.Core.Migrations
{
    public partial class AddUsernameAndPassword : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            Down(migrationBuilder);
            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    ProjectID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ProjectName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Descriptions = table.Column<string>(type: "ntext", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Disable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.ProjectID);
                });

            migrationBuilder.CreateTable(
                name: "ProjectAssigned",
                columns: table => new
                {
                    ProjectID = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Status = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ProjectA__A762321A1F4159E2", x => new { x.ProjectID, x.UserID });
                });

            migrationBuilder.CreateTable(
                name: "TaskAssigned",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false),
                    TaskID = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CompletionDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Status = table.Column<DateTime>(type: "datetime", nullable: true),
                    Rate = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Comment = table.Column<string>(type: "ntext", nullable: true),
                    TaskParent = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TaskAssi__104E58311E615DDA", x => new { x.UserID, x.TaskID });
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Role = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IdentificationCard = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    JobPosition = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LockAccount = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "Task",
                columns: table => new
                {
                    TaskID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaskCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    TaskName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Description = table.Column<string>(type: "ntext", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    DueDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Type = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Priority = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CompletionDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ProjectID = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Task", x => x.TaskID);
                    table.ForeignKey(
                        name: "FK__Task__ProjectID__3D5E1FD2",
                        column: x => x.ProjectID,
                        principalTable: "Project",
                        principalColumn: "ProjectID");
                    table.ForeignKey(
                        name: "FK__Task__UserID__3E52440B",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "ActivityLog",
                columns: table => new
                {
                    ActivityLogID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Action = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    FromStatus = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ToStatus = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    TaskID = table.Column<long>(type: "bigint", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityLog", x => x.ActivityLogID);
                    table.ForeignKey(
                        name: "FK__ActivityL__TaskI__47DBAE45",
                        column: x => x.TaskID,
                        principalTable: "Task",
                        principalColumn: "TaskID");
                    table.ForeignKey(
                        name: "FK__ActivityL__UserI__48CFD27E",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    CommentID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommentCode = table.Column<long>(type: "bigint", nullable: true),
                    CommentContent = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    TaskID = table.Column<long>(type: "bigint", nullable: false),
                    ProjectID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.CommentID);
                    table.ForeignKey(
                        name: "FK__Comment__Project__44FF419A",
                        column: x => x.ProjectID,
                        principalTable: "Project",
                        principalColumn: "ProjectID");
                    table.ForeignKey(
                        name: "FK__Comment__TaskID__440B1D61",
                        column: x => x.TaskID,
                        principalTable: "Task",
                        principalColumn: "TaskID");
                    table.ForeignKey(
                        name: "FK__Comment__UserID__4316F928",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActivityLog_TaskID",
                table: "ActivityLog",
                column: "TaskID");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityLog_UserID",
                table: "ActivityLog",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_ProjectID",
                table: "Comment",
                column: "ProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_TaskID",
                table: "Comment",
                column: "TaskID");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_UserID",
                table: "Comment",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Task_ProjectID",
                table: "Task",
                column: "ProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_Task_UserID",
                table: "Task",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActivityLog");

            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "ProjectAssigned");

            migrationBuilder.DropTable(
                name: "TaskAssigned");

            migrationBuilder.DropTable(
                name: "Task");

            migrationBuilder.DropTable(
                name: "Project");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
