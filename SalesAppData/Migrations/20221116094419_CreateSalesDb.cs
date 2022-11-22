using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SalesAppData.Migrations
{
    public partial class CreateSalesDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    product_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "100, 1"),
                    product_Brand = table.Column<string>(type: "varchar(50)", nullable: false),
                    product_ModelName = table.Column<string>(type: "varchar(50)", nullable: false),
                    product_description = table.Column<string>(type: "varchar(max)", nullable: true),
                    product_Receiving_Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0.0m),
                    product_price = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0.0m),
                    product_image_url = table.Column<string>(type: "varchar(max)", nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.product_id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "products");
        }
    }
}
