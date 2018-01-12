using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CoraCorpCM.Migrations
{
    public partial class NewInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Genc2A = table.Column<string>(maxLength: 2, nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
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
                name: "UnitsOfMeasure",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Abbreviation = table.Column<string>(nullable: true),
                    UnitOfMeasurement = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitsOfMeasure", x => x.Id);
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

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Museums",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Address1 = table.Column<string>(nullable: true),
                    Address2 = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    CountryId = table.Column<int>(nullable: true),
                    LogoId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    RecordCount = table.Column<int>(nullable: false),
                    ShortName = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    ZipCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Museums", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Museums_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Museums_Upload_LogoId",
                        column: x => x.LogoId,
                        principalTable: "Upload",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    MuseumId = table.Column<int>(nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    PasswordHash = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    SecurityStamp = table.Column<string>(nullable: true),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Museums_MuseumId",
                        column: x => x.MuseumId,
                        principalTable: "Museums",
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
                        name: "FK_Collection_Museums_MuseumId",
                        column: x => x.MuseumId,
                        principalTable: "Museums",
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
                        name: "FK_Condition_Museums_MuseumId",
                        column: x => x.MuseumId,
                        principalTable: "Museums",
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
                        name: "FK_Genre_Museums_MuseumId",
                        column: x => x.MuseumId,
                        principalTable: "Museums",
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
                        name: "FK_Inspector_Museums_MuseumId",
                        column: x => x.MuseumId,
                        principalTable: "Museums",
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
                    ExpirationDate = table.Column<DateTime>(type: "date", nullable: false),
                    MuseumId = table.Column<int>(nullable: true),
                    PolicyNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsurancePolicy", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InsurancePolicy_Museums_MuseumId",
                        column: x => x.MuseumId,
                        principalTable: "Museums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    CountryId = table.Column<int>(nullable: true),
                    MuseumId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    ZipCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Location_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Location_Museums_MuseumId",
                        column: x => x.MuseumId,
                        principalTable: "Museums",
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
                        name: "FK_Medium_Museums_MuseumId",
                        column: x => x.MuseumId,
                        principalTable: "Museums",
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
                    CountryId = table.Column<int>(nullable: true),
                    MuseumId = table.Column<int>(nullable: true),
                    State = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Origin", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Origin_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Origin_Museums_MuseumId",
                        column: x => x.MuseumId,
                        principalTable: "Museums",
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
                        name: "FK_PieceSource_Museums_MuseumId",
                        column: x => x.MuseumId,
                        principalTable: "Museums",
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
                        name: "FK_Subgenre_Museums_MuseumId",
                        column: x => x.MuseumId,
                        principalTable: "Museums",
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
                        name: "FK_SubjectMatter_Museums_MuseumId",
                        column: x => x.MuseumId,
                        principalTable: "Museums",
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
                        name: "FK_Tag_Museums_MuseumId",
                        column: x => x.MuseumId,
                        principalTable: "Museums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                        name: "FK_Exhibition_Museums_MuseumId",
                        column: x => x.MuseumId,
                        principalTable: "Museums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Artist",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Birthdate = table.Column<DateTime>(type: "date", nullable: false),
                    Deathdate = table.Column<DateTime>(type: "date", nullable: false),
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
                        name: "FK_Artist_Museums_MuseumId",
                        column: x => x.MuseumId,
                        principalTable: "Museums",
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
                    Date = table.Column<DateTime>(type: "date", nullable: false),
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
                        name: "FK_Acquisition_Museums_MuseumId",
                        column: x => x.MuseumId,
                        principalTable: "Museums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Acquisition_PieceSource_PieceSourceId",
                        column: x => x.PieceSourceId,
                        principalTable: "PieceSource",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Acquisition_Upload_PurchaseReceiptId",
                        column: x => x.PurchaseReceiptId,
                        principalTable: "Upload",
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
                        name: "FK_Loan_Upload_LoanAgreementId",
                        column: x => x.LoanAgreementId,
                        principalTable: "Upload",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Loan_Museums_MuseumId",
                        column: x => x.MuseumId,
                        principalTable: "Museums",
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
                name: "Pieces",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AccessionNumber = table.Column<string>(nullable: true),
                    AcquisitionId = table.Column<int>(nullable: true),
                    CollectionId = table.Column<int>(nullable: true),
                    CopyrightOwner = table.Column<string>(nullable: true),
                    CopyrightYear = table.Column<int>(nullable: false),
                    CreationDay = table.Column<int>(nullable: false),
                    CreationMonth = table.Column<int>(nullable: false),
                    CreationOriginId = table.Column<int>(nullable: true),
                    CreationYear = table.Column<int>(nullable: false),
                    CurrentLocationId = table.Column<int>(nullable: true),
                    Depth = table.Column<double>(nullable: false),
                    EstimatedValue = table.Column<decimal>(nullable: false),
                    ExhibitionId = table.Column<int>(nullable: true),
                    GenreId = table.Column<int>(nullable: true),
                    Height = table.Column<double>(nullable: false),
                    InsurancePolicyId = table.Column<int>(nullable: true),
                    IsArchived = table.Column<bool>(nullable: false),
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
                    UnitOfMeasureId = table.Column<int>(nullable: true),
                    Width = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pieces", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pieces_Acquisition_AcquisitionId",
                        column: x => x.AcquisitionId,
                        principalTable: "Acquisition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pieces_Collection_CollectionId",
                        column: x => x.CollectionId,
                        principalTable: "Collection",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pieces_Origin_CreationOriginId",
                        column: x => x.CreationOriginId,
                        principalTable: "Origin",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pieces_Location_CurrentLocationId",
                        column: x => x.CurrentLocationId,
                        principalTable: "Location",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pieces_Exhibition_ExhibitionId",
                        column: x => x.ExhibitionId,
                        principalTable: "Exhibition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pieces_Genre_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genre",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pieces_InsurancePolicy_InsurancePolicyId",
                        column: x => x.InsurancePolicyId,
                        principalTable: "InsurancePolicy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pieces_AspNetUsers_LastModifiedById",
                        column: x => x.LastModifiedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pieces_Medium_MediumId",
                        column: x => x.MediumId,
                        principalTable: "Medium",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pieces_Museums_MuseumId",
                        column: x => x.MuseumId,
                        principalTable: "Museums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pieces_Location_PermanentLocationId",
                        column: x => x.PermanentLocationId,
                        principalTable: "Location",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pieces_Upload_PhotoId",
                        column: x => x.PhotoId,
                        principalTable: "Upload",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pieces_Subgenre_SubgenreId",
                        column: x => x.SubgenreId,
                        principalTable: "Subgenre",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pieces_SubjectMatter_SubjectMatterId",
                        column: x => x.SubjectMatterId,
                        principalTable: "SubjectMatter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pieces_UnitsOfMeasure_UnitOfMeasureId",
                        column: x => x.UnitOfMeasureId,
                        principalTable: "UnitsOfMeasure",
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
                        name: "FK_ExhibitionPiece_Pieces_PieceId",
                        column: x => x.PieceId,
                        principalTable: "Pieces",
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
                    Date = table.Column<DateTime>(type: "date", nullable: false),
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
                        name: "FK_Inspection_Museums_MuseumId",
                        column: x => x.MuseumId,
                        principalTable: "Museums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Inspection_Pieces_PieceId",
                        column: x => x.PieceId,
                        principalTable: "Pieces",
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
                        name: "FK_LoanPiece_Pieces_PieceId",
                        column: x => x.PieceId,
                        principalTable: "Pieces",
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
                        name: "FK_PieceArtist_Pieces_PieceId",
                        column: x => x.PieceId,
                        principalTable: "Pieces",
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
                        name: "FK_PieceTag_Pieces_PieceId",
                        column: x => x.PieceId,
                        principalTable: "Pieces",
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
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_MuseumId",
                table: "AspNetUsers",
                column: "MuseumId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

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
                name: "IX_Location_CountryId",
                table: "Location",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Location_MuseumId",
                table: "Location",
                column: "MuseumId");

            migrationBuilder.CreateIndex(
                name: "IX_LocationTag_TagId",
                table: "LocationTag",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_Medium_MuseumId",
                table: "Medium",
                column: "MuseumId");

            migrationBuilder.CreateIndex(
                name: "IX_Museums_CountryId",
                table: "Museums",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Museums_LogoId",
                table: "Museums",
                column: "LogoId",
                unique: true,
                filter: "[LogoId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Origin_CountryId",
                table: "Origin",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Origin_MuseumId",
                table: "Origin",
                column: "MuseumId");

            migrationBuilder.CreateIndex(
                name: "IX_PieceArtist_ArtistId",
                table: "PieceArtist",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_Pieces_AcquisitionId",
                table: "Pieces",
                column: "AcquisitionId");

            migrationBuilder.CreateIndex(
                name: "IX_Pieces_CollectionId",
                table: "Pieces",
                column: "CollectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Pieces_CreationOriginId",
                table: "Pieces",
                column: "CreationOriginId");

            migrationBuilder.CreateIndex(
                name: "IX_Pieces_CurrentLocationId",
                table: "Pieces",
                column: "CurrentLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Pieces_ExhibitionId",
                table: "Pieces",
                column: "ExhibitionId");

            migrationBuilder.CreateIndex(
                name: "IX_Pieces_GenreId",
                table: "Pieces",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_Pieces_InsurancePolicyId",
                table: "Pieces",
                column: "InsurancePolicyId");

            migrationBuilder.CreateIndex(
                name: "IX_Pieces_LastModifiedById",
                table: "Pieces",
                column: "LastModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_Pieces_MediumId",
                table: "Pieces",
                column: "MediumId");

            migrationBuilder.CreateIndex(
                name: "IX_Pieces_MuseumId",
                table: "Pieces",
                column: "MuseumId");

            migrationBuilder.CreateIndex(
                name: "IX_Pieces_PermanentLocationId",
                table: "Pieces",
                column: "PermanentLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Pieces_PhotoId",
                table: "Pieces",
                column: "PhotoId");

            migrationBuilder.CreateIndex(
                name: "IX_Pieces_SubgenreId",
                table: "Pieces",
                column: "SubgenreId");

            migrationBuilder.CreateIndex(
                name: "IX_Pieces_SubjectMatterId",
                table: "Pieces",
                column: "SubjectMatterId");

            migrationBuilder.CreateIndex(
                name: "IX_Pieces_UnitOfMeasureId",
                table: "Pieces",
                column: "UnitOfMeasureId");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

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
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Condition");

            migrationBuilder.DropTable(
                name: "Inspector");

            migrationBuilder.DropTable(
                name: "Loan");

            migrationBuilder.DropTable(
                name: "Artist");

            migrationBuilder.DropTable(
                name: "Pieces");

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
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Medium");

            migrationBuilder.DropTable(
                name: "Subgenre");

            migrationBuilder.DropTable(
                name: "SubjectMatter");

            migrationBuilder.DropTable(
                name: "UnitsOfMeasure");

            migrationBuilder.DropTable(
                name: "FundingSource");

            migrationBuilder.DropTable(
                name: "PieceSource");

            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropTable(
                name: "Museums");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Upload");
        }
    }
}
