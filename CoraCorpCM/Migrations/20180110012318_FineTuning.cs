using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CoraCorpCM.Migrations
{
    public partial class FineTuning : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pieces_AspNetUsers_CreatedById",
                table: "Pieces");

            migrationBuilder.DropIndex(
                name: "IX_Pieces_CreatedById",
                table: "Pieces");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "Pieces");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Pieces");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Pieces",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Pieces",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Pieces",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "Pieces",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pieces_CreatedById",
                table: "Pieces",
                column: "CreatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Pieces_AspNetUsers_CreatedById",
                table: "Pieces",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
