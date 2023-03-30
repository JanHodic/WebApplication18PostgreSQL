using Movies.Data.Data;
using Movies.Data.Enums;
using Movies.Data.Interfaces;
using Movies.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Data.Repositories
{
    public class PersonRepository : BaseRepository<Person>, IPersonRepository
    {
        public PersonRepository(MoviesDbContext context) : base(context)
        {
        }

        public IList<Person> FindAllByIds(IEnumerable<int> ids)
        {
            return dbSet.Where(p => ids.Contains(p.Id)).ToList();
        }

        public IList<Person> GetAll(PersonRoleEnum role, int pageSize, int page)
        {
            return dbSet
                .Where(p => p.Role == role)
                /*.Skip(page * pageSize).
                Take(pageSize)*/
                .ToList();
        }
    }
}
