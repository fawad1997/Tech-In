using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Tech_In.Migrations
{
    public partial class test2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_City_Country_CountryID",
                table: "City");

            migrationBuilder.RenameColumn(
                name: "CountryID",
                table: "Country",
                newName: "CountryId");

            migrationBuilder.RenameColumn(
                name: "CountryID",
                table: "City",
                newName: "CountryId");

            migrationBuilder.RenameColumn(
                name: "CityID",
                table: "City",
                newName: "CityId");

            migrationBuilder.RenameIndex(
                name: "IX_City_CountryID",
                table: "City",
                newName: "IX_City_CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_City_Country_CountryId",
                table: "City",
                column: "CountryId",
                principalTable: "Country",
                principalColumn: "CountryId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_City_Country_CountryId",
                table: "City");

            migrationBuilder.RenameColumn(
                name: "CountryId",
                table: "Country",
                newName: "CountryID");

            migrationBuilder.RenameColumn(
                name: "CountryId",
                table: "City",
                newName: "CountryID");

            migrationBuilder.RenameColumn(
                name: "CityId",
                table: "City",
                newName: "CityID");

            migrationBuilder.RenameIndex(
                name: "IX_City_CountryId",
                table: "City",
                newName: "IX_City_CountryID");

            migrationBuilder.AddForeignKey(
                name: "FK_City_Country_CountryID",
                table: "City",
                column: "CountryID",
                principalTable: "Country",
                principalColumn: "CountryID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
