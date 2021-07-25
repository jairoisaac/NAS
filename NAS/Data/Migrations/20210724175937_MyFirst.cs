using Microsoft.EntityFrameworkCore.Migrations;

namespace NAS.Data.Migrations
{
    public partial class MyFirst : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BasicCosts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Value = table.Column<decimal>(type: "decimal(5, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasicCosts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Comisions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Value = table.Column<decimal>(type: "decimal(5, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comisions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HardDrives",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Manufacturer = table.Column<string>(nullable: true),
                    SKU = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Cost = table.Column<decimal>(type: "decimal(7, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HardDrives", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NASEmptys",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Manufacturer = table.Column<string>(nullable: true),
                    SKU = table.Column<string>(nullable: true),
                    Description = table.Column<string>(maxLength: 600, nullable: true),
                    Cost = table.Column<decimal>(type: "decimal(7, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NASEmptys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Prices",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SKU = table.Column<string>(nullable: true),
                    NASId = table.Column<int>(nullable: false),
                    NAS_EmptyId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prices_NASEmptys_NAS_EmptyId",
                        column: x => x.NAS_EmptyId,
                        principalTable: "NASEmptys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PriceHardDrives",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PriceId = table.Column<int>(nullable: false),
                    HardDriveId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceHardDrives", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PriceHardDrives_HardDrives_HardDriveId",
                        column: x => x.HardDriveId,
                        principalTable: "HardDrives",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PriceHardDrives_Prices_PriceId",
                        column: x => x.PriceId,
                        principalTable: "Prices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PriceHardDrives_HardDriveId",
                table: "PriceHardDrives",
                column: "HardDriveId");

            migrationBuilder.CreateIndex(
                name: "IX_PriceHardDrives_PriceId",
                table: "PriceHardDrives",
                column: "PriceId");

            migrationBuilder.CreateIndex(
                name: "IX_Prices_NAS_EmptyId",
                table: "Prices",
                column: "NAS_EmptyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BasicCosts");

            migrationBuilder.DropTable(
                name: "Comisions");

            migrationBuilder.DropTable(
                name: "PriceHardDrives");

            migrationBuilder.DropTable(
                name: "HardDrives");

            migrationBuilder.DropTable(
                name: "Prices");

            migrationBuilder.DropTable(
                name: "NASEmptys");
        }
    }
}
