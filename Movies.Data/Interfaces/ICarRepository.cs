using Movies.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Data.Interfaces
{
    public interface ICarRepository : IBaseRepository<Car>
    {
        Task<bool> IsKnownCar(string carName, string companyName);
        Task<bool> IsKnownCarWithoutCollation(string carName, string companyName);
    }
}
