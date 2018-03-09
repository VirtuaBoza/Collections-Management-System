using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CoraCorpCM.Data.Migrations
{
    public partial class EnforcesMuseumFKOnAll : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Acquisitions_Museums_MuseumId",
                table: "Acquisitions");

            migrationBuilder.DropForeignKey(
                name: "FK_ArtistMedium_Artists_ArtistId",
                table: "ArtistMedium");

            migrationBuilder.DropForeignKey(
                name: "FK_ArtistMedium_Media_MediumId",
                table: "ArtistMedium");

            migrationBuilder.DropForeignKey(
                name: "FK_ArtistSubgenre_Artists_ArtistId",
                table: "ArtistSubgenre");

            migrationBuilder.DropForeignKey(
                name: "FK_ArtistSubgenre_Subgenres_SubgenreId",
                table: "ArtistSubgenre");

            migrationBuilder.DropForeignKey(
                name: "FK_ArtistSubjectMatter_Artists_ArtistId",
                table: "ArtistSubjectMatter");

            migrationBuilder.DropForeignKey(
                name: "FK_ArtistSubjectMatter_SubjectMatters_SubjectMatterId",
                table: "ArtistSubjectMatter");

            migrationBuilder.DropForeignKey(
                name: "FK_ArtistTag_Artists_ArtistId",
                table: "ArtistTag");

            migrationBuilder.DropForeignKey(
                name: "FK_ArtistTag_Tag_TagId",
                table: "ArtistTag");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Museums_MuseumId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Collections_Museums_MuseumId",
                table: "Collections");

            migrationBuilder.DropForeignKey(
                name: "FK_Condition_Museums_MuseumId",
                table: "Condition");

            migrationBuilder.DropForeignKey(
                name: "FK_Exhibition_Museums_MuseumId",
                table: "Exhibition");

            migrationBuilder.DropForeignKey(
                name: "FK_ExhibitionPiece_Exhibition_ExhibitionId",
                table: "ExhibitionPiece");

            migrationBuilder.DropForeignKey(
                name: "FK_ExhibitionPiece_Pieces_PieceId",
                table: "ExhibitionPiece");

            migrationBuilder.DropForeignKey(
                name: "FK_FundingSources_Museums_MuseumId",
                table: "FundingSources");

            migrationBuilder.DropForeignKey(
                name: "FK_Inspector_Museums_MuseumId",
                table: "Inspector");

            migrationBuilder.DropForeignKey(
                name: "FK_Loan_Museums_MuseumId",
                table: "Loan");

            migrationBuilder.DropForeignKey(
                name: "FK_LoanPiece_Loan_LoanId",
                table: "LoanPiece");

            migrationBuilder.DropForeignKey(
                name: "FK_LoanPiece_Pieces_PieceId",
                table: "LoanPiece");

            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Museums_MuseumId",
                table: "Locations");

            migrationBuilder.DropForeignKey(
                name: "FK_LocationTag_Locations_LocationId",
                table: "LocationTag");

            migrationBuilder.DropForeignKey(
                name: "FK_LocationTag_Tag_TagId",
                table: "LocationTag");

            migrationBuilder.DropForeignKey(
                name: "FK_Media_Museums_MuseumId",
                table: "Media");

            migrationBuilder.DropForeignKey(
                name: "FK_Pieces_Museums_MuseumId",
                table: "Pieces");

            migrationBuilder.DropForeignKey(
                name: "FK_PieceTag_Pieces_PieceId",
                table: "PieceTag");

            migrationBuilder.DropForeignKey(
                name: "FK_PieceTag_Tag_TagId",
                table: "PieceTag");

            migrationBuilder.DropForeignKey(
                name: "FK_Subgenres_Museums_MuseumId",
                table: "Subgenres");

            migrationBuilder.DropForeignKey(
                name: "FK_SubjectMatters_Museums_MuseumId",
                table: "SubjectMatters");

            migrationBuilder.DropForeignKey(
                name: "FK_Tag_Museums_MuseumId",
                table: "Tag");

            migrationBuilder.DropForeignKey(
                name: "FK_Upload_Museums_MuseumId",
                table: "Upload");

            migrationBuilder.AlterColumn<int>(
                name: "MuseumId",
                table: "Upload",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MuseumId",
                table: "Tag",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MuseumId",
                table: "SubjectMatters",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MuseumId",
                table: "Subgenres",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MuseumId",
                table: "PieceTag",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "MuseumId",
                table: "Pieces",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MuseumId",
                table: "Media",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MuseumId",
                table: "LocationTag",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "MuseumId",
                table: "Locations",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MuseumId",
                table: "LoanPiece",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "MuseumId",
                table: "Loan",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MuseumId",
                table: "Inspector",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MuseumId",
                table: "FundingSources",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MuseumId",
                table: "ExhibitionPiece",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "MuseumId",
                table: "Exhibition",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MuseumId",
                table: "Condition",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MuseumId",
                table: "Collections",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MuseumId",
                table: "AspNetUsers",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MuseumId",
                table: "ArtistTag",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MuseumId",
                table: "ArtistSubjectMatter",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MuseumId",
                table: "ArtistSubgenre",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MuseumId",
                table: "ArtistMedium",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "MuseumId",
                table: "Acquisitions",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PieceTag_MuseumId",
                table: "PieceTag",
                column: "MuseumId");

            migrationBuilder.CreateIndex(
                name: "IX_LocationTag_MuseumId",
                table: "LocationTag",
                column: "MuseumId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanPiece_MuseumId",
                table: "LoanPiece",
                column: "MuseumId");

            migrationBuilder.CreateIndex(
                name: "IX_ExhibitionPiece_MuseumId",
                table: "ExhibitionPiece",
                column: "MuseumId");

            migrationBuilder.CreateIndex(
                name: "IX_ArtistTag_MuseumId",
                table: "ArtistTag",
                column: "MuseumId");

            migrationBuilder.CreateIndex(
                name: "IX_ArtistSubjectMatter_MuseumId",
                table: "ArtistSubjectMatter",
                column: "MuseumId");

            migrationBuilder.CreateIndex(
                name: "IX_ArtistSubgenre_MuseumId",
                table: "ArtistSubgenre",
                column: "MuseumId");

            migrationBuilder.CreateIndex(
                name: "IX_ArtistMedium_MuseumId",
                table: "ArtistMedium",
                column: "MuseumId");

            migrationBuilder.AddForeignKey(
                name: "FK_Acquisitions_Museums_MuseumId",
                table: "Acquisitions",
                column: "MuseumId",
                principalTable: "Museums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ArtistMedium_Artists_ArtistId",
                table: "ArtistMedium",
                column: "ArtistId",
                principalTable: "Artists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ArtistMedium_Media_MediumId",
                table: "ArtistMedium",
                column: "MediumId",
                principalTable: "Media",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ArtistMedium_Museums_MuseumId",
                table: "ArtistMedium",
                column: "MuseumId",
                principalTable: "Museums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ArtistSubgenre_Artists_ArtistId",
                table: "ArtistSubgenre",
                column: "ArtistId",
                principalTable: "Artists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ArtistSubgenre_Museums_MuseumId",
                table: "ArtistSubgenre",
                column: "MuseumId",
                principalTable: "Museums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ArtistSubgenre_Subgenres_SubgenreId",
                table: "ArtistSubgenre",
                column: "SubgenreId",
                principalTable: "Subgenres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ArtistSubjectMatter_Artists_ArtistId",
                table: "ArtistSubjectMatter",
                column: "ArtistId",
                principalTable: "Artists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ArtistSubjectMatter_Museums_MuseumId",
                table: "ArtistSubjectMatter",
                column: "MuseumId",
                principalTable: "Museums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ArtistSubjectMatter_SubjectMatters_SubjectMatterId",
                table: "ArtistSubjectMatter",
                column: "SubjectMatterId",
                principalTable: "SubjectMatters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ArtistTag_Artists_ArtistId",
                table: "ArtistTag",
                column: "ArtistId",
                principalTable: "Artists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ArtistTag_Museums_MuseumId",
                table: "ArtistTag",
                column: "MuseumId",
                principalTable: "Museums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ArtistTag_Tag_TagId",
                table: "ArtistTag",
                column: "TagId",
                principalTable: "Tag",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Museums_MuseumId",
                table: "AspNetUsers",
                column: "MuseumId",
                principalTable: "Museums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Collections_Museums_MuseumId",
                table: "Collections",
                column: "MuseumId",
                principalTable: "Museums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Condition_Museums_MuseumId",
                table: "Condition",
                column: "MuseumId",
                principalTable: "Museums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Exhibition_Museums_MuseumId",
                table: "Exhibition",
                column: "MuseumId",
                principalTable: "Museums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExhibitionPiece_Exhibition_ExhibitionId",
                table: "ExhibitionPiece",
                column: "ExhibitionId",
                principalTable: "Exhibition",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ExhibitionPiece_Museums_MuseumId",
                table: "ExhibitionPiece",
                column: "MuseumId",
                principalTable: "Museums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExhibitionPiece_Pieces_PieceId",
                table: "ExhibitionPiece",
                column: "PieceId",
                principalTable: "Pieces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FundingSources_Museums_MuseumId",
                table: "FundingSources",
                column: "MuseumId",
                principalTable: "Museums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Inspector_Museums_MuseumId",
                table: "Inspector",
                column: "MuseumId",
                principalTable: "Museums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Loan_Museums_MuseumId",
                table: "Loan",
                column: "MuseumId",
                principalTable: "Museums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LoanPiece_Loan_LoanId",
                table: "LoanPiece",
                column: "LoanId",
                principalTable: "Loan",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LoanPiece_Museums_MuseumId",
                table: "LoanPiece",
                column: "MuseumId",
                principalTable: "Museums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LoanPiece_Pieces_PieceId",
                table: "LoanPiece",
                column: "PieceId",
                principalTable: "Pieces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Museums_MuseumId",
                table: "Locations",
                column: "MuseumId",
                principalTable: "Museums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LocationTag_Locations_LocationId",
                table: "LocationTag",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LocationTag_Museums_MuseumId",
                table: "LocationTag",
                column: "MuseumId",
                principalTable: "Museums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LocationTag_Tag_TagId",
                table: "LocationTag",
                column: "TagId",
                principalTable: "Tag",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Media_Museums_MuseumId",
                table: "Media",
                column: "MuseumId",
                principalTable: "Museums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pieces_Museums_MuseumId",
                table: "Pieces",
                column: "MuseumId",
                principalTable: "Museums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PieceTag_Museums_MuseumId",
                table: "PieceTag",
                column: "MuseumId",
                principalTable: "Museums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PieceTag_Pieces_PieceId",
                table: "PieceTag",
                column: "PieceId",
                principalTable: "Pieces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PieceTag_Tag_TagId",
                table: "PieceTag",
                column: "TagId",
                principalTable: "Tag",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Subgenres_Museums_MuseumId",
                table: "Subgenres",
                column: "MuseumId",
                principalTable: "Museums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectMatters_Museums_MuseumId",
                table: "SubjectMatters",
                column: "MuseumId",
                principalTable: "Museums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tag_Museums_MuseumId",
                table: "Tag",
                column: "MuseumId",
                principalTable: "Museums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Upload_Museums_MuseumId",
                table: "Upload",
                column: "MuseumId",
                principalTable: "Museums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Acquisitions_Museums_MuseumId",
                table: "Acquisitions");

            migrationBuilder.DropForeignKey(
                name: "FK_ArtistMedium_Artists_ArtistId",
                table: "ArtistMedium");

            migrationBuilder.DropForeignKey(
                name: "FK_ArtistMedium_Media_MediumId",
                table: "ArtistMedium");

            migrationBuilder.DropForeignKey(
                name: "FK_ArtistMedium_Museums_MuseumId",
                table: "ArtistMedium");

            migrationBuilder.DropForeignKey(
                name: "FK_ArtistSubgenre_Artists_ArtistId",
                table: "ArtistSubgenre");

            migrationBuilder.DropForeignKey(
                name: "FK_ArtistSubgenre_Museums_MuseumId",
                table: "ArtistSubgenre");

            migrationBuilder.DropForeignKey(
                name: "FK_ArtistSubgenre_Subgenres_SubgenreId",
                table: "ArtistSubgenre");

            migrationBuilder.DropForeignKey(
                name: "FK_ArtistSubjectMatter_Artists_ArtistId",
                table: "ArtistSubjectMatter");

            migrationBuilder.DropForeignKey(
                name: "FK_ArtistSubjectMatter_Museums_MuseumId",
                table: "ArtistSubjectMatter");

            migrationBuilder.DropForeignKey(
                name: "FK_ArtistSubjectMatter_SubjectMatters_SubjectMatterId",
                table: "ArtistSubjectMatter");

            migrationBuilder.DropForeignKey(
                name: "FK_ArtistTag_Artists_ArtistId",
                table: "ArtistTag");

            migrationBuilder.DropForeignKey(
                name: "FK_ArtistTag_Museums_MuseumId",
                table: "ArtistTag");

            migrationBuilder.DropForeignKey(
                name: "FK_ArtistTag_Tag_TagId",
                table: "ArtistTag");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Museums_MuseumId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Collections_Museums_MuseumId",
                table: "Collections");

            migrationBuilder.DropForeignKey(
                name: "FK_Condition_Museums_MuseumId",
                table: "Condition");

            migrationBuilder.DropForeignKey(
                name: "FK_Exhibition_Museums_MuseumId",
                table: "Exhibition");

            migrationBuilder.DropForeignKey(
                name: "FK_ExhibitionPiece_Exhibition_ExhibitionId",
                table: "ExhibitionPiece");

            migrationBuilder.DropForeignKey(
                name: "FK_ExhibitionPiece_Museums_MuseumId",
                table: "ExhibitionPiece");

            migrationBuilder.DropForeignKey(
                name: "FK_ExhibitionPiece_Pieces_PieceId",
                table: "ExhibitionPiece");

            migrationBuilder.DropForeignKey(
                name: "FK_FundingSources_Museums_MuseumId",
                table: "FundingSources");

            migrationBuilder.DropForeignKey(
                name: "FK_Inspector_Museums_MuseumId",
                table: "Inspector");

            migrationBuilder.DropForeignKey(
                name: "FK_Loan_Museums_MuseumId",
                table: "Loan");

            migrationBuilder.DropForeignKey(
                name: "FK_LoanPiece_Loan_LoanId",
                table: "LoanPiece");

            migrationBuilder.DropForeignKey(
                name: "FK_LoanPiece_Museums_MuseumId",
                table: "LoanPiece");

            migrationBuilder.DropForeignKey(
                name: "FK_LoanPiece_Pieces_PieceId",
                table: "LoanPiece");

            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Museums_MuseumId",
                table: "Locations");

            migrationBuilder.DropForeignKey(
                name: "FK_LocationTag_Locations_LocationId",
                table: "LocationTag");

            migrationBuilder.DropForeignKey(
                name: "FK_LocationTag_Museums_MuseumId",
                table: "LocationTag");

            migrationBuilder.DropForeignKey(
                name: "FK_LocationTag_Tag_TagId",
                table: "LocationTag");

            migrationBuilder.DropForeignKey(
                name: "FK_Media_Museums_MuseumId",
                table: "Media");

            migrationBuilder.DropForeignKey(
                name: "FK_Pieces_Museums_MuseumId",
                table: "Pieces");

            migrationBuilder.DropForeignKey(
                name: "FK_PieceTag_Museums_MuseumId",
                table: "PieceTag");

            migrationBuilder.DropForeignKey(
                name: "FK_PieceTag_Pieces_PieceId",
                table: "PieceTag");

            migrationBuilder.DropForeignKey(
                name: "FK_PieceTag_Tag_TagId",
                table: "PieceTag");

            migrationBuilder.DropForeignKey(
                name: "FK_Subgenres_Museums_MuseumId",
                table: "Subgenres");

            migrationBuilder.DropForeignKey(
                name: "FK_SubjectMatters_Museums_MuseumId",
                table: "SubjectMatters");

            migrationBuilder.DropForeignKey(
                name: "FK_Tag_Museums_MuseumId",
                table: "Tag");

            migrationBuilder.DropForeignKey(
                name: "FK_Upload_Museums_MuseumId",
                table: "Upload");

            migrationBuilder.DropIndex(
                name: "IX_PieceTag_MuseumId",
                table: "PieceTag");

            migrationBuilder.DropIndex(
                name: "IX_LocationTag_MuseumId",
                table: "LocationTag");

            migrationBuilder.DropIndex(
                name: "IX_LoanPiece_MuseumId",
                table: "LoanPiece");

            migrationBuilder.DropIndex(
                name: "IX_ExhibitionPiece_MuseumId",
                table: "ExhibitionPiece");

            migrationBuilder.DropIndex(
                name: "IX_ArtistTag_MuseumId",
                table: "ArtistTag");

            migrationBuilder.DropIndex(
                name: "IX_ArtistSubjectMatter_MuseumId",
                table: "ArtistSubjectMatter");

            migrationBuilder.DropIndex(
                name: "IX_ArtistSubgenre_MuseumId",
                table: "ArtistSubgenre");

            migrationBuilder.DropIndex(
                name: "IX_ArtistMedium_MuseumId",
                table: "ArtistMedium");

            migrationBuilder.DropColumn(
                name: "MuseumId",
                table: "PieceTag");

            migrationBuilder.DropColumn(
                name: "MuseumId",
                table: "LocationTag");

            migrationBuilder.DropColumn(
                name: "MuseumId",
                table: "LoanPiece");

            migrationBuilder.DropColumn(
                name: "MuseumId",
                table: "ExhibitionPiece");

            migrationBuilder.DropColumn(
                name: "MuseumId",
                table: "ArtistTag");

            migrationBuilder.DropColumn(
                name: "MuseumId",
                table: "ArtistSubjectMatter");

            migrationBuilder.DropColumn(
                name: "MuseumId",
                table: "ArtistSubgenre");

            migrationBuilder.DropColumn(
                name: "MuseumId",
                table: "ArtistMedium");

            migrationBuilder.AlterColumn<int>(
                name: "MuseumId",
                table: "Upload",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "MuseumId",
                table: "Tag",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "MuseumId",
                table: "SubjectMatters",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "MuseumId",
                table: "Subgenres",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "MuseumId",
                table: "Pieces",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "MuseumId",
                table: "Media",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "MuseumId",
                table: "Locations",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "MuseumId",
                table: "Loan",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "MuseumId",
                table: "Inspector",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "MuseumId",
                table: "FundingSources",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "MuseumId",
                table: "Exhibition",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "MuseumId",
                table: "Condition",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "MuseumId",
                table: "Collections",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "MuseumId",
                table: "AspNetUsers",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "MuseumId",
                table: "Acquisitions",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Acquisitions_Museums_MuseumId",
                table: "Acquisitions",
                column: "MuseumId",
                principalTable: "Museums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ArtistMedium_Artists_ArtistId",
                table: "ArtistMedium",
                column: "ArtistId",
                principalTable: "Artists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ArtistMedium_Media_MediumId",
                table: "ArtistMedium",
                column: "MediumId",
                principalTable: "Media",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ArtistSubgenre_Artists_ArtistId",
                table: "ArtistSubgenre",
                column: "ArtistId",
                principalTable: "Artists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ArtistSubgenre_Subgenres_SubgenreId",
                table: "ArtistSubgenre",
                column: "SubgenreId",
                principalTable: "Subgenres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ArtistSubjectMatter_Artists_ArtistId",
                table: "ArtistSubjectMatter",
                column: "ArtistId",
                principalTable: "Artists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ArtistSubjectMatter_SubjectMatters_SubjectMatterId",
                table: "ArtistSubjectMatter",
                column: "SubjectMatterId",
                principalTable: "SubjectMatters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ArtistTag_Artists_ArtistId",
                table: "ArtistTag",
                column: "ArtistId",
                principalTable: "Artists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ArtistTag_Tag_TagId",
                table: "ArtistTag",
                column: "TagId",
                principalTable: "Tag",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Museums_MuseumId",
                table: "AspNetUsers",
                column: "MuseumId",
                principalTable: "Museums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Collections_Museums_MuseumId",
                table: "Collections",
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
                name: "FK_ExhibitionPiece_Exhibition_ExhibitionId",
                table: "ExhibitionPiece",
                column: "ExhibitionId",
                principalTable: "Exhibition",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExhibitionPiece_Pieces_PieceId",
                table: "ExhibitionPiece",
                column: "PieceId",
                principalTable: "Pieces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FundingSources_Museums_MuseumId",
                table: "FundingSources",
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
                name: "FK_Loan_Museums_MuseumId",
                table: "Loan",
                column: "MuseumId",
                principalTable: "Museums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LoanPiece_Loan_LoanId",
                table: "LoanPiece",
                column: "LoanId",
                principalTable: "Loan",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LoanPiece_Pieces_PieceId",
                table: "LoanPiece",
                column: "PieceId",
                principalTable: "Pieces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Museums_MuseumId",
                table: "Locations",
                column: "MuseumId",
                principalTable: "Museums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LocationTag_Locations_LocationId",
                table: "LocationTag",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LocationTag_Tag_TagId",
                table: "LocationTag",
                column: "TagId",
                principalTable: "Tag",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Media_Museums_MuseumId",
                table: "Media",
                column: "MuseumId",
                principalTable: "Museums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pieces_Museums_MuseumId",
                table: "Pieces",
                column: "MuseumId",
                principalTable: "Museums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PieceTag_Pieces_PieceId",
                table: "PieceTag",
                column: "PieceId",
                principalTable: "Pieces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PieceTag_Tag_TagId",
                table: "PieceTag",
                column: "TagId",
                principalTable: "Tag",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Subgenres_Museums_MuseumId",
                table: "Subgenres",
                column: "MuseumId",
                principalTable: "Museums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectMatters_Museums_MuseumId",
                table: "SubjectMatters",
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

            migrationBuilder.AddForeignKey(
                name: "FK_Upload_Museums_MuseumId",
                table: "Upload",
                column: "MuseumId",
                principalTable: "Museums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
