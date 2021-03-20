using System;
using System.Collections.Generic;

namespace CarServiceASP.Data.Models
{
    public class Car
    {
        public int Id { get; set; }
        public virtual Owner Owner { get; set; }
        public int OwnerId { get; set; }
        public string RegNum { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }
        public virtual ICollection<Visit> Visits { get; set; }
    }
}
