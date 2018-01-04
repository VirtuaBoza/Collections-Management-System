using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CoraCorpCM.Data.Migrations
{
    public partial class AddsDomainModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "UserNameIndex",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUserRoles_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles");

            migrationBuilder.AddColumn<int>(
                name: "MuseumId",
                table: "AspNetUsers",
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

            migrationBuilder.CreateTable(
                name: "FundingSource",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FundingSource", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Address1 = table.Column<string>(nullable: true),
                    Address2 = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    ZipCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Museum",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LocationId = table.Column<int>(nullable: true),
                    LogoId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    ShortName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Museum", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Museum_Location_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Location",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Museum_File_LogoId",
                        column: x => x.LogoId,
                        principalTable: "File",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Collection",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MuseumId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Collection", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Collection_Museum_MuseumId",
                        column: x => x.MuseumId,
                        principalTable: "Museum",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Condition",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    MuseumId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Condition", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Condition_Museum_MuseumId",
                        column: x => x.MuseumId,
                        principalTable: "Museum",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Exhibition",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Curator = table.Column<string>(nullable: true),
                    EndDate = table.Column<DateTime>(nullable: false),
                    LocationId = table.Column<int>(nullable: true),
                    MuseumId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    Theme = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exhibition", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exhibition_Location_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Location",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Exhibition_Museum_MuseumId",
                        column: x => x.MuseumId,
                        principalTable: "Museum",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Genre",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MuseumId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genre", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Genre_Museum_MuseumId",
                        column: x => x.MuseumId,
                        principalTable: "Museum",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Inspector",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: true),
                    KnownAs = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    MuseumId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inspector", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inspector_Museum_MuseumId",
                        column: x => x.MuseumId,
                        principalTable: "Museum",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InsurancePolicy",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AmountInsured = table.Column<decimal>(nullable: false),
                    Carrier = table.Column<string>(nullable: true),
                    ExpirationDate = table.Column<DateTime>(nullable: false),
                    MuseumId = table.Column<int>(nullable: true),
                    PolicyNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsurancePolicy", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InsurancePolicy_Museum_MuseumId",
                        column: x => x.MuseumId,
                        principalTable: "Museum",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Medium",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MuseumId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medium", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Medium_Museum_MuseumId",
                        column: x => x.MuseumId,
                        principalTable: "Museum",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Origin",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    City = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    MuseumId = table.Column<int>(nullable: true),
                    State = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Origin", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Origin_Museum_MuseumId",
                        column: x => x.MuseumId,
                        principalTable: "Museum",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PieceSource",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MuseumId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PieceSource", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PieceSource_Museum_MuseumId",
                        column: x => x.MuseumId,
                        principalTable: "Museum",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Subgenre",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MuseumId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subgenre", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subgenre_Museum_MuseumId",
                        column: x => x.MuseumId,
                        principalTable: "Museum",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SubjectMatter",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MuseumId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectMatter", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubjectMatter_Museum_MuseumId",
                        column: x => x.MuseumId,
                        principalTable: "Museum",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tag",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MuseumId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tag", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tag_Museum_MuseumId",
                        column: x => x.MuseumId,
                        principalTable: "Museum",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Loan",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ExhibitionId = table.Column<int>(nullable: true),
                    FromDate = table.Column<DateTime>(nullable: false),
                    FromLocationId = table.Column<int>(nullable: true),
                    LoanAgreementId = table.Column<int>(nullable: true),
                    MuseumId = table.Column<int>(nullable: true),
                    Terms = table.Column<string>(nullable: true),
                    ToDate = table.Column<DateTime>(nullable: false),
                    ToLocationId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Loan_Exhibition_ExhibitionId",
                        column: x => x.ExhibitionId,
                        principalTable: "Exhibition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Loan_Location_FromLocationId",
                        column: x => x.FromLocationId,
                        principalTable: "Location",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Loan_File_LoanAgreementId",
                        column: x => x.LoanAgreementId,
                        principalTable: "File",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Loan_Museum_MuseumId",
                        column: x => x.MuseumId,
                        principalTable: "Museum",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Loan_Location_ToLocationId",
                        column: x => x.ToLocationId,
                        principalTable: "Location",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Artist",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Birthdate = table.Column<DateTime>(nullable: false),
                    Deathdate = table.Column<DateTime>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    KnownAs = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    MuseumId = table.Column<int>(nullable: true),
                    OriginId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artist", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Artist_Museum_MuseumId",
                        column: x => x.MuseumId,
                        principalTable: "Museum",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Artist_Origin_OriginId",
                        column: x => x.OriginId,
                        principalTable: "Origin",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Acquisition",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Cost = table.Column<decimal>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    FundingSourceId = table.Column<int>(nullable: true),
                    LocationId = table.Column<int>(nullable: true),
                    MuseumId = table.Column<int>(nullable: true),
                    PieceSourceId = table.Column<int>(nullable: true),
                    PurchaseReceiptId = table.Column<int>(nullable: true),
                    Terms = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acquisition", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Acquisition_FundingSource_FundingSourceId",
                        column: x => x.FundingSourceId,
                        principalTable: "FundingSource",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Acquisition_Location_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Location",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Acquisition_Museum_MuseumId",
                        column: x => x.MuseumId,
                        principalTable: "Museum",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Acquisition_PieceSource_PieceSourceId",
                        column: x => x.PieceSourceId,
                        principalTable: "PieceSource",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Acquisition_File_PurchaseReceiptId",
                        column: x => x.PurchaseReceiptId,
                        principalTable: "File",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LocationTag",
                columns: table => new
                {
                    LocationId = table.Column<int>(nullable: false),
                    TagId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationTag", x => new { x.LocationId, x.TagId });
                    table.ForeignKey(
                        name: "FK_LocationTag_Location_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Location",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LocationTag_Tag_TagId",
                        column: x => x.TagId,
                        principalTable: "Tag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArtistGenre",
                columns: table => new
                {
                    ArtistId = table.Column<int>(nullable: false),
                    GenreId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtistGenre", x => new { x.ArtistId, x.GenreId });
                    table.ForeignKey(
                        name: "FK_ArtistGenre_Artist_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artist",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArtistGenre_Genre_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genre",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArtistMedium",
                columns: table => new
                {
                    ArtistId = table.Column<int>(nullable: false),
                    MediumId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtistMedium", x => new { x.ArtistId, x.MediumId });
                    table.ForeignKey(
                        name: "FK_ArtistMedium_Artist_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artist",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArtistMedium_Medium_MediumId",
                        column: x => x.MediumId,
                        principalTable: "Medium",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArtistSubgenre",
                columns: table => new
                {
                    ArtistId = table.Column<int>(nullable: false),
                    SubgenreId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtistSubgenre", x => new { x.ArtistId, x.SubgenreId });
                    table.ForeignKey(
                        name: "FK_ArtistSubgenre_Artist_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artist",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArtistSubgenre_Subgenre_SubgenreId",
                        column: x => x.SubgenreId,
                        principalTable: "Subgenre",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArtistSubjectMatter",
                columns: table => new
                {
                    ArtistId = table.Column<int>(nullable: false),
                    SubjectMatterId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtistSubjectMatter", x => new { x.ArtistId, x.SubjectMatterId });
                    table.ForeignKey(
                        name: "FK_ArtistSubjectMatter_Artist_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artist",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArtistSubjectMatter_SubjectMatter_SubjectMatterId",
                        column: x => x.SubjectMatterId,
                        principalTable: "SubjectMatter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArtistTag",
                columns: table => new
                {
                    ArtistId = table.Column<int>(nullable: false),
                    TagId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtistTag", x => new { x.ArtistId, x.TagId });
                    table.ForeignKey(
                        name: "FK_ArtistTag_Artist_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artist",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArtistTag_Tag_TagId",
                        column: x => x.TagId,
                        principalTable: "Tag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Piece",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AccessionNumber = table.Column<string>(nullable: true),
                    AcquisitionId = table.Column<int>(nullable: true),
                    CollectionId = table.Column<int>(nullable: true),
                    CopyrightOwner = table.Column<string>(nullable: true),
                    CopyrightYear = table.Column<DateTime>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    CreatedById = table.Column<string>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    CreationOriginId = table.Column<int>(nullable: true),
                    CurrentLocationId = table.Column<int>(nullable: true),
                    Depth = table.Column<double>(nullable: false),
                    EstimatedValue = table.Column<decimal>(nullable: false),
                    ExhibitionId = table.Column<int>(nullable: true),
                    GenreId = table.Column<int>(nullable: true),
                    Height = table.Column<double>(nullable: false),
                    InsurancePolicyId = table.Column<int>(nullable: true),
                    IsFramed = table.Column<bool>(nullable: false),
                    LastModified = table.Column<DateTime>(nullable: false),
                    LastModifiedById = table.Column<string>(nullable: true),
                    MediumId = table.Column<int>(nullable: true),
                    MuseumId = table.Column<int>(nullable: true),
                    PermanentLocationId = table.Column<int>(nullable: true),
                    PhotoId = table.Column<int>(nullable: true),
                    RecordNumber = table.Column<int>(nullable: false),
                    SubgenreId = table.Column<int>(nullable: true),
                    Subject = table.Column<string>(nullable: true),
                    SubjectMatterId = table.Column<int>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Width = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Piece", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Piece_Acquisition_AcquisitionId",
                        column: x => x.AcquisitionId,
                        principalTable: "Acquisition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Piece_Collection_CollectionId",
                        column: x => x.CollectionId,
                        principalTable: "Collection",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Piece_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Piece_Origin_CreationOriginId",
                        column: x => x.CreationOriginId,
                        principalTable: "Origin",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Piece_Location_CurrentLocationId",
                        column: x => x.CurrentLocationId,
                        principalTable: "Location",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Piece_Exhibition_ExhibitionId",
                        column: x => x.ExhibitionId,
                        principalTable: "Exhibition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Piece_Genre_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genre",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Piece_InsurancePolicy_InsurancePolicyId",
                        column: x => x.InsurancePolicyId,
                        principalTable: "InsurancePolicy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Piece_AspNetUsers_LastModifiedById",
                        column: x => x.LastModifiedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Piece_Medium_MediumId",
                        column: x => x.MediumId,
                        principalTable: "Medium",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Piece_Museum_MuseumId",
                        column: x => x.MuseumId,
                        principalTable: "Museum",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Piece_Location_PermanentLocationId",
                        column: x => x.PermanentLocationId,
                        principalTable: "Location",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Piece_File_PhotoId",
                        column: x => x.PhotoId,
                        principalTable: "File",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Piece_Subgenre_SubgenreId",
                        column: x => x.SubgenreId,
                        principalTable: "Subgenre",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Piece_SubjectMatter_SubjectMatterId",
                        column: x => x.SubjectMatterId,
                        principalTable: "SubjectMatter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ExhibitionPiece",
                columns: table => new
                {
                    ExhibitionId = table.Column<int>(nullable: false),
                    PieceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExhibitionPiece", x => new { x.ExhibitionId, x.PieceId });
                    table.ForeignKey(
                        name: "FK_ExhibitionPiece_Exhibition_ExhibitionId",
                        column: x => x.ExhibitionId,
                        principalTable: "Exhibition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExhibitionPiece_Piece_PieceId",
                        column: x => x.PieceId,
                        principalTable: "Piece",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Inspection",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ConditionId = table.Column<int>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    InspectorId = table.Column<int>(nullable: true),
                    MuseumId = table.Column<int>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    PieceId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inspection", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inspection_Condition_ConditionId",
                        column: x => x.ConditionId,
                        principalTable: "Condition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Inspection_Inspector_InspectorId",
                        column: x => x.InspectorId,
                        principalTable: "Inspector",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Inspection_Museum_MuseumId",
                        column: x => x.MuseumId,
                        principalTable: "Museum",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Inspection_Piece_PieceId",
                        column: x => x.PieceId,
                        principalTable: "Piece",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LoanPiece",
                columns: table => new
                {
                    LoanId = table.Column<int>(nullable: false),
                    PieceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanPiece", x => new { x.LoanId, x.PieceId });
                    table.ForeignKey(
                        name: "FK_LoanPiece_Loan_LoanId",
                        column: x => x.LoanId,
                        principalTable: "Loan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LoanPiece_Piece_PieceId",
                        column: x => x.PieceId,
                        principalTable: "Piece",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PieceArtist",
                columns: table => new
                {
                    PieceId = table.Column<int>(nullable: false),
                    ArtistId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PieceArtist", x => new { x.PieceId, x.ArtistId });
                    table.ForeignKey(
                        name: "FK_PieceArtist_Artist_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artist",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PieceArtist_Piece_PieceId",
                        column: x => x.PieceId,
                        principalTable: "Piece",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PieceTag",
                columns: table => new
                {
                    PieceId = table.Column<int>(nullable: false),
                    TagId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PieceTag", x => new { x.PieceId, x.TagId });
                    table.ForeignKey(
                        name: "FK_PieceTag_Piece_PieceId",
                        column: x => x.PieceId,
                        principalTable: "Piece",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PieceTag_Tag_TagId",
                        column: x => x.TagId,
                        principalTable: "Tag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_MuseumId",
                table: "AspNetUsers",
                column: "MuseumId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Acquisition_FundingSourceId",
                table: "Acquisition",
                column: "FundingSourceId");

            migrationBuilder.CreateIndex(
                name: "IX_Acquisition_LocationId",
                table: "Acquisition",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Acquisition_MuseumId",
                table: "Acquisition",
                column: "MuseumId");

            migrationBuilder.CreateIndex(
                name: "IX_Acquisition_PieceSourceId",
                table: "Acquisition",
                column: "PieceSourceId");

            migrationBuilder.CreateIndex(
                name: "IX_Acquisition_PurchaseReceiptId",
                table: "Acquisition",
                column: "PurchaseReceiptId");

            migrationBuilder.CreateIndex(
                name: "IX_Artist_MuseumId",
                table: "Artist",
                column: "MuseumId");

            migrationBuilder.CreateIndex(
                name: "IX_Artist_OriginId",
                table: "Artist",
                column: "OriginId");

            migrationBuilder.CreateIndex(
                name: "IX_ArtistGenre_GenreId",
                table: "ArtistGenre",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_ArtistMedium_MediumId",
                table: "ArtistMedium",
                column: "MediumId");

            migrationBuilder.CreateIndex(
                name: "IX_ArtistSubgenre_SubgenreId",
                table: "ArtistSubgenre",
                column: "SubgenreId");

            migrationBuilder.CreateIndex(
                name: "IX_ArtistSubjectMatter_SubjectMatterId",
                table: "ArtistSubjectMatter",
                column: "SubjectMatterId");

            migrationBuilder.CreateIndex(
                name: "IX_ArtistTag_TagId",
                table: "ArtistTag",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_Collection_MuseumId",
                table: "Collection",
                column: "MuseumId");

            migrationBuilder.CreateIndex(
                name: "IX_Condition_MuseumId",
                table: "Condition",
                column: "MuseumId");

            migrationBuilder.CreateIndex(
                name: "IX_Exhibition_LocationId",
                table: "Exhibition",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Exhibition_MuseumId",
                table: "Exhibition",
                column: "MuseumId");

            migrationBuilder.CreateIndex(
                name: "IX_ExhibitionPiece_PieceId",
                table: "ExhibitionPiece",
                column: "PieceId");

            migrationBuilder.CreateIndex(
                name: "IX_Genre_MuseumId",
                table: "Genre",
                column: "MuseumId");

            migrationBuilder.CreateIndex(
                name: "IX_Inspection_ConditionId",
                table: "Inspection",
                column: "ConditionId");

            migrationBuilder.CreateIndex(
                name: "IX_Inspection_InspectorId",
                table: "Inspection",
                column: "InspectorId");

            migrationBuilder.CreateIndex(
                name: "IX_Inspection_MuseumId",
                table: "Inspection",
                column: "MuseumId");

            migrationBuilder.CreateIndex(
                name: "IX_Inspection_PieceId",
                table: "Inspection",
                column: "PieceId");

            migrationBuilder.CreateIndex(
                name: "IX_Inspector_MuseumId",
                table: "Inspector",
                column: "MuseumId");

            migrationBuilder.CreateIndex(
                name: "IX_InsurancePolicy_MuseumId",
                table: "InsurancePolicy",
                column: "MuseumId");

            migrationBuilder.CreateIndex(
                name: "IX_Loan_ExhibitionId",
                table: "Loan",
                column: "ExhibitionId");

            migrationBuilder.CreateIndex(
                name: "IX_Loan_FromLocationId",
                table: "Loan",
                column: "FromLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Loan_LoanAgreementId",
                table: "Loan",
                column: "LoanAgreementId");

            migrationBuilder.CreateIndex(
                name: "IX_Loan_MuseumId",
                table: "Loan",
                column: "MuseumId");

            migrationBuilder.CreateIndex(
                name: "IX_Loan_ToLocationId",
                table: "Loan",
                column: "ToLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanPiece_PieceId",
                table: "LoanPiece",
                column: "PieceId");

            migrationBuilder.CreateIndex(
                name: "IX_LocationTag_TagId",
                table: "LocationTag",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_Medium_MuseumId",
                table: "Medium",
                column: "MuseumId");

            migrationBuilder.CreateIndex(
                name: "IX_Museum_LocationId",
                table: "Museum",
                column: "LocationId",
                unique: true,
                filter: "[LocationId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Museum_LogoId",
                table: "Museum",
                column: "LogoId",
                unique: true,
                filter: "[LogoId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Origin_MuseumId",
                table: "Origin",
                column: "MuseumId");

            migrationBuilder.CreateIndex(
                name: "IX_Piece_AcquisitionId",
                table: "Piece",
                column: "AcquisitionId");

            migrationBuilder.CreateIndex(
                name: "IX_Piece_CollectionId",
                table: "Piece",
                column: "CollectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Piece_CreatedById",
                table: "Piece",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Piece_CreationOriginId",
                table: "Piece",
                column: "CreationOriginId");

            migrationBuilder.CreateIndex(
                name: "IX_Piece_CurrentLocationId",
                table: "Piece",
                column: "CurrentLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Piece_ExhibitionId",
                table: "Piece",
                column: "ExhibitionId");

            migrationBuilder.CreateIndex(
                name: "IX_Piece_GenreId",
                table: "Piece",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_Piece_InsurancePolicyId",
                table: "Piece",
                column: "InsurancePolicyId");

            migrationBuilder.CreateIndex(
                name: "IX_Piece_LastModifiedById",
                table: "Piece",
                column: "LastModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_Piece_MediumId",
                table: "Piece",
                column: "MediumId");

            migrationBuilder.CreateIndex(
                name: "IX_Piece_MuseumId",
                table: "Piece",
                column: "MuseumId");

            migrationBuilder.CreateIndex(
                name: "IX_Piece_PermanentLocationId",
                table: "Piece",
                column: "PermanentLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Piece_PhotoId",
                table: "Piece",
                column: "PhotoId");

            migrationBuilder.CreateIndex(
                name: "IX_Piece_SubgenreId",
                table: "Piece",
                column: "SubgenreId");

            migrationBuilder.CreateIndex(
                name: "IX_Piece_SubjectMatterId",
                table: "Piece",
                column: "SubjectMatterId");

            migrationBuilder.CreateIndex(
                name: "IX_PieceArtist_ArtistId",
                table: "PieceArtist",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_PieceSource_MuseumId",
                table: "PieceSource",
                column: "MuseumId");

            migrationBuilder.CreateIndex(
                name: "IX_PieceTag_TagId",
                table: "PieceTag",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_Subgenre_MuseumId",
                table: "Subgenre",
                column: "MuseumId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectMatter_MuseumId",
                table: "SubjectMatter",
                column: "MuseumId");

            migrationBuilder.CreateIndex(
                name: "IX_Tag_MuseumId",
                table: "Tag",
                column: "MuseumId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Museum_MuseumId",
                table: "AspNetUsers",
                column: "MuseumId",
                principalTable: "Museum",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Museum_MuseumId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "ArtistGenre");

            migrationBuilder.DropTable(
                name: "ArtistMedium");

            migrationBuilder.DropTable(
                name: "ArtistSubgenre");

            migrationBuilder.DropTable(
                name: "ArtistSubjectMatter");

            migrationBuilder.DropTable(
                name: "ArtistTag");

            migrationBuilder.DropTable(
                name: "ExhibitionPiece");

            migrationBuilder.DropTable(
                name: "Inspection");

            migrationBuilder.DropTable(
                name: "LoanPiece");

            migrationBuilder.DropTable(
                name: "LocationTag");

            migrationBuilder.DropTable(
                name: "PieceArtist");

            migrationBuilder.DropTable(
                name: "PieceTag");

            migrationBuilder.DropTable(
                name: "Condition");

            migrationBuilder.DropTable(
                name: "Inspector");

            migrationBuilder.DropTable(
                name: "Loan");

            migrationBuilder.DropTable(
                name: "Artist");

            migrationBuilder.DropTable(
                name: "Piece");

            migrationBuilder.DropTable(
                name: "Tag");

            migrationBuilder.DropTable(
                name: "Acquisition");

            migrationBuilder.DropTable(
                name: "Collection");

            migrationBuilder.DropTable(
                name: "Origin");

            migrationBuilder.DropTable(
                name: "Exhibition");

            migrationBuilder.DropTable(
                name: "Genre");

            migrationBuilder.DropTable(
                name: "InsurancePolicy");

            migrationBuilder.DropTable(
                name: "Medium");

            migrationBuilder.DropTable(
                name: "Subgenre");

            migrationBuilder.DropTable(
                name: "SubjectMatter");

            migrationBuilder.DropTable(
                name: "FundingSource");

            migrationBuilder.DropTable(
                name: "PieceSource");

            migrationBuilder.DropTable(
                name: "Museum");

            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropTable(
                name: "File");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_MuseumId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "UserNameIndex",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles");

            migrationBuilder.DropColumn(
                name: "MuseumId",
                table: "AspNetUsers");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_UserId",
                table: "AspNetUserRoles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName");
        }
    }
}
