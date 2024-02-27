using Microsoft.AspNetCore.Identity;
using WeDriveRental.Domain.Models;

namespace WeDriveRental.Data
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public DateOnly? DateOfBirth { get; set; }
        public List<BookingModel>? Bookings { get; set; }
    }

}
