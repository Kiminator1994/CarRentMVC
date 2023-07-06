using CarRent.Data;
using System.ComponentModel.DataAnnotations;

namespace CarRent.Models
{
    public class Car
    {
        public int Id { get; set; }

        [Display(Name = "Nr")]
        [Required(ErrorMessage = "Nr is required")]
        public int Nr { get; set; }

        [Display(Name = "Description")]
        [Required(ErrorMessage = "Please add a small Description")]
        public string Description { get; set; }

        [Display(Name = "Picture Url")]
        [Required(ErrorMessage = "Picture URL is required")]
        public string? PictureUrl { get; set; }

        [Display(Name = "Price")]
        [Required(ErrorMessage = "Price is required")]
        public CarCategory Category { get; set; }

        [Display(Name = "Brand")]
        [Required(ErrorMessage = "Brand is required")]
        public string? Brand { get; set; }
        public virtual Reservation? Reservation { get; set; }

        [Display(Name = "Model Type")]
        [Required(ErrorMessage = "Modeltype is required")]
        public string? ModelType { get; set; }

        [Display(Name = "Available")]
        public bool IsAvailable { get; set; }
    }
}
