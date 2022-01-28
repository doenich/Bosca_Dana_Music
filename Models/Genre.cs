using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;



namespace Bosca_Dana_Music.Models
{
    [Table("Genre")]
    public class Genre
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public int GenreId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<Models.Song> Songs { get; set; }

        public Genre()
        {
            GenreId = 0;
            Name = string.Empty;
            Description = string.Empty;
        }

        public Genre(int iD, string name, string description)
        {
            GenreId = iD;
            Name = name;
            Description = description;
        }
    }
}
