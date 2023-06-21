namespace CarRent.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public int Nr { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal TotalFee { get; set; }
        public int CarId { get; set; }
        public int CustomerId { get; set; }
        public virtual Car? Car { get; set; }
        public virtual Customer? Customer { get; set; }
        public virtual RentalContract? RentalContract { get; set; }
    }
}
