using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mswebapiserver.Migrations
{
    public partial class FeedColoumnUpdateMigration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "imageUrl",
                table: "UserFeeds");

            migrationBuilder.AddColumn<int>(
                name: "UserFeedid",
                table: "ImageGallery",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ImageGallery_UserFeedid",
                table: "ImageGallery",
                column: "UserFeedid");

            migrationBuilder.AddForeignKey(
                name: "FK_ImageGallery_UserFeeds_UserFeedid",
                table: "ImageGallery",
                column: "UserFeedid",
                principalTable: "UserFeeds",
                principalColumn: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImageGallery_UserFeeds_UserFeedid",
                table: "ImageGallery");

            migrationBuilder.DropIndex(
                name: "IX_ImageGallery_UserFeedid",
                table: "ImageGallery");

            migrationBuilder.DropColumn(
                name: "UserFeedid",
                table: "ImageGallery");

            migrationBuilder.AddColumn<string>(
                name: "imageUrl",
                table: "UserFeeds",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
