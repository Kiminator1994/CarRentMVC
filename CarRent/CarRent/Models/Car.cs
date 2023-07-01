using CarRent.Data;
using System.ComponentModel.DataAnnotations;

namespace CarRent.Models
{
    public class Car
    {
        public int Id { get; set; }
        public int Nr { get; set; }

        [Display(Name = "Picture Url")]
        [Required(ErrorMessage = "Picture URL is required")]
        public string? PictureUrl { get; set; }

        [Display(Name = "Price / day")]
        [Required(ErrorMessage = "Price is required")]
        public CarCategory Category { get; set; }

        [Display(Name = "Brand")]
        [Required(ErrorMessage = "Brand is required")]
        public string? Brand { get; set; }
        public virtual Reservation? Reservation { get; set; }

        [Display(Name = "Model Type")]
        public string? ModelType { get; set; }

        [Display(Name = "Available")]
        public bool IsAvailable { get; set; }
    }
}
