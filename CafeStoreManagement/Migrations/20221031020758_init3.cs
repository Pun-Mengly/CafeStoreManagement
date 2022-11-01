using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CafeStoreManagement.Migrations
{
    public partial class init3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "tblChannel",
                keyColumn: "Id",
                keyValue: new Guid("37ac59ac-a129-4dbf-b99b-cac975a2664b"));

            migrationBuilder.DeleteData(
                table: "tblChannel",
                keyColumn: "Id",
                keyValue: new Guid("55fa8a55-fc85-434c-b085-c473d5a068f4"));

            migrationBuilder.DeleteData(
                table: "tblChannel",
                keyColumn: "Id",
                keyValue: new Guid("902bf2bc-7597-4497-865b-4e52b75353df"));

            migrationBuilder.DeleteData(
                table: "tblSource",
                keyColumn: "Id",
                keyValue: new Guid("3680c0ab-d44f-423c-a586-a89e6a843158"));

            migrationBuilder.DeleteData(
                table: "tblSource",
                keyColumn: "Id",
                keyValue: new Guid("6f3e73d8-6d42-4756-88b1-3aac3c949367"));

            migrationBuilder.DeleteData(
                table: "tblSource",
                keyColumn: "Id",
                keyValue: new Guid("cb457c33-3337-4541-a8ff-035375f8f5f0"));

            migrationBuilder.DeleteData(
                table: "tblTax",
                keyColumn: "Id",
                keyValue: new Guid("4905adfb-e7c0-4c0c-8722-dca322db2844"));

            migrationBuilder.DeleteData(
                table: "tblTax",
                keyColumn: "Id",
                keyValue: new Guid("710e0000-ff1f-427c-8468-4f8fdd8e571e"));

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "tblMenuGroup",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "tblCategory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MenuGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblItem",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Photo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblItem", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblSize",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblSize", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "tblCategory",
                columns: new[] { "Id", "Code", "CreatedBy", "CreatedDate", "Description", "IsDeleted", "MenuGroupId", "Name" },
                values: new object[,]
                {
                    { new Guid("51b79009-adbb-470e-a76b-e152e31db02d"), "CAF", "Default user", new DateTime(2022, 10, 31, 9, 7, 57, 810, DateTimeKind.Local).AddTicks(8446), "Generarted by System", false, new Guid("00000000-0000-0000-0000-000000000000"), "Coffee" },
                    { new Guid("6b3a6e40-5392-46dd-bfee-c03bb8618076"), "SMT", "Default user", new DateTime(2022, 10, 31, 9, 7, 57, 810, DateTimeKind.Local).AddTicks(8430), "Generarted by System", false, new Guid("00000000-0000-0000-0000-000000000000"), "Smoothie" },
                    { new Guid("847f2ac7-56e1-4fcb-be9d-d8bc3ef5ed21"), "MIT", "Default user", new DateTime(2022, 10, 31, 9, 7, 57, 810, DateTimeKind.Local).AddTicks(8444), "Generarted by System", false, new Guid("00000000-0000-0000-0000-000000000000"), "Milk Tea" }
                });

            migrationBuilder.InsertData(
                table: "tblChannel",
                columns: new[] { "Id", "Abv", "Code", "CreatedBy", "CreatedDate", "Description", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { new Guid("1385cae1-efeb-46dc-a9e5-38c378297cce"), "DIN", "DIN", "Default user", new DateTime(2022, 10, 31, 9, 7, 57, 811, DateTimeKind.Local).AddTicks(5811), "Generarted by System", false, "Dine In" },
                    { new Guid("20451b43-686f-4824-8fef-e45e8aef005a"), "TAK", "TAK", "Default user", new DateTime(2022, 10, 31, 9, 7, 57, 811, DateTimeKind.Local).AddTicks(5818), "Generarted by System", false, "Take Away" },
                    { new Guid("55b5e379-162d-4d52-a622-77f74bbef110"), "DEL", "DEL", "Default user", new DateTime(2022, 10, 31, 9, 7, 57, 811, DateTimeKind.Local).AddTicks(5820), "Generarted by System", false, "Delivery" }
                });

            migrationBuilder.InsertData(
                table: "tblMenuGroup",
                columns: new[] { "Id", "Abv", "Code", "CreatedBy", "CreatedDate", "Description", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { new Guid("3c6abf17-a529-4931-b86f-a2c930965584"), "DRK", "DRK", "Default user", new DateTime(2022, 10, 31, 9, 7, 57, 815, DateTimeKind.Local).AddTicks(2007), "Generarted by System", false, "Drink" },
                    { new Guid("d2d64ba4-d3ac-4922-9027-0a965c2576a8"), "FOD", "FOD", "Default user", new DateTime(2022, 10, 31, 9, 7, 57, 815, DateTimeKind.Local).AddTicks(2014), "Generarted by System", false, "Food" }
                });

            migrationBuilder.InsertData(
                table: "tblSize",
                columns: new[] { "Id", "Code", "CreatedBy", "CreatedDate", "Description", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { new Guid("148b0b36-93ea-4ef9-a397-c1dabaeec71e"), "S", "Default user", new DateTime(2022, 10, 31, 9, 7, 57, 812, DateTimeKind.Local).AddTicks(9936), "Generarted by System", false, "Small" },
                    { new Guid("7609b709-3da6-4476-9868-8f145a398ce6"), "L", "Default user", new DateTime(2022, 10, 31, 9, 7, 57, 812, DateTimeKind.Local).AddTicks(9953), "Generarted by System", false, "Large" },
                    { new Guid("cd26c095-9058-4a09-9a19-08d3ee021f60"), "M", "Default user", new DateTime(2022, 10, 31, 9, 7, 57, 812, DateTimeKind.Local).AddTicks(9943), "Generarted by System", false, "Medium" }
                });

            migrationBuilder.InsertData(
                table: "tblSource",
                columns: new[] { "Id", "Abv", "Code", "CreatedBy", "CreatedDate", "Description", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { new Guid("437d1652-03c5-4b52-91dc-50bf81fb8d06"), "MBL", "MBL", "Default user", new DateTime(2022, 10, 31, 9, 7, 57, 813, DateTimeKind.Local).AddTicks(7534), "Generarted by System", false, "Mobile App" },
                    { new Guid("7f47571f-8974-4620-85ab-d4a35e397897"), "FAT", "FAT", "Default user", new DateTime(2022, 10, 31, 9, 7, 57, 813, DateTimeKind.Local).AddTicks(7541), "Generarted by System", false, "Food Aggregator" },
                    { new Guid("f046310e-ee45-416a-bec0-a0cdcb9307cd"), "WAL", "WAL", "Default user", new DateTime(2022, 10, 31, 9, 7, 57, 813, DateTimeKind.Local).AddTicks(7543), "Generarted by System", false, "Walk In" }
                });

            migrationBuilder.InsertData(
                table: "tblTax",
                columns: new[] { "Id", "Code", "CreatedBy", "CreatedDate", "Description", "IsDeleted", "Name", "Percentage" },
                values: new object[,]
                {
                    { new Guid("2fdc304d-9995-43a0-8662-0ec3f79be58b"), "PLT", "Default user", new DateTime(2022, 10, 31, 9, 7, 57, 814, DateTimeKind.Local).AddTicks(4476), "Generarted by System", false, "PLT", 10.0 },
                    { new Guid("b8757f2a-85d7-4ac3-876e-a18387a17ec4"), "VAT", "Default user", new DateTime(2022, 10, 31, 9, 7, 57, 814, DateTimeKind.Local).AddTicks(4481), "Generarted by System", false, "VAT", 10.0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblCategory");

            migrationBuilder.DropTable(
                name: "tblItem");

            migrationBuilder.DropTable(
                name: "tblSize");

            migrationBuilder.DeleteData(
                table: "tblChannel",
                keyColumn: "Id",
                keyValue: new Guid("1385cae1-efeb-46dc-a9e5-38c378297cce"));

            migrationBuilder.DeleteData(
                table: "tblChannel",
                keyColumn: "Id",
                keyValue: new Guid("20451b43-686f-4824-8fef-e45e8aef005a"));

            migrationBuilder.DeleteData(
                table: "tblChannel",
                keyColumn: "Id",
                keyValue: new Guid("55b5e379-162d-4d52-a622-77f74bbef110"));

            migrationBuilder.DeleteData(
                table: "tblMenuGroup",
                keyColumn: "Id",
                keyValue: new Guid("3c6abf17-a529-4931-b86f-a2c930965584"));

            migrationBuilder.DeleteData(
                table: "tblMenuGroup",
                keyColumn: "Id",
                keyValue: new Guid("d2d64ba4-d3ac-4922-9027-0a965c2576a8"));

            migrationBuilder.DeleteData(
                table: "tblSource",
                keyColumn: "Id",
                keyValue: new Guid("437d1652-03c5-4b52-91dc-50bf81fb8d06"));

            migrationBuilder.DeleteData(
                table: "tblSource",
                keyColumn: "Id",
                keyValue: new Guid("7f47571f-8974-4620-85ab-d4a35e397897"));

            migrationBuilder.DeleteData(
                table: "tblSource",
                keyColumn: "Id",
                keyValue: new Guid("f046310e-ee45-416a-bec0-a0cdcb9307cd"));

            migrationBuilder.DeleteData(
                table: "tblTax",
                keyColumn: "Id",
                keyValue: new Guid("2fdc304d-9995-43a0-8662-0ec3f79be58b"));

            migrationBuilder.DeleteData(
                table: "tblTax",
                keyColumn: "Id",
                keyValue: new Guid("b8757f2a-85d7-4ac3-876e-a18387a17ec4"));

            migrationBuilder.DropColumn(
                name: "Code",
                table: "tblMenuGroup");

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
    }
}
