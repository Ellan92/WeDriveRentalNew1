using System.ComponentModel.DataAnnotations;

namespace WeDriveRental.Domain.Models
{
    public class CarModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public decimal? PricePerDayInSEK { get; set; }
        public string? ImageUrl { get; set; }
        public bool? IsAvailable { get; set; }
        public BookingModel? Booking { get; set; }

    }
}
