using Microsoft.EntityFrameworkCore;

namespace KOL2_grB.Models
{
    public class MusicDbContext : DbContext
    {
        //public DbSet <Musician> musicians { get; set; }
        //public DbSet <MusicLabel> musicLabels { get; set; }
        //public DbSet <Album> albums { get; set; }
        //public DbSet<Track> tracks { get; set; }
        //public DbSet<MusicianTrack> musicianTracks { get; set; }

        public MusicDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            var musicians = new List<Musician>
            {
                new Musician
                    {
                        IdMusician = 1,
                        FirstName = "Jacek",
                        LastName = "Czarny",
                        Nickname = "Jack Black"
                    },
                    new Musician
                    {
                        IdMusician = 2,
                        FirstName = "Steve",
                        LastName = "Harrington",
                        Nickname = "Stevie"
                    }
            };
            var musicLabels = new List<MusicLabel>
            {
                new MusicLabel
                    {
                        IdMusicLabel = 1,
                        Name = "Ur label"
                    },
                    new MusicLabel
                    {
                        IdMusicLabel = 2,
                        Name = "label"
                    }
            };
            var albums = new List<Album>
            {
                new Album
                    {
                        IdAlbum = 1,
                        AlbumName = "AlbumName",
                        PublishDate = new System.DateTime(2022, 6, 5),
                        IdMusicLabel = 1
                    },
                new Album
                {
                    IdAlbum = 1,
                    AlbumName = "This Is Album",
                    PublishDate = new System.DateTime(2022, 6, 5),
                    IdMusicLabel = 2
                }
            };
            var tracks = new List<Track>
            {
                new Track
                    {
                        IdTrack = 1,
                        TrackName = "track one",
                        Duration = 5,
                        IdAlbum = 1
                    },
                new Track
                {
                    IdTrack = 2,
                    TrackName = "track two",
                    Duration = 3,
                    IdAlbum = 1
                },
                new Track
                {
                    IdTrack = 3,
                    TrackName = "t r a c k",
                    Duration = 8,
                    IdAlbum = 2
                }
            };
            var musicianTracks = new List<MusicianTrack>
            {
                new MusicianTrack
                    {
                        IdTrack = 1,
                        IdMusician = 1
                    },
                new MusicianTrack
                {
                    IdTrack = 2,
                    IdMusician = 1
                },
                new MusicianTrack
                {
                    IdTrack = 3,
                    IdMusician = 2
                }
            };

            modelBuilder.Entity<Musician>(e =>
            {
                e.HasKey(e => e.IdMusician);

                e.Property(e => e.FirstName).HasMaxLength(30).IsRequired();
                e.Property(e => e.LastName).HasMaxLength(50).IsRequired();
                e.Property(e => e.Nickname).HasMaxLength(20);

                e.ToTable("Musician");
                
            });

            modelBuilder.Entity<MusicLabel>(e =>
            {
                e.HasKey(e => e.IdMusicLabel);
                e.Property(e => e.Name).HasMaxLength(50).IsRequired();

                e.ToTable("MusicLabel");

                
            });

            modelBuilder.Entity<Album>(e =>
            {
                e.HasKey(e => e.IdAlbum);
                e.Property(e => e.AlbumName).HasMaxLength(30).IsRequired();
                e.Property(e => e.PublishDate).IsRequired();

                e.HasOne(e => e.MusicLabel).WithMany(e => e.Albums)
                .HasForeignKey(e => e.IdMusicLabel)
                .OnDelete(DeleteBehavior.Restrict);



                e.ToTable("Album");
                
            });
            modelBuilder.Entity<Track>(e =>
            {
                e.HasKey(e => e.IdTrack);
                e.Property(e => e.TrackName).HasMaxLength(20).IsRequired();
                e.Property(e => e.Duration).IsRequired();
                e.Property(e => e.IdAlbum);

                e.HasOne(e => e.Album)
                .WithMany(e => e.Tracks)
                .HasForeignKey(e => e.IdAlbum)
                .OnDelete(DeleteBehavior.Restrict);

                e.ToTable("Track");

               

            });
            modelBuilder.Entity<MusicianTrack>(e =>
            {
                e.HasKey(e => new { e.IdMusician, e.IdTrack });

                e.HasOne(e => e.Musician).WithMany(e => e.MusicianTracks)
                .HasForeignKey(e => e.IdMusician)
                .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(e => e.Track).WithMany(e => e.MusicianTracks)
                .HasForeignKey(e => e.IdTrack)
                .OnDelete(DeleteBehavior.Restrict);

                e.ToTable("MusicianTrack");

                
            });
        }
    }
}
