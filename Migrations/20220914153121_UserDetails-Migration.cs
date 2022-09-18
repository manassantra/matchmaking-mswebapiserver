using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mswebapiserver.Migrations
{
    public partial class UserDetailsMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserEducationDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userRefId = table.Column<int>(type: "int", nullable: false),
                    heighestQualification = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    instituteName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    instituteLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    passOutDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    createdDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserEducationDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserFamilyDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userRefId = table.Column<int>(type: "int", nullable: false),
                    fathersName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    mothersName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    familyType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    noOfBrothers = table.Column<int>(type: "int", nullable: false),
                    noOfSisters = table.Column<int>(type: "int", nullable: false),
                    nativePlace = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    createdDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFamilyDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserJobDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userRefId = table.Column<int>(type: "int", nullable: false),
                    JobTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JobType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    companyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    salaryDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    jobLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    jobStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    createdDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserJobDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserMatches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user1Id = table.Column<int>(type: "int", nullable: false),
                    user1Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    user1Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    user2Id = table.Column<int>(type: "int", nullable: false),
                    user2Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    user2Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    agentId = table.Column<int>(type: "int", nullable: false),
                    isMatchedSuccessfull = table.Column<bool>(type: "bit", nullable: false),
                    isMatched = table.Column<bool>(type: "bit", nullable: false),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    matchRequestby = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserMatches", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserPersonalDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userRefId = table.Column<int>(type: "int", nullable: false),
                    maritalStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sunSign = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    bloodGroup = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    height = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    age = table.Column<int>(type: "int", nullable: false),
                    dob = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dite = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    grewUpLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPersonalDetails", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserEducationDetails");

            migrationBuilder.DropTable(
                name: "UserFamilyDetails");

            migrationBuilder.DropTable(
                name: "UserJobDetails");

            migrationBuilder.DropTable(
                name: "UserMatches");

            migrationBuilder.DropTable(
                name: "UserPersonalDetails");
        }
    }
}
