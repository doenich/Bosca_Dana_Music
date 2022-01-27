using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bosca_Dana_Music.Models
{
    public class Song
    {
        public int SongId { set; get; }

        public string Name { get; set; }

        public string ReleasedYear { get; set; }

        public int ArtistId { get; set; }

        public Artist Artist { get; set; }

        public int GenreId { get; set; }

        public Genre Genre { get; set; }

        public Song()
        {
            SongId = -1;
            Name = string.Empty;
            ReleasedYear = string.Empty;
            GenreId = int 

        }

        public Song(int iD, string name, string releasedYear)
        {
            SongId = iD;
            Name = name;
            ReleasedYear = releasedYear;
        }

    }
}
