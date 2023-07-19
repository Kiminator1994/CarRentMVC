using System.ComponentModel.DataAnnotations;

namespace CarRent.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        [Display(Name = "Reservation Nr")]
        public int Nr { get; set; }

        [Display(Name = "Startdate")]
        [DataType(DataType.Date)] // Specify the data type to be Date
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)] // Date format for display
        public DateTime StartDate { get; set; }

        [Display(Name = "Enddate")]
        [DataType(DataType.Date)] // Specify the data type to be Date
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)] // Date format for display
        public DateTime EndDate { get; set; }

        [Display(Name = "Total Fee")]
        public decimal TotalFee { get; set; }
        public int CarId { get; set; }
        public int CustomerId { get; set; }

        public virtual Car Car { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual RentalContract? RentalContract { get; set; }
    }

}
