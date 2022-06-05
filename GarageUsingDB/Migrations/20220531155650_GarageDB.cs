using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GarageUsingDB.Migrations
{
    public partial class GarageDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "peoples",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Unique", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_peoples", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "cars",
                columns: table => new
                {
                    LicensePlate = table.Column<int>(type: "int", maxLength: 10, nullable: false)
                    .Annotation("SqlServer:Unique", "1"),//chack how to make unique
                    OwnerId = table.Column<int>(type: "int", nullable: false),
                    Manufacturer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cars", x => x.LicensePlate);
                    table.ForeignKey("FK_cars", x => x.OwnerId, "peoples");
                }
                );

            migrationBuilder.CreateTable(
                name: "Garage",
                columns: table => new
                {
                    ReferenceNumber = table.Column<int>(type: "int", maxLength: 8, nullable: false)
                        .Annotation("SqlServer:Identity", "6000000, 1"),
                    LicensePlate = table.Column<int>(type: "int", nullable: false),
                    OwnerId = table.Column<int>(type: "int", nullable: false),
                    OwnerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsFixed = table.Column<bool>(type: "bit", nullable: false),
                    CostToFix = table.Column<double>(type: "float", nullable: false),
                    EnteredGarage = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Garage", x => x.ReferenceNumber);
                    table.ForeignKey("FK_Garage", x => x.LicensePlate, "cars");
                });

        }


        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cars");

            migrationBuilder.DropTable(
                name: "Garage");

            migrationBuilder.DropTable(
                name: "peoples");
        }
    }
}
