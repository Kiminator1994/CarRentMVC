using System.ComponentModel.DataAnnotations;
using System.Formats.Asn1;

namespace CarRent.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Display(Name = "Customer Nr")]
        public int Nr { get; set; }

        [Display(Name = "Firstname")]
        [Required(ErrorMessage = "Firstname is required")]
        public string? FirstName { get; set; }

        [Display(Name = "Lastname")]
        [Required(ErrorMessage = "Lastname is required")]
        public string? LastName { get; set; }

        [Display(Name = "Address")]
        [Required(ErrorMessage = "Address is required")]
        public string? Address { get; set; }

        [Display(Name = "City")]
        [Required(ErrorMessage = "City is required")]
        public string? City { get; set; }
        public virtual ICollection<Reservation>? Reservations { get; set; }
    }
}

