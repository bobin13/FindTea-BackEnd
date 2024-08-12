using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FindTeaBackEnd.Migrations
{
    /// <inheritdoc />
    public partial class AddedDrinksRating : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "address_hint",
                table: "Stores",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "thumbnailURL",
                table: "Stores",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Drinkid",
                table: "Ratings",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "user_id",
                table: "Ratings",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Storeid",
                table: "Drinks",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_Drinkid",
                table: "Ratings",
                column: "Drinkid");

            migrationBuilder.CreateIndex(
                name: "IX_Drinks_Storeid",
                table: "Drinks",
                column: "Storeid");

            migrationBuilder.AddForeignKey(
                name: "FK_Drinks_Stores_Storeid",
                table: "Drinks",
                column: "Storeid",
                principalTable: "Stores",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_Drinks_Drinkid",
                table: "Ratings",
                column: "Drinkid",
                principalTable: "Drinks",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Drinks_Stores_Storeid",
                table: "Drinks");

            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_Drinks_Drinkid",
                table: "Ratings");

            migrationBuilder.DropIndex(
                name: "IX_Ratings_Drinkid",
                table: "Ratings");

            migrationBuilder.DropIndex(
                name: "IX_Drinks_Storeid",
                table: "Drinks");

            migrationBuilder.DropColumn(
                name: "address_hint",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "thumbnailURL",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "Drinkid",
                table: "Ratings");

            migrationBuilder.DropColumn(
                name: "user_id",
                table: "Ratings");

            migrationBuilder.DropColumn(
                name: "Storeid",
                table: "Drinks");
        }
    }
}
