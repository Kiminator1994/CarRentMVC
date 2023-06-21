using CarRent.Data;
using System.ComponentModel.DataAnnotations;

namespace CarRent.Models
{
    public class Car
    {
        public int Id { get; set; }
        public int Nr { get; set; }

        [Display(Name = "Picture Url")]
        public string? PictureUrl { get; set; }

        [Display(Name = "Price / day")]
        public CarCategory Category { get; set; }

        [Display(Name = "Brand")]
        public string? Brand { get; set; }
        public virtual Reservation? Reservation { get; set; }

        [Display(Name = "Model Type")]
        public string? ModelType { get; set; }

        [Display(Name = "Available")]
        public bool IsAvailable { get; set; }
    }
}
