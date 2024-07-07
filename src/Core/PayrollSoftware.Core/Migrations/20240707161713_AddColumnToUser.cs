using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PayrollSoftware.Core.Migrations
{
    public partial class AddColumnToUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Project",
                keyColumn: "ProjectID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 7, 7, 23, 10, 30, 993, DateTimeKind.Local).AddTicks(7880));

            migrationBuilder.UpdateData(
                table: "Project",
                keyColumn: "ProjectID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 7, 7, 23, 10, 30, 993, DateTimeKind.Local).AddTicks(7910));

            migrationBuilder.UpdateData(
                table: "Project",
                keyColumn: "ProjectID",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 7, 7, 23, 10, 30, 993, DateTimeKind.Local).AddTicks(7914));

            migrationBuilder.UpdateData(
                table: "Project",
                keyColumn: "ProjectID",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 7, 7, 23, 10, 30, 993, DateTimeKind.Local).AddTicks(7917));
        }
    }
}
