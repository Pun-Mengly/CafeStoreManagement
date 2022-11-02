using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CafeStoreManagement.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "tblTax",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "tblSource",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "tblSize",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "tblMenuGroup",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "tblMenuGroup",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "tblChannel",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "tblCategory",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_tblTax_Code_CreatedBy",
                table: "tblTax",
                columns: new[] { "Code", "CreatedBy" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tblSource_Code_CreatedBy",
                table: "tblSource",
                columns: new[] { "Code", "CreatedBy" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tblSize_Code_CreatedBy",
                table: "tblSize",
                columns: new[] { "Code", "CreatedBy" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tblMenuGroup_Code_CreatedBy",
                table: "tblMenuGroup",
                columns: new[] { "Code", "CreatedBy" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tblChannel_Code_CreatedBy",
                table: "tblChannel",
                columns: new[] { "Code", "CreatedBy" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tblCategory_Code_CreatedBy",
                table: "tblCategory",
                columns: new[] { "Code", "CreatedBy" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_tblTax_Code_CreatedBy",
                table: "tblTax");

            migrationBuilder.DropIndex(
                name: "IX_tblSource_Code_CreatedBy",
                table: "tblSource");

            migrationBuilder.DropIndex(
                name: "IX_tblSize_Code_CreatedBy",
                table: "tblSize");

            migrationBuilder.DropIndex(
                name: "IX_tblMenuGroup_Code_CreatedBy",
                table: "tblMenuGroup");

            migrationBuilder.DropIndex(
                name: "IX_tblChannel_Code_CreatedBy",
                table: "tblChannel");

            migrationBuilder.DropIndex(
                name: "IX_tblCategory_Code_CreatedBy",
                table: "tblCategory");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "tblTax",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "tblSource",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "tblSize",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "tblMenuGroup",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "tblMenuGroup",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "tblChannel",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "tblCategory",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
