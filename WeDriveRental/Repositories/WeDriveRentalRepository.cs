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
	}
}
