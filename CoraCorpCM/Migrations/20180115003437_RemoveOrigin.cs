using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CoraCorpCM.Migrations
{
    public partial class RemoveOrigin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Artists_Origin_OriginId",
                table: "Artists");

            migrationBuilder.DropForeignKey(
                name: "FK_Pieces_Origin_CreationOriginId",
                table: "Pieces");

            migrationBuilder.DropTable(
                name: "Origin");

            migrationBuilder.RenameColumn(
                name: "CreationOriginId",
                table: "Pieces",
                newName: "CountryOfOriginId");

            migrationBuilder.RenameIndex(
                name: "IX_Pieces_CreationOriginId",
                table: "Pieces",
                newName: "IX_Pieces_CountryOfOriginId");

            migrationBuilder.RenameColumn(
                name: "OriginId",
                table: "Artists",
                newName: "CountryOfOriginId");

            migrationBuilder.RenameIndex(
                name: "IX_Artists_OriginId",
                table: "Artists",
                newName: "IX_Artists_CountryOfOriginId");

            migrationBuilder.AddColumn<string>(
                name: "CityOfOrigin",
                table: "Pieces",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StateOfOrigin",
                table: "Pieces",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CityOfOrigin",
                table: "Artists",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StateOfOrigin",
                table: "Artists",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Artists_Countries_CountryOfOriginId",
                table: "Artists",
                column: "CountryOfOriginId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pieces_Countries_CountryOfOriginId",
                table: "Pieces",
                column: "CountryOfOriginId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Artists_Countries_CountryOfOriginId",
                table: "Artists");

            migrationBuilder.DropForeignKey(
                name: "FK_Pieces_Countries_CountryOfOriginId",
                table: "Pieces");

            migrationBuilder.DropColumn(
                name: "CityOfOrigin",
                table: "Pieces");

            migrationBuilder.DropColumn(
                name: "StateOfOrigin",
                table: "Pieces");

            migrationBuilder.DropColumn(
                name: "CityOfOrigin",
                table: "Artists");

            migrationBuilder.DropColumn(
                name: "StateOfOrigin",
                table: "Artists");

            migrationBuilder.RenameColumn(
                name: "CountryOfOriginId",
                table: "Pieces",
                newName: "CreationOriginId");

            migrationBuilder.RenameIndex(
                name: "IX_Pieces_CountryOfOriginId",
                table: "Pieces",
                newName: "IX_Pieces_CreationOriginId");

            migrationBuilder.RenameColumn(
                name: "CountryOfOriginId",
                table: "Artists",
                newName: "OriginId");

            migrationBuilder.RenameIndex(
                name: "IX_Artists_CountryOfOriginId",
                table: "Artists",
                newName: "IX_Artists_OriginId");

            migrationBuilder.CreateTable(
                name: "Origin",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    City = table.Column<string>(nullable: true),
                    CountryId = table.Column<int>(nullable: true),
                    MuseumId = table.Column<int>(nullable: true),
                    State = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Origin", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Origin_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Origin_Museums_MuseumId",
                        column: x => x.MuseumId,
                        principalTable: "Museums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Origin_CountryId",
                table: "Origin",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Origin_MuseumId",
                table: "Origin",
                column: "MuseumId");

            migrationBuilder.AddForeignKey(
                name: "FK_Artists_Origin_OriginId",
                table: "Artists",
                column: "OriginId",
                principalTable: "Origin",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pieces_Origin_CreationOriginId",
                table: "Pieces",
                column: "CreationOriginId",
                principalTable: "Origin",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
