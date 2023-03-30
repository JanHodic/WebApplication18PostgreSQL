using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Data.Models
{
    public class Movie
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key]
        public int MovieId { get; set; }
        [Required, MinLength(3)]
        public string Name { get; set; } = "";
        [Required]
        public int Year { get; set; }
        [Required]
        public bool IsAvailable { get; set; }
        [ForeignKey(nameof(Director))]
        public int DirectorId { get; set; }
        public virtual Person? Director { get; set; }
        public virtual List<Person> Actors { get; set; } = new List<Person>();
        public virtual List<Genre> Genres { get; set; } = new List<Genre>();
    }
}
