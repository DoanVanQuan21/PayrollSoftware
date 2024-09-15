using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InnoSoft.Core.Migrations
{
    public partial class AddDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Project",
                columns: new[] { "ProjectID", "CreatedDate", "Descriptions", "Disable", "EndDate", "ProjectCode", "ProjectName", "Status", "UpdateDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 7, 7, 23, 10, 30, 993, DateTimeKind.Local).AddTicks(7880), null, false, null, "PJ001", "XBOOM ATS", "Active", null },
                    { 2, new DateTime(2024, 7, 7, 23, 10, 30, 993, DateTimeKind.Local).AddTicks(7910), null, false, null, "PJ002", "MOONPO ATS", "Active", null },
                    { 3, new DateTime(2024, 7, 7, 23, 10, 30, 993, DateTimeKind.Local).AddTicks(7914), null, false, null, "PJ003", "MARUSYS ATS", "Active", null },
                    { 4, new DateTime(2024, 7, 7, 23, 10, 30, 993, DateTimeKind.Local).AddTicks(7917), null, false, null, "PJ004", "X3/X4 ATS", "Active", null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Project",
                keyColumn: "ProjectID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Project",
                keyColumn: "ProjectID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Project",
                keyColumn: "ProjectID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Project",
                keyColumn: "ProjectID",
                keyValue: 4);
        }
    }
}
