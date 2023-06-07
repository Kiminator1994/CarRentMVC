using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Models
{
    public class Car
    {
        public int Id { get; set; }
        public int Nr { get; set; }
        public string Brand { get; set; }
        public virtual CarClass CarClass { get; set; }
        public string Typ { get; set; }
        public bool IsAvailable { get; set; }
    }
}
