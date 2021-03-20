using System;
using System.Collections.Generic;
using System.Text;

namespace CarServiceASP.Data.Models
{
    public class Worker
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public virtual ICollection<Visit> Visits { get; set; }
    }
}
