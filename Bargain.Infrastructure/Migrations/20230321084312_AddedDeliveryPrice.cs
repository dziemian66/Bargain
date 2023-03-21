using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bargain.Infrastructure.Migrations
{
    public partial class AddedDeliveryPrice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "DeliveryPrice",
                table: "Items",
                type: "decimal(4,2)",
                precision: 4,
                scale: 2,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeliveryPrice",
                table: "Items");
        }
    }
}
