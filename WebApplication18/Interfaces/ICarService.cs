using Movies.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Movies.Api.Interfaces
{
    public interface ICarService
    {
        IList<CarDto> GetAll();
        CarDto? Get(int id);
        CarDto Add(CarDto itemDto);
        Task<bool> CheckAuto(string companyName, string carName);
        Task<bool> CheckAutoWithoutCollation(string companyName, string carName, string notMeaningfulVariable);
        CarDto? Update(int id, CarDto itemDto);
        bool Delete(int id);
    }
}
