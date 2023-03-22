using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CafeStoreManagement.Migrations
{
    public partial class @in : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Total",
                table: "ReceiptReportModels",
                newName: "Amount");

            migrationBuilder.AlterColumn<string>(
                name: "Cashier",
                table: "ReceiptReportModels",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "ReceiptReportModels",
                newName: "Total");

            migrationBuilder.AlterColumn<string>(
                name: "Cashier",
                table: "ReceiptReportModels",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
