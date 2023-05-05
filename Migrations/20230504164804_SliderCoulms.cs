using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Labs.Migrations
{
    public partial class SliderCoulms : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ImageName",
                table: "TbSlider",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AddColumn<string>(
                name: "CreateBy",
                table: "TbSlider",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "TbSlider",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CurrentState",
                table: "TbSlider",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UpdateBy",
                table: "TbSlider",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "TbSlider",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateBy",
                table: "TbSlider");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "TbSlider");

            migrationBuilder.DropColumn(
                name: "CurrentState",
                table: "TbSlider");

            migrationBuilder.DropColumn(
                name: "UpdateBy",
                table: "TbSlider");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "TbSlider");

            migrationBuilder.AlterColumn<string>(
                name: "ImageName",
                table: "TbSlider",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);
        }
    }
}
