using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bosca_Dana_Music
{
    [Table("Artist")]
    public class Artist
    {
        

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ArtistId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime FormedDate { get; set;  }

        public Artist(int iD, string name, string description, DateTime formedDate)
        {
            ArtistId = iD;
            Name = name;
            Description = description;
            FormedDate = formedDate;
        }

        public Artist()
        {
            ArtistId = -1;
            Name = string.Empty;
            Description = string.Empty;
            FormedDate = new DateTime();
        }
    }
}
