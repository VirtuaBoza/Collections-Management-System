using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CoraCorpCM.Data.Migrations
{
    public partial class MuseumFKOnArtistGenre : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArtistGenre_Artists_ArtistId",
                table: "ArtistGenre");

            migrationBuilder.DropForeignKey(
                name: "FK_ArtistGenre_Genres_GenreId",
                table: "ArtistGenre");

            migrationBuilder.AddColumn<int>(
                name: "MuseumId",
                table: "ArtistGenre",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ArtistGenre_MuseumId",
                table: "ArtistGenre",
                column: "MuseumId");

            migrationBuilder.AddForeignKey(
                name: "FK_ArtistGenre_Artists_ArtistId",
                table: "ArtistGenre",
                column: "ArtistId",
                principalTable: "Artists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ArtistGenre_Genres_GenreId",
                table: "ArtistGenre",
                column: "GenreId",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ArtistGenre_Museums_MuseumId",
                table: "ArtistGenre",
                column: "MuseumId",
                principalTable: "Museums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArtistGenre_Artists_ArtistId",
                table: "ArtistGenre");

            migrationBuilder.DropForeignKey(
                name: "FK_ArtistGenre_Genres_GenreId",
                table: "ArtistGenre");

            migrationBuilder.DropForeignKey(
                name: "FK_ArtistGenre_Museums_MuseumId",
                table: "ArtistGenre");

            migrationBuilder.DropIndex(
                name: "IX_ArtistGenre_MuseumId",
                table: "ArtistGenre");

            migrationBuilder.DropColumn(
                name: "MuseumId",
                table: "ArtistGenre");

            migrationBuilder.AddForeignKey(
                name: "FK_ArtistGenre_Artists_ArtistId",
                table: "ArtistGenre",
                column: "ArtistId",
                principalTable: "Artists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ArtistGenre_Genres_GenreId",
                table: "ArtistGenre",
                column: "GenreId",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
