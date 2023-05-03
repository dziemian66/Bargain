using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bargain.Infrastructure.Migrations
{
    public partial class AddUserRatingLikeAndUserRatingDislike : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserRating");

            migrationBuilder.CreateTable(
                name: "UserRatingDislike",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RatingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRatingDislike", x => new { x.UserId, x.RatingId });
                    table.ForeignKey(
                        name: "FK_UserRatingDislike_Ratings_RatingId",
                        column: x => x.RatingId,
                        principalTable: "Ratings",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserRatingDislike_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserRatingLike",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RatingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRatingLike", x => new { x.UserId, x.RatingId });
                    table.ForeignKey(
                        name: "FK_UserRatingLike_Ratings_RatingId",
                        column: x => x.RatingId,
                        principalTable: "Ratings",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserRatingLike_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserRatingDislike_RatingId",
                table: "UserRatingDislike",
                column: "RatingId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRatingLike_RatingId",
                table: "UserRatingLike",
                column: "RatingId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserRatingDislike");

            migrationBuilder.DropTable(
                name: "UserRatingLike");

            migrationBuilder.CreateTable(
                name: "UserRating",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RatingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRating", x => new { x.UserId, x.RatingId });
                    table.ForeignKey(
                        name: "FK_UserRating_Ratings_RatingId",
                        column: x => x.RatingId,
                        principalTable: "Ratings",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserRating_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserRating_RatingId",
                table: "UserRating",
                column: "RatingId");
        }
    }
}
