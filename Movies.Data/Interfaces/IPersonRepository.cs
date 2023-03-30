using Movies.Data.Enums;
using Movies.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Data.Interfaces
{
    public interface IPersonRepository : IBaseRepository<Person>
    {
        IList<Person> GetAll(PersonRoleEnum role, int pageSize, int page);

        IList<Person> FindAllByIds(IEnumerable<int> ids);
    }
}
