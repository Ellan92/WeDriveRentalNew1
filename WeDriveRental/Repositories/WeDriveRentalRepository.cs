using Microsoft.EntityFrameworkCore;
using WeDriveRental.Data;
using WeDriveRental.Domain.Models;

namespace WeDriveRental.Repositories
{
	public class WeDriveRentalRepository
	{
		private readonly ApplicationDbContext _context;
		public WeDriveRentalRepository(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<CarModel?> GetCarByIdAsync(int carId)
		{
			return await _context.Cars.FirstOrDefaultAsync(c => c.Id == carId);
		}

		public async Task<List<CarModel>> GetAllCarsAsync()
		{
			if (_context.Cars != null)
			{
				return await _context.Cars.ToListAsync();
			}

			throw new NullReferenceException();
		}

		public async Task AddCarAsync(CarModel car)
		{
			_context.Cars.Add(car);
			await _context.SaveChangesAsync();
		}

		public async Task RemoveCarAsync(int id)
		{
			CarModel? carToDelete = await GetCarByIdAsync(id);

			if (carToDelete != null)
			{
				_context.Cars.Remove(carToDelete);
				await _context.SaveChangesAsync();
			}
		}

		public async Task UpdateCar(CarModel car)
		{
			CarModel? carToUpdate = await GetCarByIdAsync(car.Id);

			if (carToUpdate != null)
			{
				carToUpdate.Description = car.Description;
				carToUpdate.Name = car.Name;
				carToUpdate.PricePerDayInSEK = car.PricePerDayInSEK;
			}
		}

        // BOOKINGS

        public async Task<BookingModel?> GetBookingByIdAsync(int bookingId)
        {
            return await _context.Bookings.FirstOrDefaultAsync(c => c.Id == bookingId);
        }

        public async Task<List<BookingModel>> GetAllBookingsAsync()
        {
            if (_context.Bookings != null)
            {
                return await _context.Bookings.ToListAsync();
            }

            throw new NullReferenceException();
        }

        public async Task AddBookingAsync(BookingModel booking)
        {
            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateBooking(BookingModel booking)
        {
            BookingModel? bookingToUpdate = await GetBookingByIdAsync(booking.Id);

            if (bookingToUpdate != null)
            {
                bookingToUpdate.UserEmail = booking.UserEmail;
                bookingToUpdate.StartDate = booking.StartDate;
                bookingToUpdate.EndDate = booking.EndDate;
                bookingToUpdate.CarId = booking.CarId;
            }
        }



        //public int Id { get; set; }
        //public string? UserEmail { get; set; }
        //public DateTime? StartDate { get; set; }
        //public DateTime? EndDate { get; set; }
        //public int? CarId { get; set; }
        //public CarModel? Car { get; set; }
    }
}
