using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CafeStoreManagement.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblChannel",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Abv = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblChannel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblSource",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Abv = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblSource", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblTax",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Percentage = table.Column<double>(type: "float", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblTax", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "tblChannel",
                columns: new[] { "Id", "Abv", "Code", "CreatedBy", "CreatedDate", "Description", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { new Guid("37ac59ac-a129-4dbf-b99b-cac975a2664b"), "DEL", "DEL", "Default User", new DateTime(2022, 10, 27, 9, 23, 4, 338, DateTimeKind.Local).AddTicks(9682), "They use delivery for item", false, "Delivery" },
                    { new Guid("55fa8a55-fc85-434c-b085-c473d5a068f4"), "DIN", "DIN", "Default User", new DateTime(2022, 10, 27, 9, 23, 4, 338, DateTimeKind.Local).AddTicks(9670), "They eat inside the store", false, "Dine In" },
                    { new Guid("902bf2bc-7597-4497-865b-4e52b75353df"), "TAK", "TAK", "Default User", new DateTime(2022, 10, 27, 9, 23, 4, 338, DateTimeKind.Local).AddTicks(9681), "They eat outside the store", false, "Take Away" }
                });

            migrationBuilder.InsertData(
                table: "tblSource",
                columns: new[] { "Id", "Abv", "Code", "CreatedBy", "CreatedDate", "Description", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { new Guid("3680c0ab-d44f-423c-a586-a89e6a843158"), "FAT", "FAT", "Default User", new DateTime(2022, 10, 27, 9, 23, 4, 339, DateTimeKind.Local).AddTicks(5107), "The order from Food Aggregator", false, "Food Aggregator" },
                    { new Guid("6f3e73d8-6d42-4756-88b1-3aac3c949367"), "WAL", "WAL", "Default User", new DateTime(2022, 10, 27, 9, 23, 4, 339, DateTimeKind.Local).AddTicks(5109), "The order from Walk In", false, "Walk In" },
                    { new Guid("cb457c33-3337-4541-a8ff-035375f8f5f0"), "MBL", "MBL", "Default User", new DateTime(2022, 10, 27, 9, 23, 4, 339, DateTimeKind.Local).AddTicks(5104), "The order from mobile app", false, "Mobile App" }
                });

            migrationBuilder.InsertData(
                table: "tblTax",
                columns: new[] { "Id", "Code", "CreatedBy", "CreatedDate", "Description", "IsDeleted", "Name", "Percentage" },
                values: new object[,]
                {
                    { new Guid("4905adfb-e7c0-4c0c-8722-dca322db2844"), "PLT", "Default User", new DateTime(2022, 10, 27, 9, 23, 4, 340, DateTimeKind.Local).AddTicks(124), "", false, "PLT", 10.0 },
                    { new Guid("710e0000-ff1f-427c-8468-4f8fdd8e571e"), "VAT", "Default User", new DateTime(2022, 10, 27, 9, 23, 4, 340, DateTimeKind.Local).AddTicks(128), "", false, "VAT", 10.0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblChannel");

            migrationBuilder.DropTable(
                name: "tblSource");

            migrationBuilder.DropTable(
                name: "tblTax");
        }
    }
}
