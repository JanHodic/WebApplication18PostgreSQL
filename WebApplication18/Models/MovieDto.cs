using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Movies.Api.Models
{
    public class MovieDto
    {
        [JsonPropertyName("_id")]
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("year")]
        public int Year { get; set; }
        [JsonPropertyName("isAvailable")]
        public bool IsAvailable { get; set; }
        [JsonPropertyName("directorId")]
        public int DirectorId { get; set; }

        [JsonPropertyName("actorIDs")]
        public virtual List<int> Actors { get; set; } = new List<int>();

        [JsonPropertyName("genres")]
        public virtual List<string> Genres { get; set; } = new List<string>();
    }
}
