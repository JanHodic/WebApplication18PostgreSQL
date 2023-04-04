using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Movies.Data.Enums;
using Movies.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Data.Data
{
    public class MoviesDbContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Car> Cars { get; set; }
        public MoviesDbContext(DbContextOptions<MoviesDbContext> options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Movie>()
                .HasOne(m => m.Director)
                .WithMany(p => p.MovieAsDirector);

            modelBuilder.Entity<Movie>()
                .HasMany(m => m.Actors)
                .WithMany(p => p.MovieAsActor)
                .UsingEntity(j => j.ToTable("MovieActors"));

            IEnumerable<IMutableForeignKey> casCadeFKs = modelBuilder.Model.GetEntityTypes()
                .SelectMany(type => type.GetForeignKeys())
                .Where(foreignKey => !foreignKey.IsOwnership
                && foreignKey.DeleteBehavior == DeleteBehavior.Cascade);
            foreach (IMutableForeignKey foreignKey in casCadeFKs)
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;

            AddTestingData(modelBuilder);
        }

        private void AddTestingData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().HasData(
                new Person
                {
                    Id = 1,
                    Name = "George Lucas",
                    BirthDate = new DateTime(1944, 4, 15),
                    Country = "USA",
                    Biography = "Vlastním jménem George Walton Lucas, Jr. se narodil 14. května 1944 v Modestu, Kalifornii. Zde také vystudoval proslulou University of Southern California (USC)...",
                    Role = PersonRoleEnum.Director
                },
                new Person
                {
                    Id = 2,
                    Name = "Irvin Kershner",
                    BirthDate = new DateTime(1923, 4, 29),
                    Country = "USA",
                    Biography = "Irvin Kershner se narodil ve Filadelfii rodičům židovského původu. Jeho uměleckým zaměřením bylo zpočátku hraní na hudební nástroje...",
                    Role = PersonRoleEnum.Director
                },
                new Person
                {
                    Id = 3,
                    Name = "Harrison Ford",
                    BirthDate = new DateTime(1942, 7, 13),
                    Country = "USA",
                    Biography = "Harrison vyrůstal na Chicagském předměstí, kde jeho otec pracoval jako reklamní manažer. Po střední škole začal Harrison studovat filozofii...",
                    Role = PersonRoleEnum.Actor
                });
            modelBuilder.Entity<Genre>().HasData(
                new Genre { Id = 1, Name = "sci-fi" },
                new Genre { Id = 2, Name = "adventure" },
                new Genre { Id = 3, Name = "action" },
                new Genre { Id = 4, Name = "romantic" },
                new Genre { Id = 5, Name = "animated" },
                new Genre { Id = 6, Name = "comedy" });
            /*
            modelBuilder.Entity<Car>().HasData(
                new Car() { Id = 1, CarName = "Octavia", CompanyName = "AAA" },
                new Car() { Id = 1, CarName = "Felicia", CompanyName = "BBB" },
                new Car() { Id = 1, CarName = "Superb", CompanyName = "CCC" }
                );*/
        }
    }
}
