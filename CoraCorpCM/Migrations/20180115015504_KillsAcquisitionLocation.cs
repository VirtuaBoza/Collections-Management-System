using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CoraCorpCM.Migrations
{
    public partial class KillsAcquisitionLocation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Acquisitions_Locations_LocationId",
                table: "Acquisitions");

            migrationBuilder.DropIndex(
                name: "IX_Acquisitions_LocationId",
                table: "Acquisitions");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "Acquisitions");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "Acquisitions",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Acquisitions_LocationId",
                table: "Acquisitions",
                column: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Acquisitions_Locations_LocationId",
                table: "Acquisitions",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
