using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CoraCorpCM.Migrations
{
    public partial class AddsDbSets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Acquisition_FundingSource_FundingSourceId",
                table: "Acquisition");

            migrationBuilder.DropForeignKey(
                name: "FK_Acquisition_Location_LocationId",
                table: "Acquisition");

            migrationBuilder.DropForeignKey(
                name: "FK_Acquisition_Museums_MuseumId",
                table: "Acquisition");

            migrationBuilder.DropForeignKey(
                name: "FK_Acquisition_PieceSource_PieceSourceId",
                table: "Acquisition");

            migrationBuilder.DropForeignKey(
                name: "FK_Acquisition_Upload_PurchaseReceiptId",
                table: "Acquisition");

            migrationBuilder.DropForeignKey(
                name: "FK_Artist_Museums_MuseumId",
                table: "Artist");

            migrationBuilder.DropForeignKey(
                name: "FK_Artist_Origin_OriginId",
                table: "Artist");

            migrationBuilder.DropForeignKey(
                name: "FK_ArtistGenre_Artist_ArtistId",
                table: "ArtistGenre");

            migrationBuilder.DropForeignKey(
                name: "FK_ArtistGenre_Genre_GenreId",
                table: "ArtistGenre");

            migrationBuilder.DropForeignKey(
                name: "FK_ArtistMedium_Artist_ArtistId",
                table: "ArtistMedium");

            migrationBuilder.DropForeignKey(
                name: "FK_ArtistMedium_Medium_MediumId",
                table: "ArtistMedium");

            migrationBuilder.DropForeignKey(
                name: "FK_ArtistSubgenre_Artist_ArtistId",
                table: "ArtistSubgenre");

            migrationBuilder.DropForeignKey(
                name: "FK_ArtistSubgenre_Subgenre_SubgenreId",
                table: "ArtistSubgenre");

            migrationBuilder.DropForeignKey(
                name: "FK_ArtistSubjectMatter_Artist_ArtistId",
                table: "ArtistSubjectMatter");

            migrationBuilder.DropForeignKey(
                name: "FK_ArtistSubjectMatter_SubjectMatter_SubjectMatterId",
                table: "ArtistSubjectMatter");

            migrationBuilder.DropForeignKey(
                name: "FK_ArtistTag_Artist_ArtistId",
                table: "ArtistTag");

            migrationBuilder.DropForeignKey(
                name: "FK_Exhibition_Location_LocationId",
                table: "Exhibition");

            migrationBuilder.DropForeignKey(
                name: "FK_Genre_Museums_MuseumId",
                table: "Genre");

            migrationBuilder.DropForeignKey(
                name: "FK_InsurancePolicy_Museums_MuseumId",
                table: "InsurancePolicy");

            migrationBuilder.DropForeignKey(
                name: "FK_Loan_Location_FromLocationId",
                table: "Loan");

            migrationBuilder.DropForeignKey(
                name: "FK_Loan_Location_ToLocationId",
                table: "Loan");

            migrationBuilder.DropForeignKey(
                name: "FK_Location_Countries_CountryId",
                table: "Location");

            migrationBuilder.DropForeignKey(
                name: "FK_Location_Museums_MuseumId",
                table: "Location");

            migrationBuilder.DropForeignKey(
                name: "FK_LocationTag_Location_LocationId",
                table: "LocationTag");

            migrationBuilder.DropForeignKey(
                name: "FK_Medium_Museums_MuseumId",
                table: "Medium");

            migrationBuilder.DropForeignKey(
                name: "FK_PieceArtist_Artist_ArtistId",
                table: "PieceArtist");

            migrationBuilder.DropForeignKey(
                name: "FK_Pieces_Acquisition_AcquisitionId",
                table: "Pieces");

            migrationBuilder.DropForeignKey(
                name: "FK_Pieces_Location_CurrentLocationId",
                table: "Pieces");

            migrationBuilder.DropForeignKey(
                name: "FK_Pieces_Genre_GenreId",
                table: "Pieces");

            migrationBuilder.DropForeignKey(
                name: "FK_Pieces_InsurancePolicy_InsurancePolicyId",
                table: "Pieces");

            migrationBuilder.DropForeignKey(
                name: "FK_Pieces_Medium_MediumId",
                table: "Pieces");

            migrationBuilder.DropForeignKey(
                name: "FK_Pieces_Location_PermanentLocationId",
                table: "Pieces");

            migrationBuilder.DropForeignKey(
                name: "FK_Pieces_Subgenre_SubgenreId",
                table: "Pieces");

            migrationBuilder.DropForeignKey(
                name: "FK_Pieces_SubjectMatter_SubjectMatterId",
                table: "Pieces");

            migrationBuilder.DropForeignKey(
                name: "FK_PieceSource_Museums_MuseumId",
                table: "PieceSource");

            migrationBuilder.DropForeignKey(
                name: "FK_Subgenre_Museums_MuseumId",
                table: "Subgenre");

            migrationBuilder.DropForeignKey(
                name: "FK_SubjectMatter_Museums_MuseumId",
                table: "SubjectMatter");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubjectMatter",
                table: "SubjectMatter");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Subgenre",
                table: "Subgenre");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PieceSource",
                table: "PieceSource");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Medium",
                table: "Medium");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Location",
                table: "Location");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InsurancePolicy",
                table: "InsurancePolicy");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Genre",
                table: "Genre");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FundingSource",
                table: "FundingSource");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Artist",
                table: "Artist");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Acquisition",
                table: "Acquisition");

            migrationBuilder.RenameTable(
                name: "SubjectMatter",
                newName: "SubjectMatters");

            migrationBuilder.RenameTable(
                name: "Subgenre",
                newName: "Subgenres");

            migrationBuilder.RenameTable(
                name: "PieceSource",
                newName: "PieceSources");

            migrationBuilder.RenameTable(
                name: "Medium",
                newName: "Media");

            migrationBuilder.RenameTable(
                name: "Location",
                newName: "Locations");

            migrationBuilder.RenameTable(
                name: "InsurancePolicy",
                newName: "InsurancePolicies");

            migrationBuilder.RenameTable(
                name: "Genre",
                newName: "Genres");

            migrationBuilder.RenameTable(
                name: "FundingSource",
                newName: "FundingSources");

            migrationBuilder.RenameTable(
                name: "Artist",
                newName: "Artists");

            migrationBuilder.RenameTable(
                name: "Acquisition",
                newName: "Acquisitions");

            migrationBuilder.RenameIndex(
                name: "IX_SubjectMatter_MuseumId",
                table: "SubjectMatters",
                newName: "IX_SubjectMatters_MuseumId");

            migrationBuilder.RenameIndex(
                name: "IX_Subgenre_MuseumId",
                table: "Subgenres",
                newName: "IX_Subgenres_MuseumId");

            migrationBuilder.RenameIndex(
                name: "IX_PieceSource_MuseumId",
                table: "PieceSources",
                newName: "IX_PieceSources_MuseumId");

            migrationBuilder.RenameIndex(
                name: "IX_Medium_MuseumId",
                table: "Media",
                newName: "IX_Media_MuseumId");

            migrationBuilder.RenameIndex(
                name: "IX_Location_MuseumId",
                table: "Locations",
                newName: "IX_Locations_MuseumId");

            migrationBuilder.RenameIndex(
                name: "IX_Location_CountryId",
                table: "Locations",
                newName: "IX_Locations_CountryId");

            migrationBuilder.RenameIndex(
                name: "IX_InsurancePolicy_MuseumId",
                table: "InsurancePolicies",
                newName: "IX_InsurancePolicies_MuseumId");

            migrationBuilder.RenameIndex(
                name: "IX_Genre_MuseumId",
                table: "Genres",
                newName: "IX_Genres_MuseumId");

            migrationBuilder.RenameIndex(
                name: "IX_Artist_OriginId",
                table: "Artists",
                newName: "IX_Artists_OriginId");

            migrationBuilder.RenameIndex(
                name: "IX_Artist_MuseumId",
                table: "Artists",
                newName: "IX_Artists_MuseumId");

            migrationBuilder.RenameIndex(
                name: "IX_Acquisition_PurchaseReceiptId",
                table: "Acquisitions",
                newName: "IX_Acquisitions_PurchaseReceiptId");

            migrationBuilder.RenameIndex(
                name: "IX_Acquisition_PieceSourceId",
                table: "Acquisitions",
                newName: "IX_Acquisitions_PieceSourceId");

            migrationBuilder.RenameIndex(
                name: "IX_Acquisition_MuseumId",
                table: "Acquisitions",
                newName: "IX_Acquisitions_MuseumId");

            migrationBuilder.RenameIndex(
                name: "IX_Acquisition_LocationId",
                table: "Acquisitions",
                newName: "IX_Acquisitions_LocationId");

            migrationBuilder.RenameIndex(
                name: "IX_Acquisition_FundingSourceId",
                table: "Acquisitions",
                newName: "IX_Acquisitions_FundingSourceId");

            migrationBuilder.AddColumn<int>(
                name: "MuseumId",
                table: "FundingSources",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubjectMatters",
                table: "SubjectMatters",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Subgenres",
                table: "Subgenres",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PieceSources",
                table: "PieceSources",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Media",
                table: "Media",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Locations",
                table: "Locations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InsurancePolicies",
                table: "InsurancePolicies",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Genres",
                table: "Genres",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FundingSources",
                table: "FundingSources",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Artists",
                table: "Artists",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Acquisitions",
                table: "Acquisitions",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_FundingSources_MuseumId",
                table: "FundingSources",
                column: "MuseumId");

            migrationBuilder.AddForeignKey(
                name: "FK_Acquisitions_FundingSources_FundingSourceId",
                table: "Acquisitions",
                column: "FundingSourceId",
                principalTable: "FundingSources",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Acquisitions_Locations_LocationId",
                table: "Acquisitions",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Acquisitions_Museums_MuseumId",
                table: "Acquisitions",
                column: "MuseumId",
                principalTable: "Museums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Acquisitions_PieceSources_PieceSourceId",
                table: "Acquisitions",
                column: "PieceSourceId",
                principalTable: "PieceSources",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Acquisitions_Upload_PurchaseReceiptId",
                table: "Acquisitions",
                column: "PurchaseReceiptId",
                principalTable: "Upload",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ArtistGenre_Artists_ArtistId",
                table: "ArtistGenre",
                column: "ArtistId",
                principalTable: "Artists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ArtistGenre_Genres_GenreId",
                table: "ArtistGenre",
                column: "GenreId",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
                name: "FK_Artists_Museums_MuseumId",
                table: "Artists",
                column: "MuseumId",
                principalTable: "Museums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Artists_Origin_OriginId",
                table: "Artists",
                column: "OriginId",
                principalTable: "Origin",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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
                name: "FK_Exhibition_Locations_LocationId",
                table: "Exhibition",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FundingSources_Museums_MuseumId",
                table: "FundingSources",
                column: "MuseumId",
                principalTable: "Museums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Genres_Museums_MuseumId",
                table: "Genres",
                column: "MuseumId",
                principalTable: "Museums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InsurancePolicies_Museums_MuseumId",
                table: "InsurancePolicies",
                column: "MuseumId",
                principalTable: "Museums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Loan_Locations_FromLocationId",
                table: "Loan",
                column: "FromLocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Loan_Locations_ToLocationId",
                table: "Loan",
                column: "ToLocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Countries_CountryId",
                table: "Locations",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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
                name: "FK_Media_Museums_MuseumId",
                table: "Media",
                column: "MuseumId",
                principalTable: "Museums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PieceArtist_Artists_ArtistId",
                table: "PieceArtist",
                column: "ArtistId",
                principalTable: "Artists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pieces_Acquisitions_AcquisitionId",
                table: "Pieces",
                column: "AcquisitionId",
                principalTable: "Acquisitions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pieces_Locations_CurrentLocationId",
                table: "Pieces",
                column: "CurrentLocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pieces_Genres_GenreId",
                table: "Pieces",
                column: "GenreId",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pieces_InsurancePolicies_InsurancePolicyId",
                table: "Pieces",
                column: "InsurancePolicyId",
                principalTable: "InsurancePolicies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pieces_Media_MediumId",
                table: "Pieces",
                column: "MediumId",
                principalTable: "Media",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pieces_Locations_PermanentLocationId",
                table: "Pieces",
                column: "PermanentLocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pieces_Subgenres_SubgenreId",
                table: "Pieces",
                column: "SubgenreId",
                principalTable: "Subgenres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pieces_SubjectMatters_SubjectMatterId",
                table: "Pieces",
                column: "SubjectMatterId",
                principalTable: "SubjectMatters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PieceSources_Museums_MuseumId",
                table: "PieceSources",
                column: "MuseumId",
                principalTable: "Museums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Acquisitions_FundingSources_FundingSourceId",
                table: "Acquisitions");

            migrationBuilder.DropForeignKey(
                name: "FK_Acquisitions_Locations_LocationId",
                table: "Acquisitions");

            migrationBuilder.DropForeignKey(
                name: "FK_Acquisitions_Museums_MuseumId",
                table: "Acquisitions");

            migrationBuilder.DropForeignKey(
                name: "FK_Acquisitions_PieceSources_PieceSourceId",
                table: "Acquisitions");

            migrationBuilder.DropForeignKey(
                name: "FK_Acquisitions_Upload_PurchaseReceiptId",
                table: "Acquisitions");

            migrationBuilder.DropForeignKey(
                name: "FK_ArtistGenre_Artists_ArtistId",
                table: "ArtistGenre");

            migrationBuilder.DropForeignKey(
                name: "FK_ArtistGenre_Genres_GenreId",
                table: "ArtistGenre");

            migrationBuilder.DropForeignKey(
                name: "FK_ArtistMedium_Artists_ArtistId",
                table: "ArtistMedium");

            migrationBuilder.DropForeignKey(
                name: "FK_ArtistMedium_Media_MediumId",
                table: "ArtistMedium");

            migrationBuilder.DropForeignKey(
                name: "FK_Artists_Museums_MuseumId",
                table: "Artists");

            migrationBuilder.DropForeignKey(
                name: "FK_Artists_Origin_OriginId",
                table: "Artists");

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
                name: "FK_Exhibition_Locations_LocationId",
                table: "Exhibition");

            migrationBuilder.DropForeignKey(
                name: "FK_FundingSources_Museums_MuseumId",
                table: "FundingSources");

            migrationBuilder.DropForeignKey(
                name: "FK_Genres_Museums_MuseumId",
                table: "Genres");

            migrationBuilder.DropForeignKey(
                name: "FK_InsurancePolicies_Museums_MuseumId",
                table: "InsurancePolicies");

            migrationBuilder.DropForeignKey(
                name: "FK_Loan_Locations_FromLocationId",
                table: "Loan");

            migrationBuilder.DropForeignKey(
                name: "FK_Loan_Locations_ToLocationId",
                table: "Loan");

            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Countries_CountryId",
                table: "Locations");

            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Museums_MuseumId",
                table: "Locations");

            migrationBuilder.DropForeignKey(
                name: "FK_LocationTag_Locations_LocationId",
                table: "LocationTag");

            migrationBuilder.DropForeignKey(
                name: "FK_Media_Museums_MuseumId",
                table: "Media");

            migrationBuilder.DropForeignKey(
                name: "FK_PieceArtist_Artists_ArtistId",
                table: "PieceArtist");

            migrationBuilder.DropForeignKey(
                name: "FK_Pieces_Acquisitions_AcquisitionId",
                table: "Pieces");

            migrationBuilder.DropForeignKey(
                name: "FK_Pieces_Locations_CurrentLocationId",
                table: "Pieces");

            migrationBuilder.DropForeignKey(
                name: "FK_Pieces_Genres_GenreId",
                table: "Pieces");

            migrationBuilder.DropForeignKey(
                name: "FK_Pieces_InsurancePolicies_InsurancePolicyId",
                table: "Pieces");

            migrationBuilder.DropForeignKey(
                name: "FK_Pieces_Media_MediumId",
                table: "Pieces");

            migrationBuilder.DropForeignKey(
                name: "FK_Pieces_Locations_PermanentLocationId",
                table: "Pieces");

            migrationBuilder.DropForeignKey(
                name: "FK_Pieces_Subgenres_SubgenreId",
                table: "Pieces");

            migrationBuilder.DropForeignKey(
                name: "FK_Pieces_SubjectMatters_SubjectMatterId",
                table: "Pieces");

            migrationBuilder.DropForeignKey(
                name: "FK_PieceSources_Museums_MuseumId",
                table: "PieceSources");

            migrationBuilder.DropForeignKey(
                name: "FK_Subgenres_Museums_MuseumId",
                table: "Subgenres");

            migrationBuilder.DropForeignKey(
                name: "FK_SubjectMatters_Museums_MuseumId",
                table: "SubjectMatters");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubjectMatters",
                table: "SubjectMatters");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Subgenres",
                table: "Subgenres");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PieceSources",
                table: "PieceSources");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Media",
                table: "Media");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Locations",
                table: "Locations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InsurancePolicies",
                table: "InsurancePolicies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Genres",
                table: "Genres");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FundingSources",
                table: "FundingSources");

            migrationBuilder.DropIndex(
                name: "IX_FundingSources_MuseumId",
                table: "FundingSources");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Artists",
                table: "Artists");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Acquisitions",
                table: "Acquisitions");

            migrationBuilder.DropColumn(
                name: "MuseumId",
                table: "FundingSources");

            migrationBuilder.RenameTable(
                name: "SubjectMatters",
                newName: "SubjectMatter");

            migrationBuilder.RenameTable(
                name: "Subgenres",
                newName: "Subgenre");

            migrationBuilder.RenameTable(
                name: "PieceSources",
                newName: "PieceSource");

            migrationBuilder.RenameTable(
                name: "Media",
                newName: "Medium");

            migrationBuilder.RenameTable(
                name: "Locations",
                newName: "Location");

            migrationBuilder.RenameTable(
                name: "InsurancePolicies",
                newName: "InsurancePolicy");

            migrationBuilder.RenameTable(
                name: "Genres",
                newName: "Genre");

            migrationBuilder.RenameTable(
                name: "FundingSources",
                newName: "FundingSource");

            migrationBuilder.RenameTable(
                name: "Artists",
                newName: "Artist");

            migrationBuilder.RenameTable(
                name: "Acquisitions",
                newName: "Acquisition");

            migrationBuilder.RenameIndex(
                name: "IX_SubjectMatters_MuseumId",
                table: "SubjectMatter",
                newName: "IX_SubjectMatter_MuseumId");

            migrationBuilder.RenameIndex(
                name: "IX_Subgenres_MuseumId",
                table: "Subgenre",
                newName: "IX_Subgenre_MuseumId");

            migrationBuilder.RenameIndex(
                name: "IX_PieceSources_MuseumId",
                table: "PieceSource",
                newName: "IX_PieceSource_MuseumId");

            migrationBuilder.RenameIndex(
                name: "IX_Media_MuseumId",
                table: "Medium",
                newName: "IX_Medium_MuseumId");

            migrationBuilder.RenameIndex(
                name: "IX_Locations_MuseumId",
                table: "Location",
                newName: "IX_Location_MuseumId");

            migrationBuilder.RenameIndex(
                name: "IX_Locations_CountryId",
                table: "Location",
                newName: "IX_Location_CountryId");

            migrationBuilder.RenameIndex(
                name: "IX_InsurancePolicies_MuseumId",
                table: "InsurancePolicy",
                newName: "IX_InsurancePolicy_MuseumId");

            migrationBuilder.RenameIndex(
                name: "IX_Genres_MuseumId",
                table: "Genre",
                newName: "IX_Genre_MuseumId");

            migrationBuilder.RenameIndex(
                name: "IX_Artists_OriginId",
                table: "Artist",
                newName: "IX_Artist_OriginId");

            migrationBuilder.RenameIndex(
                name: "IX_Artists_MuseumId",
                table: "Artist",
                newName: "IX_Artist_MuseumId");

            migrationBuilder.RenameIndex(
                name: "IX_Acquisitions_PurchaseReceiptId",
                table: "Acquisition",
                newName: "IX_Acquisition_PurchaseReceiptId");

            migrationBuilder.RenameIndex(
                name: "IX_Acquisitions_PieceSourceId",
                table: "Acquisition",
                newName: "IX_Acquisition_PieceSourceId");

            migrationBuilder.RenameIndex(
                name: "IX_Acquisitions_MuseumId",
                table: "Acquisition",
                newName: "IX_Acquisition_MuseumId");

            migrationBuilder.RenameIndex(
                name: "IX_Acquisitions_LocationId",
                table: "Acquisition",
                newName: "IX_Acquisition_LocationId");

            migrationBuilder.RenameIndex(
                name: "IX_Acquisitions_FundingSourceId",
                table: "Acquisition",
                newName: "IX_Acquisition_FundingSourceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubjectMatter",
                table: "SubjectMatter",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Subgenre",
                table: "Subgenre",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PieceSource",
                table: "PieceSource",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Medium",
                table: "Medium",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Location",
                table: "Location",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InsurancePolicy",
                table: "InsurancePolicy",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Genre",
                table: "Genre",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FundingSource",
                table: "FundingSource",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Artist",
                table: "Artist",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Acquisition",
                table: "Acquisition",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Acquisition_FundingSource_FundingSourceId",
                table: "Acquisition",
                column: "FundingSourceId",
                principalTable: "FundingSource",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Acquisition_Location_LocationId",
                table: "Acquisition",
                column: "LocationId",
                principalTable: "Location",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Acquisition_Museums_MuseumId",
                table: "Acquisition",
                column: "MuseumId",
                principalTable: "Museums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Acquisition_PieceSource_PieceSourceId",
                table: "Acquisition",
                column: "PieceSourceId",
                principalTable: "PieceSource",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Acquisition_Upload_PurchaseReceiptId",
                table: "Acquisition",
                column: "PurchaseReceiptId",
                principalTable: "Upload",
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
                name: "FK_Artist_Origin_OriginId",
                table: "Artist",
                column: "OriginId",
                principalTable: "Origin",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ArtistGenre_Artist_ArtistId",
                table: "ArtistGenre",
                column: "ArtistId",
                principalTable: "Artist",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ArtistGenre_Genre_GenreId",
                table: "ArtistGenre",
                column: "GenreId",
                principalTable: "Genre",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ArtistMedium_Artist_ArtistId",
                table: "ArtistMedium",
                column: "ArtistId",
                principalTable: "Artist",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ArtistMedium_Medium_MediumId",
                table: "ArtistMedium",
                column: "MediumId",
                principalTable: "Medium",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ArtistSubgenre_Artist_ArtistId",
                table: "ArtistSubgenre",
                column: "ArtistId",
                principalTable: "Artist",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ArtistSubgenre_Subgenre_SubgenreId",
                table: "ArtistSubgenre",
                column: "SubgenreId",
                principalTable: "Subgenre",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ArtistSubjectMatter_Artist_ArtistId",
                table: "ArtistSubjectMatter",
                column: "ArtistId",
                principalTable: "Artist",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ArtistSubjectMatter_SubjectMatter_SubjectMatterId",
                table: "ArtistSubjectMatter",
                column: "SubjectMatterId",
                principalTable: "SubjectMatter",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ArtistTag_Artist_ArtistId",
                table: "ArtistTag",
                column: "ArtistId",
                principalTable: "Artist",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Exhibition_Location_LocationId",
                table: "Exhibition",
                column: "LocationId",
                principalTable: "Location",
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
                name: "FK_InsurancePolicy_Museums_MuseumId",
                table: "InsurancePolicy",
                column: "MuseumId",
                principalTable: "Museums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Loan_Location_FromLocationId",
                table: "Loan",
                column: "FromLocationId",
                principalTable: "Location",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Loan_Location_ToLocationId",
                table: "Loan",
                column: "ToLocationId",
                principalTable: "Location",
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
                name: "FK_Location_Museums_MuseumId",
                table: "Location",
                column: "MuseumId",
                principalTable: "Museums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LocationTag_Location_LocationId",
                table: "LocationTag",
                column: "LocationId",
                principalTable: "Location",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Medium_Museums_MuseumId",
                table: "Medium",
                column: "MuseumId",
                principalTable: "Museums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PieceArtist_Artist_ArtistId",
                table: "PieceArtist",
                column: "ArtistId",
                principalTable: "Artist",
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
                name: "FK_Pieces_Location_CurrentLocationId",
                table: "Pieces",
                column: "CurrentLocationId",
                principalTable: "Location",
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
                name: "FK_Pieces_Medium_MediumId",
                table: "Pieces",
                column: "MediumId",
                principalTable: "Medium",
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
        }
    }
}
