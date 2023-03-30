using Movies.Data.Enums;
using System;
using System.Text.Json.Serialization;

namespace Movies.Api.Models
{
    public class PersonDto
    {
        [JsonPropertyName("_id")]
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public DateTime BirthDate { get; set; }
        public string Country { get; set; } = "";
        public string Biography { get; set; } = "";
        public PersonRoleEnum Role { get; set; }
    }
}
