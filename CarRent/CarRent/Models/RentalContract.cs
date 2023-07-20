using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRent.Models
{
    public class RentalContract
    {
        public int Id { get; set; }

        [Display(Name = "Rental Contract Nr")]
        public int Nr { get; set; }

        [Display(Name = "Startdate")]
        [DataType(DataType.Date)] // Specify the data type to be Date
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)] // Date format for display
        public DateTime StartDate { get; set; }

        [Display(Name = "Enddate")]
        [DataType(DataType.Date)] // Specify the data type to be Date
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)] // Date format for display
        public DateTime EndDate { get; set; }

        public decimal TotalFee { get; set; }
        public int ReservationId { get; set; }
        [ForeignKey("ReservationId")]
        public virtual Reservation? Reservation { get; set; }
    }
}
