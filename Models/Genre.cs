using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;



namespace Bosca_Dana_Music.Models
{
    public class Genre
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int GenreID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }


        public Genre()
        {
            GenreID = -1;
            Name = string.Empty;
            Description = string.Empty;
        }

        public Genre(int iD, string name, string description)
        {
            GenreID = iD;
            Name = name;
            Description = description;
        }
    }
}
