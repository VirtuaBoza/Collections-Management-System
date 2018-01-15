using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CoraCorpCM.Migrations
{
    public partial class ManyPieceToOneArtist : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PieceArtist");

            migrationBuilder.AddColumn<int>(
                name: "ArtistId",
                table: "Pieces",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pieces_ArtistId",
                table: "Pieces",
                column: "ArtistId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pieces_Artists_ArtistId",
                table: "Pieces",
                column: "ArtistId",
                principalTable: "Artists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pieces_Artists_ArtistId",
                table: "Pieces");

            migrationBuilder.DropIndex(
                name: "IX_Pieces_ArtistId",
                table: "Pieces");

            migrationBuilder.DropColumn(
                name: "ArtistId",
                table: "Pieces");

            migrationBuilder.CreateTable(
                name: "PieceArtist",
                columns: table => new
                {
                    PieceId = table.Column<int>(nullable: false),
                    ArtistId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PieceArtist", x => new { x.PieceId, x.ArtistId });
                    table.ForeignKey(
                        name: "FK_PieceArtist_Artists_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PieceArtist_Pieces_PieceId",
                        column: x => x.PieceId,
                        principalTable: "Pieces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PieceArtist_ArtistId",
                table: "PieceArtist",
                column: "ArtistId");
        }
    }
}
