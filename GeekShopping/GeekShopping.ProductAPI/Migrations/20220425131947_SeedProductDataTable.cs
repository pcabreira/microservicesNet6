using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeekShopping.ProductAPI.Migrations
{
    public partial class SeedProductDataTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "product",
                columns: new[] { "id", "category", "description", "imageURL", "name", "price" },
                values: new object[] { 2L, "Informatica", "Tela de pc", "https://www.digitalavmagazine.com/wp-content/uploads/2020/08/Philips-279C9.jpg", "Monitor", 1.1m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "id",
                keyValue: 2L);
        }
    }
}
