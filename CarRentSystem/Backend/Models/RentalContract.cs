using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Models
{
    public class RentalContract
    {
        public int Id { get; set; }
        public int Nr { get; set; }
        public int Days { get; set; }
        public decimal TotalFee { get; set; }

        public int ReservationId { get; set; }
        public virtual Reservation Reservation { get; set; }
    }
}
