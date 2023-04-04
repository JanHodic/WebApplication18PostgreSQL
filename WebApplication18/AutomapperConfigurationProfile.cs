using AutoMapper;
using Movies.Api.Models;
using Movies.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace Movies.Api
{
    public class AutomapperConfigurationProfile : Profile
    {
        public AutomapperConfigurationProfile()
        {
            CreateMap<Person, PersonDto>();
            CreateMap<PersonDto, Person>();
            CreateMap<Car, CarDto>();
            CreateMap<CarDto, Car>();
            CreateMap<Genre, string>()
                .ConstructUsing((genre, resolutionContext) => genre.Name);
            CreateMap<Movie, MovieDto>()
                .ForMember(m => m.Actors, opt => opt.ConvertUsing<PeopleToIdsConverter, List<Person>>());
            CreateMap<MovieDto, Movie>()
                .ForMember(m => m.Genres, opt => opt.Ignore())
                .ForMember(m => m.Actors, opt => opt.Ignore());

        }

        private class PeopleToIdsConverter : IValueConverter<List<Person>, List<int>>
        {
            public List<int> Convert(List<Person> sourceMember, ResolutionContext context) =>
                sourceMember.Select(p => p.Id).ToList();
        }
    }
}
