using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CoraCorpCM.Domain;

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

            // Define one-to-many relationships
            builder.Entity<Acquisition>()
                .HasOne(a => a.Museum)
                .WithMany(m => m.Acquisitions);
            builder.Entity<ApplicationUser>()
                .HasOne(u => u.Museum)
                .WithMany(m => m.Users);
            builder.Entity<Artist>()
                .HasOne(a => a.Museum)
                .WithMany(m => m.Artists);
            builder.Entity<Collection>()
                .HasOne(c => c.Museum)
                .WithMany(m => m.Collections);
            builder.Entity<Condition>()
                .HasOne(c => c.Museum)
                .WithMany(m => m.Conditions);
            builder.Entity<Exhibition>()
                .HasOne(e => e.Museum)
                .WithMany(m => m.Exhibitions);
            builder.Entity<FundingSource>()
                .HasOne(e => e.Museum)
                .WithMany(m => m.FundingSources);
            builder.Entity<Genre>()
                .HasOne(g => g.Museum)
                .WithMany(m => m.Genres);
            builder.Entity<Inspection>()
                .HasOne(i => i.Museum)
                .WithMany(m => m.Inspections);
            builder.Entity<Inspector>()
                .HasOne(i => i.Museum)
                .WithMany(m => m.Inspectors);
            builder.Entity<Loan>()
                .HasOne(l => l.Museum)
                .WithMany(m => m.Loans);
            builder.Entity<Location>()
                .HasOne(l => l.Museum)
                .WithMany(m => m.Locations);
            builder.Entity<Medium>()
                .HasOne(m => m.Museum)
                .WithMany(m => m.Media);
            builder.Entity<Piece>()
                .HasOne(p => p.Museum)
                .WithMany(m => m.Pieces);
            builder.Entity<Subgenre>()
                .HasOne(s => s.Museum)
                .WithMany(m => m.Subgenres);
            builder.Entity<SubjectMatter>()
                .HasOne(s => s.Museum)
                .WithMany(m => m.SubjectMatters);
            builder.Entity<Tag>()
                .HasOne(t => t.Museum)
                .WithMany(m => m.Tags);
            builder.Entity<Upload>()
                .HasOne(u => u.Museum)
                .WithMany(m => m.Uploads);
        }
    }
}
