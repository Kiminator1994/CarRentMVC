using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public int Nr { get; set; }
        public int Days { get; set; }
        public decimal TotalFee { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual RentalContract RentalContract { get; set; }

    }
}
