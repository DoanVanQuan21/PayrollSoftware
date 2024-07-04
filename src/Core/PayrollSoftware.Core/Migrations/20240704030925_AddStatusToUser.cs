using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PayrollSoftware.Core.Migrations
{
    public partial class AddStatusToUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "User",
                type: "nvarchar(100)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "User");
        }
    }
}
