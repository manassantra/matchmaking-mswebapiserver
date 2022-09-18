using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mswebapiserver.Migrations
{
    public partial class UserDetailsv25Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PartnerPreferances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    area = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ageFrom = table.Column<int>(type: "int", nullable: false),
                    ageTo = table.Column<int>(type: "int", nullable: false),
                    maritalStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    highetFrom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    highetTo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    religion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    community = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    subCommunity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    gothra = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    canSpeak = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    motherToung = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    jobType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isPremium = table.Column<bool>(type: "bit", nullable: true),
                    modifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartnerPreferances", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserReligions",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    religion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    community = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    subCommunity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    gothra = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    modifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserReligions", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PartnerPreferances");

            migrationBuilder.DropTable(
                name: "UserReligions");
        }
    }
}
