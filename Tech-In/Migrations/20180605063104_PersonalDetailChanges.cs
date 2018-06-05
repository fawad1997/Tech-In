using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Tech_In.Migrations
{
    public partial class PersonalDetailChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserPersonalDetail_City_CityID",
                table: "UserPersonalDetail");

            migrationBuilder.RenameColumn(
                name: "CityID",
                table: "UserPersonalDetail",
                newName: "CityId");

            migrationBuilder.RenameColumn(
                name: "UserPersonalDetailID",
                table: "UserPersonalDetail",
                newName: "UserPersonalDetailId");

            migrationBuilder.RenameIndex(
                name: "IX_UserPersonalDetail_CityID",
                table: "UserPersonalDetail",
                newName: "IX_UserPersonalDetail_CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserPersonalDetail_City_CityId",
                table: "UserPersonalDetail",
                column: "CityId",
                principalTable: "City",
                principalColumn: "CityId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserPersonalDetail_City_CityId",
                table: "UserPersonalDetail");

            migrationBuilder.RenameColumn(
                name: "CityId",
                table: "UserPersonalDetail",
                newName: "CityID");

            migrationBuilder.RenameColumn(
                name: "UserPersonalDetailId",
                table: "UserPersonalDetail",
                newName: "UserPersonalDetailID");

            migrationBuilder.RenameIndex(
                name: "IX_UserPersonalDetail_CityId",
                table: "UserPersonalDetail",
                newName: "IX_UserPersonalDetail_CityID");

            migrationBuilder.AddForeignKey(
                name: "FK_UserPersonalDetail_City_CityID",
                table: "UserPersonalDetail",
                column: "CityID",
                principalTable: "City",
                principalColumn: "CityId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
