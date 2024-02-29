namespace WeDriveRental.Domain.Models
{
    public class BookingModel
    {
        public int Id { get; set; }
        public string? UserEmail { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? CarId { get; set; }
        public CarModel? Car { get; set; }
    }
}
