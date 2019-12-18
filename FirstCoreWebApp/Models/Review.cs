using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstCoreWebApp.Models
{
    public class Review
    {
        static int idCounter = 0;
        public static List<Review> reviewsList = new List<Review>();

        public int Id { get; set; }
        public string Info { get; set; }

        public Review()
        {
            Id = ++idCounter;
        }
    }
}
