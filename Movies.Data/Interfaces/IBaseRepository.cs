using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Data.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        IList<TEntity> GetAll();
        TEntity? FindById(int id);
        TEntity Insert(TEntity entity);
        TEntity Update(TEntity entity);
        void Delete(int id);
        bool ExistsWith(int id);
    }
}
