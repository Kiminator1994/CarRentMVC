namespace CarRent.Models
{
    public class RentalContract
    {
        public int Id { get; set; }
        public int Nr { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal TotalFee { get; set; }

        public int ReservationId { get; set; }
        public virtual Reservation? Reservation { get; set; }
    }
}
