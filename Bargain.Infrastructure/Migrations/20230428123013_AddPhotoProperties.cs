using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bargain.Infrastructure.Migrations
{
    public partial class AddPhotoProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photos_Items_ItemId",
                table: "Photos");

            migrationBuilder.AlterColumn<int>(
                name: "ItemId",
                table: "Photos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<long>(
                name: "FileSize",
                table: "Photos",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "FileType",
                table: "Photos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ShopRef",
                table: "Photos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UploaderId",
                table: "Photos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserRef",
                table: "Photos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Photos_ShopRef",
                table: "Photos",
                column: "ShopRef",
                unique: true,
                filter: "[ShopRef] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Photos_UploaderId",
                table: "Photos",
                column: "UploaderId");

            migrationBuilder.CreateIndex(
                name: "IX_Photos_UserRef",
                table: "Photos",
                column: "UserRef",
                unique: true,
                filter: "[UserRef] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_Items_ItemId",
                table: "Photos",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_Shops_ShopRef",
                table: "Photos",
                column: "ShopRef",
                principalTable: "Shops",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_Users_UploaderId",
                table: "Photos",
                column: "UploaderId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_Users_UserRef",
                table: "Photos",
                column: "UserRef",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photos_Items_ItemId",
                table: "Photos");

            migrationBuilder.DropForeignKey(
                name: "FK_Photos_Shops_ShopRef",
                table: "Photos");

            migrationBuilder.DropForeignKey(
                name: "FK_Photos_Users_UploaderId",
                table: "Photos");

            migrationBuilder.DropForeignKey(
                name: "FK_Photos_Users_UserRef",
                table: "Photos");

            migrationBuilder.DropIndex(
                name: "IX_Photos_ShopRef",
                table: "Photos");

            migrationBuilder.DropIndex(
                name: "IX_Photos_UploaderId",
                table: "Photos");

            migrationBuilder.DropIndex(
                name: "IX_Photos_UserRef",
                table: "Photos");

            migrationBuilder.DropColumn(
                name: "FileSize",
                table: "Photos");

            migrationBuilder.DropColumn(
                name: "FileType",
                table: "Photos");

            migrationBuilder.DropColumn(
                name: "ShopRef",
                table: "Photos");

            migrationBuilder.DropColumn(
                name: "UploaderId",
                table: "Photos");

            migrationBuilder.DropColumn(
                name: "UserRef",
                table: "Photos");

            migrationBuilder.AlterColumn<int>(
                name: "ItemId",
                table: "Photos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_Items_ItemId",
                table: "Photos",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
