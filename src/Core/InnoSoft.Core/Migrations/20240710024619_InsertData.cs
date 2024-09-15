using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InnoSoft.Core.Migrations
{
    public partial class InsertData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Project",
                keyColumn: "ProjectID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 7, 10, 9, 46, 18, 869, DateTimeKind.Local).AddTicks(6325));

            migrationBuilder.UpdateData(
                table: "Project",
                keyColumn: "ProjectID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 7, 10, 9, 46, 18, 869, DateTimeKind.Local).AddTicks(6344));

            migrationBuilder.UpdateData(
                table: "Project",
                keyColumn: "ProjectID",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 7, 10, 9, 46, 18, 869, DateTimeKind.Local).AddTicks(6348));

            migrationBuilder.UpdateData(
                table: "Project",
                keyColumn: "ProjectID",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 7, 10, 9, 46, 18, 869, DateTimeKind.Local).AddTicks(6352));

            migrationBuilder.InsertData(
                table: "Task",
                columns: new[] { "TaskID", "CompletionDate", "CreatedDate", "Description", "DueDate", "Priority", "ProjectID", "StartDate", "Status", "TaskCode", "TaskName", "Type", "UpdatedDate", "UserID" },
                values: new object[,]
                {
                    { 1L, null, new DateTime(2024, 7, 10, 9, 46, 18, 869, DateTimeKind.Local).AddTicks(6384), "Phát triển phần mềm kiểm tra các chức năng của sản phẩm", new DateTime(2024, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "1", 1, null, "Cần làm", "XBOOM_ATS_TASK01", "Phát triển phần mềm XBOOM ATS", "Issue", null, 1 },
                    { 2L, null, new DateTime(2024, 7, 10, 9, 46, 18, 869, DateTimeKind.Local).AddTicks(6397), "Phát triển phần mềm kiểm tra các chức năng của sản phẩm", new DateTime(2024, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "1", 1, null, "Cần làm", "XBOOM_ATS_TASK02", "Phát triển module COMPORT", "Issue", null, 1 },
                    { 3L, null, new DateTime(2024, 7, 10, 9, 46, 18, 869, DateTimeKind.Local).AddTicks(6402), "Phát triển phần mềm kiểm tra các chức năng của sản phẩm", new DateTime(2024, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "1", 1, null, "Cần làm", "XBOOM_ATS_TASK03", "Phát triển module VIDEO", "Issue", null, 1 },
                    { 4L, null, new DateTime(2024, 7, 10, 9, 46, 18, 869, DateTimeKind.Local).AddTicks(6434), "Phát triển phần mềm kiểm tra các chức năng của sản phẩm", new DateTime(2024, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "1", 1, null, "Cần làm", "XBOOM_ATS_TASK04", "Phát triển module DMM", "Issue", null, 1 },
                    { 5L, null, new DateTime(2024, 7, 10, 9, 46, 18, 869, DateTimeKind.Local).AddTicks(6438), "Phát triển phần mềm kiểm tra các chức năng của sản phẩm", new DateTime(2024, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "1", 1, null, "Cần làm", "XBOOM_ATS_TASK05", "Phát triển module AUDIO", "Issue", null, 1 },
                    { 6L, null, new DateTime(2024, 7, 10, 9, 46, 18, 869, DateTimeKind.Local).AddTicks(6444), "Phát triển phần mềm kiểm tra các chức năng của sản phẩm", new DateTime(2024, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "1", 1, null, "Cần làm", "XBOOM_ATS_TASK06", "Phát triển module Data logger", "Issue", null, 1 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Task",
                keyColumn: "TaskID",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Task",
                keyColumn: "TaskID",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Task",
                keyColumn: "TaskID",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Task",
                keyColumn: "TaskID",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Task",
                keyColumn: "TaskID",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "Task",
                keyColumn: "TaskID",
                keyValue: 6L);

            migrationBuilder.UpdateData(
                table: "Project",
                keyColumn: "ProjectID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 7, 7, 23, 17, 13, 580, DateTimeKind.Local).AddTicks(318));

            migrationBuilder.UpdateData(
                table: "Project",
                keyColumn: "ProjectID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 7, 7, 23, 17, 13, 580, DateTimeKind.Local).AddTicks(348));

            migrationBuilder.UpdateData(
                table: "Project",
                keyColumn: "ProjectID",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 7, 7, 23, 17, 13, 580, DateTimeKind.Local).AddTicks(352));

            migrationBuilder.UpdateData(
                table: "Project",
                keyColumn: "ProjectID",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 7, 7, 23, 17, 13, 580, DateTimeKind.Local).AddTicks(356));
        }
    }
}
