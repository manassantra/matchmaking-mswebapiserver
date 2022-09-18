using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mswebapiserver.Migrations
{
    public partial class UserDetailsv251Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "userRefId",
                table: "UserReligions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "userRefId",
                table: "PartnerPreferances",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "userRefId",
                table: "UserReligions");

            migrationBuilder.DropColumn(
                name: "userRefId",
                table: "PartnerPreferances");
        }
    }
}
