using System;
using System.Collections.Generic;
using System.Text;

namespace CarServiceASP.Data.Models
{
    public class Owner
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public int Age { get; set; }
        public string City { get; set; }
        public virtual ICollection<Car> Cars { get; set; }
        public virtual ICollection<Visit> Visits { get; set; }
    }
}
