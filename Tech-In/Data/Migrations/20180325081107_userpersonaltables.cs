using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Tech_In.Data.Migrations
{
    public partial class userpersonaltables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MyProperty_Cities_CityID",
                table: "MyProperty");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MyProperty",
                table: "MyProperty");

            migrationBuilder.RenameTable(
                name: "MyProperty",
                newName: "UserPersonalDetails");

            migrationBuilder.RenameIndex(
                name: "IX_MyProperty_CityID",
                table: "UserPersonalDetails",
                newName: "IX_UserPersonalDetails_CityID");

            migrationBuilder.AlterColumn<int>(
                name: "CityID",
                table: "UserPersonalDetails",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "CVImage",
                table: "UserPersonalDetails",
                nullable: true);

            migrationBuilder.AddColumn<short>(
                name: "DOBVisibility",
                table: "UserPersonalDetails",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<short>(
                name: "EmailVisibility",
                table: "UserPersonalDetails",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<short>(
                name: "PhonoNoVisibility",
                table: "UserPersonalDetails",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserPersonalDetails",
                table: "UserPersonalDetails",
                column: "UserPersonalDetailID");

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    CompanyID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CompanyName = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.CompanyID);
                });

            migrationBuilder.CreateTable(
                name: "UserEducations",
                columns: table => new
                {
                    UserEducationID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CityID = table.Column<int>(nullable: false),
                    CurrentStatusCheck = table.Column<bool>(nullable: false),
                    Details = table.Column<string>(maxLength: 200, nullable: true),
                    EduFrom = table.Column<DateTime>(nullable: false),
                    EduTo = table.Column<DateTime>(nullable: false),
                    SchoolName = table.Column<string>(maxLength: 100, nullable: false),
                    Title = table.Column<string>(maxLength: 50, nullable: false),
                    UserID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserEducations", x => x.UserEducationID);
                    table.ForeignKey(
                        name: "FK_UserEducations_Cities_CityID",
                        column: x => x.CityID,
                        principalTable: "Cities",
                        principalColumn: "CityID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserExperiences",
                columns: table => new
                {
                    UserExperienceID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CityID = table.Column<int>(nullable: false),
                    CompanyID = table.Column<int>(nullable: false),
                    CompanyName = table.Column<string>(maxLength: 100, nullable: true),
                    CurrentStatus = table.Column<bool>(nullable: false),
                    Description = table.Column<string>(maxLength: 200, nullable: true),
                    ExpFrom = table.Column<DateTime>(nullable: false),
                    ExpTo = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(maxLength: 50, nullable: false),
                    UserID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserExperiences", x => x.UserExperienceID);
                    table.ForeignKey(
                        name: "FK_UserExperiences_Cities_CityID",
                        column: x => x.CityID,
                        principalTable: "Cities",
                        principalColumn: "CityID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserExperiences_Companies_CompanyID",
                        column: x => x.CompanyID,
                        principalTable: "Companies",
                        principalColumn: "CompanyID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserEducations_CityID",
                table: "UserEducations",
                column: "CityID");

            migrationBuilder.CreateIndex(
                name: "IX_UserExperiences_CityID",
                table: "UserExperiences",
                column: "CityID");

            migrationBuilder.CreateIndex(
                name: "IX_UserExperiences_CompanyID",
                table: "UserExperiences",
                column: "CompanyID");

            migrationBuilder.AddForeignKey(
                name: "FK_UserPersonalDetails_Cities_CityID",
                table: "UserPersonalDetails",
                column: "CityID",
                principalTable: "Cities",
                principalColumn: "CityID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserPersonalDetails_Cities_CityID",
                table: "UserPersonalDetails");

            migrationBuilder.DropTable(
                name: "UserEducations");

            migrationBuilder.DropTable(
                name: "UserExperiences");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserPersonalDetails",
                table: "UserPersonalDetails");

            migrationBuilder.DropColumn(
                name: "CVImage",
                table: "UserPersonalDetails");

            migrationBuilder.DropColumn(
                name: "DOBVisibility",
                table: "UserPersonalDetails");

            migrationBuilder.DropColumn(
                name: "EmailVisibility",
                table: "UserPersonalDetails");

            migrationBuilder.DropColumn(
                name: "PhonoNoVisibility",
                table: "UserPersonalDetails");

            migrationBuilder.RenameTable(
                name: "UserPersonalDetails",
                newName: "MyProperty");

            migrationBuilder.RenameIndex(
                name: "IX_UserPersonalDetails_CityID",
                table: "MyProperty",
                newName: "IX_MyProperty_CityID");

            migrationBuilder.AlterColumn<int>(
                name: "CityID",
                table: "MyProperty",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddPrimaryKey(
                name: "PK_MyProperty",
                table: "MyProperty",
                column: "UserPersonalDetailID");

            migrationBuilder.AddForeignKey(
                name: "FK_MyProperty_Cities_CityID",
                table: "MyProperty",
                column: "CityID",
                principalTable: "Cities",
                principalColumn: "CityID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
