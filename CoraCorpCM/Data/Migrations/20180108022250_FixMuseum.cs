using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CoraCorpCM.Data.Migrations
{
    public partial class FixMuseum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Acquisition_Museum_MuseumId",
                table: "Acquisition");

            migrationBuilder.DropForeignKey(
                name: "FK_Artist_Museum_MuseumId",
                table: "Artist");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Museum_MuseumId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Collection_Museum_MuseumId",
                table: "Collection");

            migrationBuilder.DropForeignKey(
                name: "FK_Condition_Museum_MuseumId",
                table: "Condition");

            migrationBuilder.DropForeignKey(
                name: "FK_Exhibition_Museum_MuseumId",
                table: "Exhibition");

            migrationBuilder.DropForeignKey(
                name: "FK_Genre_Museum_MuseumId",
                table: "Genre");

            migrationBuilder.DropForeignKey(
                name: "FK_Inspection_Museum_MuseumId",
                table: "Inspection");

            migrationBuilder.DropForeignKey(
                name: "FK_Inspector_Museum_MuseumId",
                table: "Inspector");

            migrationBuilder.DropForeignKey(
                name: "FK_InsurancePolicy_Museum_MuseumId",
                table: "InsurancePolicy");

            migrationBuilder.DropForeignKey(
                name: "FK_Loan_Museum_MuseumId",
                table: "Loan");

            migrationBuilder.DropForeignKey(
                name: "FK_Medium_Museum_MuseumId",
                table: "Medium");

            migrationBuilder.DropForeignKey(
                name: "FK_Museum_Location_LocationId",
                table: "Museum");

            migrationBuilder.DropForeignKey(
                name: "FK_Museum_Upload_LogoId",
                table: "Museum");

            migrationBuilder.DropForeignKey(
                name: "FK_Origin_Museum_MuseumId",
                table: "Origin");

            migrationBuilder.DropForeignKey(
                name: "FK_Piece_Museum_MuseumId",
                table: "Piece");

            migrationBuilder.DropForeignKey(
                name: "FK_PieceSource_Museum_MuseumId",
                table: "PieceSource");

            migrationBuilder.DropForeignKey(
                name: "FK_Subgenre_Museum_MuseumId",
                table: "Subgenre");

            migrationBuilder.DropForeignKey(
                name: "FK_SubjectMatter_Museum_MuseumId",
                table: "SubjectMatter");

            migrationBuilder.DropForeignKey(
                name: "FK_Tag_Museum_MuseumId",
                table: "Tag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Museum",
                table: "Museum");

            migrationBuilder.RenameTable(
                name: "Museum",
                newName: "Museums");

            migrationBuilder.RenameIndex(
                name: "IX_Museum_LogoId",
                table: "Museums",
                newName: "IX_Museums_LogoId");

            migrationBuilder.RenameIndex(
                name: "IX_Museum_LocationId",
                table: "Museums",
                newName: "IX_Museums_LocationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Museums",
                table: "Museums",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Acquisition_Museums_MuseumId",
                table: "Acquisition",
                column: "MuseumId",
                principalTable: "Museums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Artist_Museums_MuseumId",
                table: "Artist",
                column: "MuseumId",
                principalTable: "Museums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Museums_MuseumId",
                table: "AspNetUsers",
                column: "MuseumId",
                principalTable: "Museums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Collection_Museums_MuseumId",
                table: "Collection",
                column: "MuseumId",
                principalTable: "Museums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Condition_Museums_MuseumId",
                table: "Condition",
                column: "MuseumId",
                principalTable: "Museums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Exhibition_Museums_MuseumId",
                table: "Exhibition",
                column: "MuseumId",
                principalTable: "Museums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Genre_Museums_MuseumId",
                table: "Genre",
                column: "MuseumId",
                principalTable: "Museums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Inspection_Museums_MuseumId",
                table: "Inspection",
                column: "MuseumId",
                principalTable: "Museums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Inspector_Museums_MuseumId",
                table: "Inspector",
                column: "MuseumId",
                principalTable: "Museums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InsurancePolicy_Museums_MuseumId",
                table: "InsurancePolicy",
                column: "MuseumId",
                principalTable: "Museums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Loan_Museums_MuseumId",
                table: "Loan",
                column: "MuseumId",
                principalTable: "Museums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Medium_Museums_MuseumId",
                table: "Medium",
                column: "MuseumId",
                principalTable: "Museums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Museums_Location_LocationId",
                table: "Museums",
                column: "LocationId",
                principalTable: "Location",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Museums_Upload_LogoId",
                table: "Museums",
                column: "LogoId",
                principalTable: "Upload",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Origin_Museums_MuseumId",
                table: "Origin",
                column: "MuseumId",
                principalTable: "Museums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Piece_Museums_MuseumId",
                table: "Piece",
                column: "MuseumId",
                principalTable: "Museums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PieceSource_Museums_MuseumId",
                table: "PieceSource",
                column: "MuseumId",
                principalTable: "Museums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Subgenre_Museums_MuseumId",
                table: "Subgenre",
                column: "MuseumId",
                principalTable: "Museums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectMatter_Museums_MuseumId",
                table: "SubjectMatter",
                column: "MuseumId",
                principalTable: "Museums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tag_Museums_MuseumId",
                table: "Tag",
                column: "MuseumId",
                principalTable: "Museums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Acquisition_Museums_MuseumId",
                table: "Acquisition");

            migrationBuilder.DropForeignKey(
                name: "FK_Artist_Museums_MuseumId",
                table: "Artist");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Museums_MuseumId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Collection_Museums_MuseumId",
                table: "Collection");

            migrationBuilder.DropForeignKey(
                name: "FK_Condition_Museums_MuseumId",
                table: "Condition");

            migrationBuilder.DropForeignKey(
                name: "FK_Exhibition_Museums_MuseumId",
                table: "Exhibition");

            migrationBuilder.DropForeignKey(
                name: "FK_Genre_Museums_MuseumId",
                table: "Genre");

            migrationBuilder.DropForeignKey(
                name: "FK_Inspection_Museums_MuseumId",
                table: "Inspection");

            migrationBuilder.DropForeignKey(
                name: "FK_Inspector_Museums_MuseumId",
                table: "Inspector");

            migrationBuilder.DropForeignKey(
                name: "FK_InsurancePolicy_Museums_MuseumId",
                table: "InsurancePolicy");

            migrationBuilder.DropForeignKey(
                name: "FK_Loan_Museums_MuseumId",
                table: "Loan");

            migrationBuilder.DropForeignKey(
                name: "FK_Medium_Museums_MuseumId",
                table: "Medium");

            migrationBuilder.DropForeignKey(
                name: "FK_Museums_Location_LocationId",
                table: "Museums");

            migrationBuilder.DropForeignKey(
                name: "FK_Museums_Upload_LogoId",
                table: "Museums");

            migrationBuilder.DropForeignKey(
                name: "FK_Origin_Museums_MuseumId",
                table: "Origin");

            migrationBuilder.DropForeignKey(
                name: "FK_Piece_Museums_MuseumId",
                table: "Piece");

            migrationBuilder.DropForeignKey(
                name: "FK_PieceSource_Museums_MuseumId",
                table: "PieceSource");

            migrationBuilder.DropForeignKey(
                name: "FK_Subgenre_Museums_MuseumId",
                table: "Subgenre");

            migrationBuilder.DropForeignKey(
                name: "FK_SubjectMatter_Museums_MuseumId",
                table: "SubjectMatter");

            migrationBuilder.DropForeignKey(
                name: "FK_Tag_Museums_MuseumId",
                table: "Tag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Museums",
                table: "Museums");

            migrationBuilder.RenameTable(
                name: "Museums",
                newName: "Museum");

            migrationBuilder.RenameIndex(
                name: "IX_Museums_LogoId",
                table: "Museum",
                newName: "IX_Museum_LogoId");

            migrationBuilder.RenameIndex(
                name: "IX_Museums_LocationId",
                table: "Museum",
                newName: "IX_Museum_LocationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Museum",
                table: "Museum",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Acquisition_Museum_MuseumId",
                table: "Acquisition",
                column: "MuseumId",
                principalTable: "Museum",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Artist_Museum_MuseumId",
                table: "Artist",
                column: "MuseumId",
                principalTable: "Museum",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Museum_MuseumId",
                table: "AspNetUsers",
                column: "MuseumId",
                principalTable: "Museum",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Collection_Museum_MuseumId",
                table: "Collection",
                column: "MuseumId",
                principalTable: "Museum",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Condition_Museum_MuseumId",
                table: "Condition",
                column: "MuseumId",
                principalTable: "Museum",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Exhibition_Museum_MuseumId",
                table: "Exhibition",
                column: "MuseumId",
                principalTable: "Museum",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Genre_Museum_MuseumId",
                table: "Genre",
                column: "MuseumId",
                principalTable: "Museum",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Inspection_Museum_MuseumId",
                table: "Inspection",
                column: "MuseumId",
                principalTable: "Museum",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Inspector_Museum_MuseumId",
                table: "Inspector",
                column: "MuseumId",
                principalTable: "Museum",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InsurancePolicy_Museum_MuseumId",
                table: "InsurancePolicy",
                column: "MuseumId",
                principalTable: "Museum",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Loan_Museum_MuseumId",
                table: "Loan",
                column: "MuseumId",
                principalTable: "Museum",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Medium_Museum_MuseumId",
                table: "Medium",
                column: "MuseumId",
                principalTable: "Museum",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Museum_Location_LocationId",
                table: "Museum",
                column: "LocationId",
                principalTable: "Location",
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
                name: "FK_Origin_Museum_MuseumId",
                table: "Origin",
                column: "MuseumId",
                principalTable: "Museum",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Piece_Museum_MuseumId",
                table: "Piece",
                column: "MuseumId",
                principalTable: "Museum",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PieceSource_Museum_MuseumId",
                table: "PieceSource",
                column: "MuseumId",
                principalTable: "Museum",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Subgenre_Museum_MuseumId",
                table: "Subgenre",
                column: "MuseumId",
                principalTable: "Museum",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectMatter_Museum_MuseumId",
                table: "SubjectMatter",
                column: "MuseumId",
                principalTable: "Museum",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tag_Museum_MuseumId",
                table: "Tag",
                column: "MuseumId",
                principalTable: "Museum",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
