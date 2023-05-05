using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Labs.Migrations
{
    public partial class SettingCouloms : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Settings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ContactNumber",
                table: "Settings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastPanner",
                table: "Settings",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "ContactNumber",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "LastPanner",
                table: "Settings");
        }
    }
}
