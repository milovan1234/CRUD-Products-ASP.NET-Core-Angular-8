using Microsoft.EntityFrameworkCore.Migrations;

namespace CRUDProducts.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(nullable: true),
                    Price = table.Column<double>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Price", "ProductName" },
                values: new object[] { 1, "AMD Ryzen 5, 8GB DDR4 2400 MHz, 240GB SSD, GeForce GTX 1650", 55000.0, "GIGATRON PRIME R16008G240S16504G" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Price", "ProductName" },
                values: new object[] { 2, "AMD Ryzen 5, 8GB DDR4 2666 MHz, 240GB SSD, AMD Radeon RX 570", 58000.0, "GIGATRON PRIME LIDER MASTERBOX X" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
