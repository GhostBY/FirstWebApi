using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FirstWebApi.Models.Abstract;
using FirstWebApi.Models.Concrete;
using FirstWebApi.Models;

namespace FirstWebApi.Controllers
{
    [Route("api/[controller]")]
    public class CarController : Controller
    {
        public ICarRepository Cars { get; set; }
        public CarController(ICarRepository Cars)
        {
            this.Cars = Cars;
        }
        [HttpGet]
        public IEnumerable<Car> GetAll()
        {
            return Cars.GetAll();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(string CarID)
        {
            var car = Cars.Find(CarID);
            if (car == null)
            {
                return NotFound();
            }
            return new ObjectResult(car);
        }
        [HttpPost]
        public IActionResult Create([FromBody]Car car)
        {
            if (car == null)
            {
                return BadRequest();
            }
            Cars.Add(car);
            return CreatedAtRoute("GetAll", new { CarID=car.CarID},car);
        }
        [HttpPut("{id}")]
        public IActionResult Update(string CarID, [FromBody] Car car)
        {
            if (car== null || car.CarID != CarID)
            {
                return BadRequest();
            }

            var todo = Cars.Find(CarID);
            if (todo == null)
            {
                return NotFound();
            }

            Cars.Update(car);
            return new NoContentResult();
        }
    }
}
