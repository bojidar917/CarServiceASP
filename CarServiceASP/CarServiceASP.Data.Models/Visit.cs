using System;
using System.Collections.Generic;
using System.Text;

namespace CarServiceASP.Data.Models
{
    public class Visit
    {
        public int Id { get; set; }
        public virtual Owner Owner { get; set; }
        public int OwnerId { get; set; }
        public virtual Car Car { get; set; }
        public int CarId { get; set; }
        public virtual Worker Worker { get; set; }
        public int WorkerId { get; set; }
        public string CurrRegNum { get; set; }
        public string Subject { get; set; }
        public decimal Price { get; set; }
        public DateTime DateTime { get; set; }
    }
}
