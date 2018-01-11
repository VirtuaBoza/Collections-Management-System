using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CoraCorpCM.Migrations
{
    public partial class UnitOfMeasureUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UnitOfMeasure",
                table: "Pieces");

            migrationBuilder.AddColumn<int>(
                name: "UnitOfMeasureId",
                table: "Pieces",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UnitOfMeasure",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Abbreviation = table.Column<string>(nullable: true),
                    UnitOfMeasurement = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitOfMeasure", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pieces_UnitOfMeasureId",
                table: "Pieces",
                column: "UnitOfMeasureId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pieces_UnitOfMeasure_UnitOfMeasureId",
                table: "Pieces",
                column: "UnitOfMeasureId",
                principalTable: "UnitOfMeasure",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pieces_UnitOfMeasure_UnitOfMeasureId",
                table: "Pieces");

            migrationBuilder.DropTable(
                name: "UnitOfMeasure");

            migrationBuilder.DropIndex(
                name: "IX_Pieces_UnitOfMeasureId",
                table: "Pieces");

            migrationBuilder.DropColumn(
                name: "UnitOfMeasureId",
                table: "Pieces");

            migrationBuilder.AddColumn<string>(
                name: "UnitOfMeasure",
                table: "Pieces",
                nullable: true);
        }
    }
}
