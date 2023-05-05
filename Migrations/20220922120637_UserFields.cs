using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Labs.Migrations
{
    public partial class UserFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
        }
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");
        }
    }
}
