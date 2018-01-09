using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CoraCorpCM.Migrations
{
    public partial class AddAddressToMuseum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Museums_Location_LocationId",
                table: "Museums");

            migrationBuilder.DropIndex(
                name: "IX_Museums_LocationId",
                table: "Museums");

            migrationBuilder.RenameColumn(
                name: "LocationId",
                table: "Museums",
                newName: "CountryId");

            migrationBuilder.AddColumn<string>(
                name: "Address1",
                table: "Museums",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address2",
                table: "Museums",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Museums",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "Museums",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ZipCode",
                table: "Museums",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MuseumId",
                table: "Location",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Museums_CountryId",
                table: "Museums",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Location_MuseumId",
                table: "Location",
                column: "MuseumId");

            migrationBuilder.AddForeignKey(
                name: "FK_Location_Museums_MuseumId",
                table: "Location",
                column: "MuseumId",
                principalTable: "Museums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Museums_Countries_CountryId",
                table: "Museums",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Location_Museums_MuseumId",
                table: "Location");

            migrationBuilder.DropForeignKey(
                name: "FK_Museums_Countries_CountryId",
                table: "Museums");

            migrationBuilder.DropIndex(
                name: "IX_Museums_CountryId",
                table: "Museums");

            migrationBuilder.DropIndex(
                name: "IX_Location_MuseumId",
                table: "Location");

            migrationBuilder.DropColumn(
                name: "Address1",
                table: "Museums");

            migrationBuilder.DropColumn(
                name: "Address2",
                table: "Museums");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Museums");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Museums");

            migrationBuilder.DropColumn(
                name: "ZipCode",
                table: "Museums");

            migrationBuilder.DropColumn(
                name: "MuseumId",
                table: "Location");

            migrationBuilder.RenameColumn(
                name: "CountryId",
                table: "Museums",
                newName: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Museums_LocationId",
                table: "Museums",
                column: "LocationId",
                unique: true,
                filter: "[LocationId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Museums_Location_LocationId",
                table: "Museums",
                column: "LocationId",
                principalTable: "Location",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
