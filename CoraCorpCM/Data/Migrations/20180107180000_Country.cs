using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CoraCorpCM.Data.Migrations
{
    public partial class Country : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Acquisition_File_PurchaseReceiptId",
                table: "Acquisition");

            migrationBuilder.DropForeignKey(
                name: "FK_Loan_File_LoanAgreementId",
                table: "Loan");

            migrationBuilder.DropForeignKey(
                name: "FK_Museum_File_LogoId",
                table: "Museum");

            migrationBuilder.DropForeignKey(
                name: "FK_Piece_File_PhotoId",
                table: "Piece");

            migrationBuilder.DropTable(
                name: "File");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Origin");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Location");

            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "Origin",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "Location",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Genc3A = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Upload",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Data = table.Column<byte[]>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Upload", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Origin_CountryId",
                table: "Origin",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Location_CountryId",
                table: "Location",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Acquisition_Upload_PurchaseReceiptId",
                table: "Acquisition",
                column: "PurchaseReceiptId",
                principalTable: "Upload",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Loan_Upload_LoanAgreementId",
                table: "Loan",
                column: "LoanAgreementId",
                principalTable: "Upload",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Location_Countries_CountryId",
                table: "Location",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Museum_Upload_LogoId",
                table: "Museum",
                column: "LogoId",
                principalTable: "Upload",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Origin_Countries_CountryId",
                table: "Origin",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Piece_Upload_PhotoId",
                table: "Piece",
                column: "PhotoId",
                principalTable: "Upload",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Acquisition_Upload_PurchaseReceiptId",
                table: "Acquisition");

            migrationBuilder.DropForeignKey(
                name: "FK_Loan_Upload_LoanAgreementId",
                table: "Loan");

            migrationBuilder.DropForeignKey(
                name: "FK_Location_Countries_CountryId",
                table: "Location");

            migrationBuilder.DropForeignKey(
                name: "FK_Museum_Upload_LogoId",
                table: "Museum");

            migrationBuilder.DropForeignKey(
                name: "FK_Origin_Countries_CountryId",
                table: "Origin");

            migrationBuilder.DropForeignKey(
                name: "FK_Piece_Upload_PhotoId",
                table: "Piece");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Upload");

            migrationBuilder.DropIndex(
                name: "IX_Origin_CountryId",
                table: "Origin");

            migrationBuilder.DropIndex(
                name: "IX_Location_CountryId",
                table: "Location");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "Origin");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "Location");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Origin",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Location",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "File",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Data = table.Column<byte[]>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_File", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Acquisition_File_PurchaseReceiptId",
                table: "Acquisition",
                column: "PurchaseReceiptId",
                principalTable: "File",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Loan_File_LoanAgreementId",
                table: "Loan",
                column: "LoanAgreementId",
                principalTable: "File",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Museum_File_LogoId",
                table: "Museum",
                column: "LogoId",
                principalTable: "File",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Piece_File_PhotoId",
                table: "Piece",
                column: "PhotoId",
                principalTable: "File",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
