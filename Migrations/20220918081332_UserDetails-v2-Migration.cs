using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mswebapiserver.Migrations
{
    public partial class UserDetailsv2Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "canSpeak",
                table: "UserPersonalDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "motherToung",
                table: "UserPersonalDetails",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "canSpeak",
                table: "UserPersonalDetails");

            migrationBuilder.DropColumn(
                name: "motherToung",
                table: "UserPersonalDetails");
        }
    }
}
