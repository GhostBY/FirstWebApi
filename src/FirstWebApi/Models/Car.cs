using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstWebApi.Models
{
    public class Car
    {
        public string CarID { get; set; }
        public string Company { get; set;}
        public string Model { get; set; }
        public double Price { get; set; }
        public int Year { get; set; }
    }
}
