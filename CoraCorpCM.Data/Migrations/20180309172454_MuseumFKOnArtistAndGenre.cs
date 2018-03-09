using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CoraCorpCM.Data.Migrations
{
    public partial class MuseumFKOnArtistAndGenre : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Artists_Museums_MuseumId",
                table: "Artists");

            migrationBuilder.DropForeignKey(
                name: "FK_Genres_Museums_MuseumId",
                table: "Genres");

            migrationBuilder.AlterColumn<int>(
                name: "MuseumId",
                table: "Genres",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MuseumId",
                table: "Artists",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Artists_Museums_MuseumId",
                table: "Artists",
                column: "MuseumId",
                principalTable: "Museums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Genres_Museums_MuseumId",
                table: "Genres",
                column: "MuseumId",
                principalTable: "Museums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Artists_Museums_MuseumId",
                table: "Artists");

            migrationBuilder.DropForeignKey(
                name: "FK_Genres_Museums_MuseumId",
                table: "Genres");

            migrationBuilder.AlterColumn<int>(
                name: "MuseumId",
                table: "Genres",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "MuseumId",
                table: "Artists",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Artists_Museums_MuseumId",
                table: "Artists",
                column: "MuseumId",
                principalTable: "Museums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Genres_Museums_MuseumId",
                table: "Genres",
                column: "MuseumId",
                principalTable: "Museums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
