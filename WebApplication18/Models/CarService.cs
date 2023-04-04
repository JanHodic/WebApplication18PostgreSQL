using AutoMapper;
using Movies.Api.Interfaces;
using Movies.Data.Enums;
using Movies.Data.Interfaces;
using Movies.Data.Models;
using Movies.Data.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Movies.Api.Models
{
    public class CarService : ICarService
    {
        private readonly ICarRepository repository;
        private readonly IMapper mapper;

        public CarService(ICarRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public IList<CarDto> GetAll()
        {
            var items = repository.GetAll();
            return mapper.Map<IList<CarDto>>(items);
        }

        public CarDto? Get(int id)
        {
            var item = repository.FindById(id);
            if(item == null)
                return null;
            return mapper.Map<CarDto>(item);
        }

        public CarDto Add(CarDto itemDto)
        {
            var item = mapper.Map<Car>(itemDto);
            item.Id = default;
            var added = repository.Insert(item);

            return mapper.Map<CarDto>(added);
        }

        public CarDto? Update(int id, CarDto itemDto)
        {
            if (!repository.ExistsWith(id))
                return null;

            var item = mapper.Map<Car>(itemDto);
            item.Id = id;
            var updated = repository.Update(item);

            return mapper.Map<CarDto>(updated);
        }

        public bool Delete(int id)
        {
            bool exists = repository.ExistsWith(id);

            if (exists)
                repository.Delete(id);

            return exists;
        }

        public Task<bool> CheckAuto(string companyName, string carName)
        {
            //return repository.IsKnownCar(companyName, carName);
            return repository.IsKnownCarWithoutCollation(companyName, carName);
        }

        public Task<bool> CheckAutoWithoutCollation(string companyName, string carName, string notMeaningfulVariable)
        {
            return repository.IsKnownCarWithoutCollation(companyName, carName);
        }
    }
}
