using Movies.Api.Models;
using Movies.Data.Enums;
using System.Collections.Generic;

namespace Movies.Api.Interfaces
{
    public interface IPersonService
    {
        IList<PersonDto> GetAllPeople();
        IList<PersonDto> GetAllPeople(PersonRoleEnum role, int pageSize, int page = 0);
        PersonDto? GetPerson(int id);
        PersonDto AddPerson(PersonDto personDto);
        PersonDto? UpdatePerson(int id, PersonDto personDto);
        bool DeletePerson(int id);
    }
}
