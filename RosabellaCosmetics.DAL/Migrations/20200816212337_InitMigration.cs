using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RosabellaCosmetics.Dal.Migrations
{
    public partial class InitMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "DateTime", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "DateTime", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "DateTime", nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Email = table.Column<string>(type: "varchar(62)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(128)", nullable: false),
                    PasswordSalt = table.Column<string>(type: "nvarchar(128)", nullable: false),
                    Country = table.Column<string>(nullable: false),
                    City = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "DateTime", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "DateTime", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "DateTime", nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Price = table.Column<decimal>(nullable: false, defaultValue: 0m),
                    QuantityInStock = table.Column<int>(nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
