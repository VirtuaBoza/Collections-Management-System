using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CoraCorpCM.Migrations
{
    public partial class UpdatesFieldsAndDbSetPieces : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExhibitionPiece_Piece_PieceId",
                table: "ExhibitionPiece");

            migrationBuilder.DropForeignKey(
                name: "FK_Inspection_Piece_PieceId",
                table: "Inspection");

            migrationBuilder.DropForeignKey(
                name: "FK_LoanPiece_Piece_PieceId",
                table: "LoanPiece");

            migrationBuilder.DropForeignKey(
                name: "FK_Piece_Acquisition_AcquisitionId",
                table: "Piece");

            migrationBuilder.DropForeignKey(
                name: "FK_Piece_Collection_CollectionId",
                table: "Piece");

            migrationBuilder.DropForeignKey(
                name: "FK_Piece_AspNetUsers_CreatedById",
                table: "Piece");

            migrationBuilder.DropForeignKey(
                name: "FK_Piece_Origin_CreationOriginId",
                table: "Piece");

            migrationBuilder.DropForeignKey(
                name: "FK_Piece_Location_CurrentLocationId",
                table: "Piece");

            migrationBuilder.DropForeignKey(
                name: "FK_Piece_Exhibition_ExhibitionId",
                table: "Piece");

            migrationBuilder.DropForeignKey(
                name: "FK_Piece_Genre_GenreId",
                table: "Piece");

            migrationBuilder.DropForeignKey(
                name: "FK_Piece_InsurancePolicy_InsurancePolicyId",
                table: "Piece");

            migrationBuilder.DropForeignKey(
                name: "FK_Piece_AspNetUsers_LastModifiedById",
                table: "Piece");

            migrationBuilder.DropForeignKey(
                name: "FK_Piece_Medium_MediumId",
                table: "Piece");

            migrationBuilder.DropForeignKey(
                name: "FK_Piece_Museums_MuseumId",
                table: "Piece");

            migrationBuilder.DropForeignKey(
                name: "FK_Piece_Location_PermanentLocationId",
                table: "Piece");

            migrationBuilder.DropForeignKey(
                name: "FK_Piece_Upload_PhotoId",
                table: "Piece");

            migrationBuilder.DropForeignKey(
                name: "FK_Piece_Subgenre_SubgenreId",
                table: "Piece");

            migrationBuilder.DropForeignKey(
                name: "FK_Piece_SubjectMatter_SubjectMatterId",
                table: "Piece");

            migrationBuilder.DropForeignKey(
                name: "FK_PieceArtist_Piece_PieceId",
                table: "PieceArtist");

            migrationBuilder.DropForeignKey(
                name: "FK_PieceTag_Piece_PieceId",
                table: "PieceTag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Piece",
                table: "Piece");

            migrationBuilder.RenameTable(
                name: "Piece",
                newName: "Pieces");

            migrationBuilder.RenameIndex(
                name: "IX_Piece_SubjectMatterId",
                table: "Pieces",
                newName: "IX_Pieces_SubjectMatterId");

            migrationBuilder.RenameIndex(
                name: "IX_Piece_SubgenreId",
                table: "Pieces",
                newName: "IX_Pieces_SubgenreId");

            migrationBuilder.RenameIndex(
                name: "IX_Piece_PhotoId",
                table: "Pieces",
                newName: "IX_Pieces_PhotoId");

            migrationBuilder.RenameIndex(
                name: "IX_Piece_PermanentLocationId",
                table: "Pieces",
                newName: "IX_Pieces_PermanentLocationId");

            migrationBuilder.RenameIndex(
                name: "IX_Piece_MuseumId",
                table: "Pieces",
                newName: "IX_Pieces_MuseumId");

            migrationBuilder.RenameIndex(
                name: "IX_Piece_MediumId",
                table: "Pieces",
                newName: "IX_Pieces_MediumId");

            migrationBuilder.RenameIndex(
                name: "IX_Piece_LastModifiedById",
                table: "Pieces",
                newName: "IX_Pieces_LastModifiedById");

            migrationBuilder.RenameIndex(
                name: "IX_Piece_InsurancePolicyId",
                table: "Pieces",
                newName: "IX_Pieces_InsurancePolicyId");

            migrationBuilder.RenameIndex(
                name: "IX_Piece_GenreId",
                table: "Pieces",
                newName: "IX_Pieces_GenreId");

            migrationBuilder.RenameIndex(
                name: "IX_Piece_ExhibitionId",
                table: "Pieces",
                newName: "IX_Pieces_ExhibitionId");

            migrationBuilder.RenameIndex(
                name: "IX_Piece_CurrentLocationId",
                table: "Pieces",
                newName: "IX_Pieces_CurrentLocationId");

            migrationBuilder.RenameIndex(
                name: "IX_Piece_CreationOriginId",
                table: "Pieces",
                newName: "IX_Pieces_CreationOriginId");

            migrationBuilder.RenameIndex(
                name: "IX_Piece_CreatedById",
                table: "Pieces",
                newName: "IX_Pieces_CreatedById");

            migrationBuilder.RenameIndex(
                name: "IX_Piece_CollectionId",
                table: "Pieces",
                newName: "IX_Pieces_CollectionId");

            migrationBuilder.RenameIndex(
                name: "IX_Piece_AcquisitionId",
                table: "Pieces",
                newName: "IX_Pieces_AcquisitionId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CopyrightYear",
                table: "Pieces",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpirationDate",
                table: "InsurancePolicy",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Inspection",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<string>(
                name: "Genc2A",
                table: "Countries",
                maxLength: 2,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Deathdate",
                table: "Artist",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Birthdate",
                table: "Artist",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Acquisition",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pieces",
                table: "Pieces",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ExhibitionPiece_Pieces_PieceId",
                table: "ExhibitionPiece",
                column: "PieceId",
                principalTable: "Pieces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Inspection_Pieces_PieceId",
                table: "Inspection",
                column: "PieceId",
                principalTable: "Pieces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LoanPiece_Pieces_PieceId",
                table: "LoanPiece",
                column: "PieceId",
                principalTable: "Pieces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PieceArtist_Pieces_PieceId",
                table: "PieceArtist",
                column: "PieceId",
                principalTable: "Pieces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pieces_Acquisition_AcquisitionId",
                table: "Pieces",
                column: "AcquisitionId",
                principalTable: "Acquisition",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pieces_Collection_CollectionId",
                table: "Pieces",
                column: "CollectionId",
                principalTable: "Collection",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pieces_AspNetUsers_CreatedById",
                table: "Pieces",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pieces_Origin_CreationOriginId",
                table: "Pieces",
                column: "CreationOriginId",
                principalTable: "Origin",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pieces_Location_CurrentLocationId",
                table: "Pieces",
                column: "CurrentLocationId",
                principalTable: "Location",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pieces_Exhibition_ExhibitionId",
                table: "Pieces",
                column: "ExhibitionId",
                principalTable: "Exhibition",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pieces_Genre_GenreId",
                table: "Pieces",
                column: "GenreId",
                principalTable: "Genre",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pieces_InsurancePolicy_InsurancePolicyId",
                table: "Pieces",
                column: "InsurancePolicyId",
                principalTable: "InsurancePolicy",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pieces_AspNetUsers_LastModifiedById",
                table: "Pieces",
                column: "LastModifiedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pieces_Medium_MediumId",
                table: "Pieces",
                column: "MediumId",
                principalTable: "Medium",
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
                name: "FK_Pieces_Location_PermanentLocationId",
                table: "Pieces",
                column: "PermanentLocationId",
                principalTable: "Location",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pieces_Upload_PhotoId",
                table: "Pieces",
                column: "PhotoId",
                principalTable: "Upload",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pieces_Subgenre_SubgenreId",
                table: "Pieces",
                column: "SubgenreId",
                principalTable: "Subgenre",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pieces_SubjectMatter_SubjectMatterId",
                table: "Pieces",
                column: "SubjectMatterId",
                principalTable: "SubjectMatter",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PieceTag_Pieces_PieceId",
                table: "PieceTag",
                column: "PieceId",
                principalTable: "Pieces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExhibitionPiece_Pieces_PieceId",
                table: "ExhibitionPiece");

            migrationBuilder.DropForeignKey(
                name: "FK_Inspection_Pieces_PieceId",
                table: "Inspection");

            migrationBuilder.DropForeignKey(
                name: "FK_LoanPiece_Pieces_PieceId",
                table: "LoanPiece");

            migrationBuilder.DropForeignKey(
                name: "FK_PieceArtist_Pieces_PieceId",
                table: "PieceArtist");

            migrationBuilder.DropForeignKey(
                name: "FK_Pieces_Acquisition_AcquisitionId",
                table: "Pieces");

            migrationBuilder.DropForeignKey(
                name: "FK_Pieces_Collection_CollectionId",
                table: "Pieces");

            migrationBuilder.DropForeignKey(
                name: "FK_Pieces_AspNetUsers_CreatedById",
                table: "Pieces");

            migrationBuilder.DropForeignKey(
                name: "FK_Pieces_Origin_CreationOriginId",
                table: "Pieces");

            migrationBuilder.DropForeignKey(
                name: "FK_Pieces_Location_CurrentLocationId",
                table: "Pieces");

            migrationBuilder.DropForeignKey(
                name: "FK_Pieces_Exhibition_ExhibitionId",
                table: "Pieces");

            migrationBuilder.DropForeignKey(
                name: "FK_Pieces_Genre_GenreId",
                table: "Pieces");

            migrationBuilder.DropForeignKey(
                name: "FK_Pieces_InsurancePolicy_InsurancePolicyId",
                table: "Pieces");

            migrationBuilder.DropForeignKey(
                name: "FK_Pieces_AspNetUsers_LastModifiedById",
                table: "Pieces");

            migrationBuilder.DropForeignKey(
                name: "FK_Pieces_Medium_MediumId",
                table: "Pieces");

            migrationBuilder.DropForeignKey(
                name: "FK_Pieces_Museums_MuseumId",
                table: "Pieces");

            migrationBuilder.DropForeignKey(
                name: "FK_Pieces_Location_PermanentLocationId",
                table: "Pieces");

            migrationBuilder.DropForeignKey(
                name: "FK_Pieces_Upload_PhotoId",
                table: "Pieces");

            migrationBuilder.DropForeignKey(
                name: "FK_Pieces_Subgenre_SubgenreId",
                table: "Pieces");

            migrationBuilder.DropForeignKey(
                name: "FK_Pieces_SubjectMatter_SubjectMatterId",
                table: "Pieces");

            migrationBuilder.DropForeignKey(
                name: "FK_PieceTag_Pieces_PieceId",
                table: "PieceTag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pieces",
                table: "Pieces");

            migrationBuilder.RenameTable(
                name: "Pieces",
                newName: "Piece");

            migrationBuilder.RenameIndex(
                name: "IX_Pieces_SubjectMatterId",
                table: "Piece",
                newName: "IX_Piece_SubjectMatterId");

            migrationBuilder.RenameIndex(
                name: "IX_Pieces_SubgenreId",
                table: "Piece",
                newName: "IX_Piece_SubgenreId");

            migrationBuilder.RenameIndex(
                name: "IX_Pieces_PhotoId",
                table: "Piece",
                newName: "IX_Piece_PhotoId");

            migrationBuilder.RenameIndex(
                name: "IX_Pieces_PermanentLocationId",
                table: "Piece",
                newName: "IX_Piece_PermanentLocationId");

            migrationBuilder.RenameIndex(
                name: "IX_Pieces_MuseumId",
                table: "Piece",
                newName: "IX_Piece_MuseumId");

            migrationBuilder.RenameIndex(
                name: "IX_Pieces_MediumId",
                table: "Piece",
                newName: "IX_Piece_MediumId");

            migrationBuilder.RenameIndex(
                name: "IX_Pieces_LastModifiedById",
                table: "Piece",
                newName: "IX_Piece_LastModifiedById");

            migrationBuilder.RenameIndex(
                name: "IX_Pieces_InsurancePolicyId",
                table: "Piece",
                newName: "IX_Piece_InsurancePolicyId");

            migrationBuilder.RenameIndex(
                name: "IX_Pieces_GenreId",
                table: "Piece",
                newName: "IX_Piece_GenreId");

            migrationBuilder.RenameIndex(
                name: "IX_Pieces_ExhibitionId",
                table: "Piece",
                newName: "IX_Piece_ExhibitionId");

            migrationBuilder.RenameIndex(
                name: "IX_Pieces_CurrentLocationId",
                table: "Piece",
                newName: "IX_Piece_CurrentLocationId");

            migrationBuilder.RenameIndex(
                name: "IX_Pieces_CreationOriginId",
                table: "Piece",
                newName: "IX_Piece_CreationOriginId");

            migrationBuilder.RenameIndex(
                name: "IX_Pieces_CreatedById",
                table: "Piece",
                newName: "IX_Piece_CreatedById");

            migrationBuilder.RenameIndex(
                name: "IX_Pieces_CollectionId",
                table: "Piece",
                newName: "IX_Piece_CollectionId");

            migrationBuilder.RenameIndex(
                name: "IX_Pieces_AcquisitionId",
                table: "Piece",
                newName: "IX_Piece_AcquisitionId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CopyrightYear",
                table: "Piece",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpirationDate",
                table: "InsurancePolicy",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Inspection",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AlterColumn<string>(
                name: "Genc2A",
                table: "Countries",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 2,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Deathdate",
                table: "Artist",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Birthdate",
                table: "Artist",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Acquisition",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Piece",
                table: "Piece",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ExhibitionPiece_Piece_PieceId",
                table: "ExhibitionPiece",
                column: "PieceId",
                principalTable: "Piece",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Inspection_Piece_PieceId",
                table: "Inspection",
                column: "PieceId",
                principalTable: "Piece",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LoanPiece_Piece_PieceId",
                table: "LoanPiece",
                column: "PieceId",
                principalTable: "Piece",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Piece_Acquisition_AcquisitionId",
                table: "Piece",
                column: "AcquisitionId",
                principalTable: "Acquisition",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Piece_Collection_CollectionId",
                table: "Piece",
                column: "CollectionId",
                principalTable: "Collection",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Piece_AspNetUsers_CreatedById",
                table: "Piece",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Piece_Origin_CreationOriginId",
                table: "Piece",
                column: "CreationOriginId",
                principalTable: "Origin",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Piece_Location_CurrentLocationId",
                table: "Piece",
                column: "CurrentLocationId",
                principalTable: "Location",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Piece_Exhibition_ExhibitionId",
                table: "Piece",
                column: "ExhibitionId",
                principalTable: "Exhibition",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Piece_Genre_GenreId",
                table: "Piece",
                column: "GenreId",
                principalTable: "Genre",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Piece_InsurancePolicy_InsurancePolicyId",
                table: "Piece",
                column: "InsurancePolicyId",
                principalTable: "InsurancePolicy",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Piece_AspNetUsers_LastModifiedById",
                table: "Piece",
                column: "LastModifiedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Piece_Medium_MediumId",
                table: "Piece",
                column: "MediumId",
                principalTable: "Medium",
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
                name: "FK_Piece_Location_PermanentLocationId",
                table: "Piece",
                column: "PermanentLocationId",
                principalTable: "Location",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Piece_Upload_PhotoId",
                table: "Piece",
                column: "PhotoId",
                principalTable: "Upload",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Piece_Subgenre_SubgenreId",
                table: "Piece",
                column: "SubgenreId",
                principalTable: "Subgenre",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Piece_SubjectMatter_SubjectMatterId",
                table: "Piece",
                column: "SubjectMatterId",
                principalTable: "SubjectMatter",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PieceArtist_Piece_PieceId",
                table: "PieceArtist",
                column: "PieceId",
                principalTable: "Piece",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PieceTag_Piece_PieceId",
                table: "PieceTag",
                column: "PieceId",
                principalTable: "Piece",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
