using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading.Tasks;
using FirstWebApi.Models;
using FirstWebApi.Models.Abstract;

namespace FirstWebApi.Models.Concrete
{
    public class CarRepository : ICarRepository
    {
        private static ConcurrentDictionary<string, Car> _Cars = new ConcurrentDictionary<string, Car>();

        public CarRepository()
        {
            Add(new Car { CarID = "1", Company = "BMW", Model = "X5", Year = 2010, Price = 18500 });
        }
       public void Add(Car car)
        {
            car.CarID = Guid.NewGuid().ToString();
            _Cars[car.CarID] = car;
        }

        public Car Find(string CarID)
        {
            Car car;
            _Cars.TryGetValue(CarID, out car);
            return car;
        }

        public IEnumerable<Car> GetAll()
        {
            return _Cars.Values;
        }

        public Car Remove(string CarID)
        {
            Car car;
            _Cars.TryRemove(CarID, out car);
            return car;
        }

        public void Update(Car car)
        {
            _Cars[car.CarID] = car;
        }
    }
}
