using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CafeStoreManagement.Migrations
{
    public partial class init1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MenuGroup",
                table: "MenuGroup");

            migrationBuilder.RenameTable(
                name: "MenuGroup",
                newName: "tblMenuGroup");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "tblMenuGroup",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "tblMenuGroup",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblMenuGroup",
                table: "tblMenuGroup",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_tblMenuGroup",
                table: "tblMenuGroup");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "tblMenuGroup");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "tblMenuGroup");

            migrationBuilder.RenameTable(
                name: "tblMenuGroup",
                newName: "MenuGroup");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MenuGroup",
                table: "MenuGroup",
                column: "Id");
        }
    }
}
