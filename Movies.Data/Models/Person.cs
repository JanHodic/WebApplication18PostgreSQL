using Movies.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Data.Models
{
    public class Person
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key]
        public int Id { get; set; }
        [Required, MinLength(3)]
        public string Name { get; set; } = "";
        [Required]
        public DateTime BirthDate { get; set; }
        [Required]
        public string Country { get; set; } = "";
        [Required]
        public string Biography { get; set; } = "";
        [Required]
        public PersonRoleEnum Role { get; set; }

        public virtual List<Movie> MovieAsActor { get; set; } = new List<Movie>();
        public virtual List<Movie> MovieAsDirector { get; set; } = new List<Movie>();
    }
}
