using System.ComponentModel.DataAnnotations;

namespace CarRent.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public int Nr { get; set; }

        [Display(Name = "Startdate")]
        public DateTime StartDate { get; set; }

        [Display(Name = "Enddate")]
        public DateTime EndDate { get; set; }

        [Display(Name = "Total Fee")]
        public decimal TotalFee { get; set; }
        public int CarId { get; set; }
        public int CustomerId { get; set; }
        public virtual Car? Car { get; set; }
        public virtual Customer? Customer { get; set; }
        public virtual RentalContract? RentalContract { get; set; }
    }
}
