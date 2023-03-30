using AutoMapper;
using Movies.Api.Interfaces;
using Movies.Data.Enums;
using Movies.Data.Interfaces;
using Movies.Data.Models;
using Movies.Data.Repositories;
using System.Collections.Generic;

namespace Movies.Api.Models
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository repository;
        private readonly IMapper mapper;

        public PersonService(IPersonRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public IList<PersonDto> GetAllPeople()
        {
            var people = repository.GetAll();
            return mapper.Map<IList<PersonDto>>(people);
        }

        public PersonDto? GetPerson(int id)
        {
            var person = repository.FindById(id);
            if(person == null)
                return null;
            return mapper.Map<PersonDto>(person);
        }

        public IList<PersonDto> GetAllPeople(PersonRoleEnum role, int pageSize = int.MaxValue, int page = 0)
        {
            var people = repository.GetAll(role, pageSize, page);
            return mapper.Map<IList<PersonDto>>(people);
        }

        public PersonDto AddPerson(PersonDto personDto)
        {
            var person = mapper.Map<Person>(personDto);
            person.Id = default;
            var addedPerson = repository.Insert(person);

            return mapper.Map<PersonDto>(addedPerson);
        }

        public PersonDto? UpdatePerson(int id, PersonDto personDto)
        {
            if (!repository.ExistsWith(id))
                return null;

            var person = mapper.Map<Person>(personDto);
            person.Id = id;
            var updatedPerson = repository.Update(person);

            return mapper.Map<PersonDto>(updatedPerson);
        }

        public bool DeletePerson(int id)
        {
            bool exists = repository.ExistsWith(id);

            if (exists)
                repository.Delete(id);

            return exists;
        }
    }
}
