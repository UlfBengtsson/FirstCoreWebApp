using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstCoreWebApp.Models
{
    public class Car
    {
        static int idCounter = 0;
        public static List<Car> carList = new List<Car>();

        public int Id { get; set; }
        public string Brand { get; set; }
        public string ModelName { get; set; }

        public Car()
        {
            Id = ++idCounter;
        }
    }
}
