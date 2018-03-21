using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CoraCorpCM.Domain.Models;
using Microsoft.AspNetCore.Identity;

namespace CoraCorpCM.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Acquisition> Acquisitions { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Collection> Collections { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<FundingSource> FundingSources { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Medium> Media { get; set; }
        public DbSet<Museum> Museums { get; set; }
        public DbSet<Piece> Pieces { get; set; }
        public DbSet<PieceSource> PieceSources { get; set; }
        public DbSet<Subgenre> Subgenres { get; set; }
        public DbSet<SubjectMatter> SubjectMatters { get; set; }
        public DbSet<UnitOfMeasure> UnitsOfMeasure { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

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
            builder.Entity<PieceTag>()
                .HasKey(pieceTag => new { pieceTag.PieceId, pieceTag.TagId });

            // Explicitly define one-to-many relationships where necessary
            builder.Entity<Upload>()
                .HasOne(upload => upload.Museum)
                .WithMany(museum => museum.Uploads);

            builder.Entity<ArtistGenre>()
                .HasOne(artistGenre => artistGenre.Artist)
                .WithMany(artist => artist.ArtistGenres)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<ArtistGenre>()
                .HasOne(artistGenre => artistGenre.Genre)
                .WithMany(genre => genre.ArtistGenres)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<ArtistMedium>()
                .HasOne(artistMedium => artistMedium.Artist)
                .WithMany(artist => artist.ArtistMedia)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<ArtistMedium>()
                .HasOne(artistMedium => artistMedium.Medium)
                .WithMany(medium => medium.ArtistMedia)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<ArtistSubgenre>()
                .HasOne(artistSubgenre => artistSubgenre.Artist)
                .WithMany(artist => artist.ArtistSubgenres)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<ArtistSubgenre>()
                .HasOne(artistSubgenre => artistSubgenre.Subgenre)
                .WithMany(subgenre => subgenre.ArtistSubgenres)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<ArtistSubjectMatter>()
                .HasOne(artistSubjectMatter => artistSubjectMatter.Artist)
                .WithMany(artist => artist.ArtistSubjectMatters)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<ArtistSubjectMatter>()
                .HasOne(artistSubjectMatter => artistSubjectMatter.SubjectMatter)
                .WithMany(subjectMatter => subjectMatter.ArtistSubjectMatters)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<ArtistTag>()
                .HasOne(artistTag => artistTag.Artist)
                .WithMany(artist => artist.ArtistTags)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<ArtistTag>()
                .HasOne(artistTag => artistTag.Tag)
                .WithMany(tag => tag.ArtistTags)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<ExhibitionPiece>()
                .HasOne(exhibitionPiece => exhibitionPiece.Exhibition)
                .WithMany(exhibition => exhibition.ExhibitionPieces)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<ExhibitionPiece>()
                .HasOne(exhibitionPiece => exhibitionPiece.Piece)
                .WithMany(piece => piece.ExhibitionPieces)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<LoanPiece>()
                .HasOne(loanPiece => loanPiece.Loan)
                .WithMany(loan => loan.LoanPieces)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<LoanPiece>()
                .HasOne(loanPiece => loanPiece.Piece)
                .WithMany(piece => piece.LoanPieces)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<LocationTag>()
                .HasOne(locationTag => locationTag.Location)
                .WithMany(location => location.LocationTags)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<LocationTag>()
                .HasOne(locationTag => locationTag.Tag)
                .WithMany(tag => tag.LocationTags)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<PieceTag>()
                .HasOne(pieceTag => pieceTag.Piece)
                .WithMany(piece => piece.PieceTags)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<PieceTag>()
                .HasOne(pieceTag => pieceTag.Tag)
                .WithMany(tag => tag.PieceTags)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
