using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CoraCorpCM.Migrations
{
    public partial class ConsolidateArtistName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Artists");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Artists",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "KnownAs",
                table: "Artists",
                newName: "AlsoKnownAs");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Artists",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "AlsoKnownAs",
                table: "Artists",
                newName: "KnownAs");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Artists",
                nullable: true);
        }
    }
}
