using Microsoft.EntityFrameworkCore;
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
    public class CarRepository : BaseRepository<Car>, ICarRepository
    {
        public CarRepository(MoviesDbContext context) : base(context)
        {
        }

        public Task<bool> IsKnownCar(string carName, string companyName)
        {
            var car = FindById(1);


            return context.Cars.IgnoreQueryFilters().AnyAsync(
                x => EF.Functions.Collate(
                    x.CompanyName, "SQL_Latin1_General_CP1_CS_AS"
                    ) == companyName
                    &&
                    EF.Functions.Collate(
                    x.CarName, "SQL_Latin1_General_CP1_CS_AS"
                    ) == carName
                );
        }

        public Task<bool> IsKnownCarWithoutCollation(string companyName, string carName)
        {
            var car = FindById(1);//just to check parameters of the tested car

            return context.Cars.IgnoreQueryFilters().AnyAsync(
                x => 
                    x.CompanyName == companyName
                    &&
                    x.CarName == carName
                );
        }
    }
}
