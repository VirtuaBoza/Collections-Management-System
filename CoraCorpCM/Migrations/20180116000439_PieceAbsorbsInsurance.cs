using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CoraCorpCM.Migrations
{
    public partial class PieceAbsorbsInsurance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pieces_InsurancePolicies_InsurancePolicyId",
                table: "Pieces");

            migrationBuilder.DropTable(
                name: "InsurancePolicies");

            migrationBuilder.DropIndex(
                name: "IX_Pieces_InsurancePolicyId",
                table: "Pieces");

            migrationBuilder.DropColumn(
                name: "InsurancePolicyId",
                table: "Pieces");

            migrationBuilder.AddColumn<decimal>(
                name: "InsuranceAmount",
                table: "Pieces",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "InsuranceCarrier",
                table: "Pieces",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "InsuranceExpirationDate",
                table: "Pieces",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "InsurancePolicyNumber",
                table: "Pieces",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InsuranceAmount",
                table: "Pieces");

            migrationBuilder.DropColumn(
                name: "InsuranceCarrier",
                table: "Pieces");

            migrationBuilder.DropColumn(
                name: "InsuranceExpirationDate",
                table: "Pieces");

            migrationBuilder.DropColumn(
                name: "InsurancePolicyNumber",
                table: "Pieces");

            migrationBuilder.AddColumn<int>(
                name: "InsurancePolicyId",
                table: "Pieces",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "InsurancePolicies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AmountInsured = table.Column<decimal>(nullable: false),
                    Carrier = table.Column<string>(nullable: true),
                    ExpirationDate = table.Column<DateTime>(type: "date", nullable: false),
                    MuseumId = table.Column<int>(nullable: true),
                    PolicyNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsurancePolicies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InsurancePolicies_Museums_MuseumId",
                        column: x => x.MuseumId,
                        principalTable: "Museums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pieces_InsurancePolicyId",
                table: "Pieces",
                column: "InsurancePolicyId");

            migrationBuilder.CreateIndex(
                name: "IX_InsurancePolicies_MuseumId",
                table: "InsurancePolicies",
                column: "MuseumId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pieces_InsurancePolicies_InsurancePolicyId",
                table: "Pieces",
                column: "InsurancePolicyId",
                principalTable: "InsurancePolicies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
