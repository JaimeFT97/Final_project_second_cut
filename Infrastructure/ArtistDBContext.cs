using Microsoft.EntityFrameworkCore;
using FinalProjectSecondCut.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalProjectSecondCut.Infrastructure.EntityConfiguration;

namespace FinalProjectSecondCut.Infrastructure
{
    public class ArtistDBContext : DbContext
    {
        public ArtistDBContext(DbContextOptions<ArtistDBContext> options) : base(options)
        {

        }
        public DbSet<Album> Album { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<Artist> Artist { get; set; }
        public DbSet<Gender> Gender { get; set; }
        public DbSet<Language> Language { get; set; }
        public DbSet<Song> Song { get; set; }
        public DbSet<Staff> Staff { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new AlbumEntityConfiguration());
            builder.ApplyConfiguration(new CountryEntityConfiguration());
            builder.ApplyConfiguration(new ArtistEntityConfiguration());
            builder.ApplyConfiguration(new GenderEntityConfiguration());
            builder.ApplyConfiguration(new LanguageEntityConfiguration());
            builder.ApplyConfiguration(new SongEntityConfiguration());
            builder.ApplyConfiguration(new StaffEntityConfiguration());
        }
    }
}
