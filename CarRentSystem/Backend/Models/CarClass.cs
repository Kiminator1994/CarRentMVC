using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Models
{
    public class CarClass
    {
        public int Id { get; set; }
        public decimal DailyFee { get; set; }
        public string Class { get; set; }
        public virtual ICollection<Car> Cars { get; set; }

        public enum Classes : int
        {
            Simple = 1,
            Medium = 2,
            Luxury = 3
        }

    }
}
