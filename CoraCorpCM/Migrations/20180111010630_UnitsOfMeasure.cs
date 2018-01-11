using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CoraCorpCM.Migrations
{
    public partial class UnitsOfMeasure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pieces_UnitOfMeasure_UnitOfMeasureId",
                table: "Pieces");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UnitOfMeasure",
                table: "UnitOfMeasure");

            migrationBuilder.RenameTable(
                name: "UnitOfMeasure",
                newName: "UnitsOfMeasure");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UnitsOfMeasure",
                table: "UnitsOfMeasure",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pieces_UnitsOfMeasure_UnitOfMeasureId",
                table: "Pieces",
                column: "UnitOfMeasureId",
                principalTable: "UnitsOfMeasure",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pieces_UnitsOfMeasure_UnitOfMeasureId",
                table: "Pieces");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UnitsOfMeasure",
                table: "UnitsOfMeasure");

            migrationBuilder.RenameTable(
                name: "UnitsOfMeasure",
                newName: "UnitOfMeasure");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UnitOfMeasure",
                table: "UnitOfMeasure",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pieces_UnitOfMeasure_UnitOfMeasureId",
                table: "Pieces",
                column: "UnitOfMeasureId",
                principalTable: "UnitOfMeasure",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
