using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CoraCorpCM.Models;

namespace CoraCorpCM.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Museum> Museums { get; set; }
        public DbSet<Country> Countries { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            // Creating keys for all junction tables
            builder.Entity<ArtistGenre>()
                .HasKey(artistGenre => new { artistGenre.ArtistId, artistGenre.GenreId });
            builder.Entity<ArtistMedium>()
                .HasKey(artistMedium => new { artistMedium.ArtistId, artistMedium.MediumId });
            builder.Entity<ArtistSubgenre>()
                .HasKey(artistSubgenre => new { artistSubgenre.ArtistId, artistSubgenre.SubgenreId });
            builder.Entity<ArtistSubjectMatter>()
                .HasKey(artistSubjectMatter => new { artistSubjectMatter.ArtistId, artistSubjectMatter.SubjectMatterId });
            builder.Entity<ArtistTag>()
                .HasKey(artistTag => new { artistTag.ArtistId, artistTag.TagId });
            builder.Entity<ExhibitionPiece>()
                .HasKey(exhibitionPiece => new { exhibitionPiece.ExhibitionId, exhibitionPiece.PieceId });
            builder.Entity<LoanPiece>()
                .HasKey(loanPiece => new { loanPiece.LoanId, loanPiece.PieceId });
            builder.Entity<LocationTag>()
                .HasKey(locationTag => new { locationTag.LocationId, locationTag.TagId });
            builder.Entity<PieceArtist>()
                .HasKey(pieceArtist => new { pieceArtist.PieceId, pieceArtist.ArtistId });
            builder.Entity<PieceTag>()
                .HasKey(pieceTag => new { pieceTag.PieceId, pieceTag.TagId });
        }
    }
}
