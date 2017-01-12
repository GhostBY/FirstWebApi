using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstWebApi.Models;

namespace FirstWebApi.Models.Abstract
{
    public interface ICarRepository
    {
        void Add(Car car);
        IEnumerable<Car> GetAll();
        Car Find(string CarID);
        Car Remove(string CarID);
        void Update(Car car);
    }
}
