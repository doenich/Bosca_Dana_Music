using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Bosca_Dana_Music.Models;
using Bosca_Dana_Music;

namespace Bosca_Dana_Music.Data
{
    public class Bosca_Dana_MusicContext : DbContext
    {
        public Bosca_Dana_MusicContext (DbContextOptions<Bosca_Dana_MusicContext> options)
            : base(options)
        {
        }

        public DbSet<Bosca_Dana_Music.Models.Genre> Genre { get; set; }
        public DbSet<Bosca_Dana_Music.Artist> Artist { get; set; }
        public DbSet<Bosca_Dana_Music.Models.Song> Song { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Genre>().ToTable("Genre");
        //    modelBuilder.Entity<Artist>().ToTable("Artist");
        //}


    }


}
