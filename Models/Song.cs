using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace Bosca_Dana_Music.Models
{
    [Table("Song")]
    public class Song
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        [Key]
        public int SongId { set; get; }
        public string Name { get; set; }
        public string ReleasedYear { get; set; }



        public int ArtistId { get; set; }
        public Artist Artist { get; set; }


        public int GenreId { get; set; }
        public Genre Genre { get; set; }

        public Song()
        {
            SongId = 0;
            Name = string.Empty;
            ReleasedYear = string.Empty;
            ArtistId = 0;
            GenreId = 0;
            Artist = new Artist();
            Genre = new Genre();
        }

        public Song(int songId, string name, string releasedYear, int artistId, Artist artist, int genreId, Genre genre)
        {
            SongId = songId;
            Name = name ?? throw new ArgumentNullException(nameof(name));
            ReleasedYear = releasedYear ?? throw new ArgumentNullException(nameof(releasedYear));
            ArtistId = artistId;
            Artist = artist ?? throw new ArgumentNullException(nameof(artist));
            GenreId = genreId;
            Genre = genre ?? throw new ArgumentNullException(nameof(genre));
        }
    }
}
