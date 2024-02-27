using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WeDriveRental.Domain.Models;

namespace WeDriveRental.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<BookingModel> Bookings { get; set; }
        public DbSet<CarModel> Cars { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<CarModel>().HasData(
                new CarModel
                {
                    Id = 1,
                    Name = "Lamborghini Urus 2022",
                    Description = "The 2022 Lamborghini Urus is a cutting-edge luxury SUV that merges striking Italian design with exceptional performance, boasting a potent V8 engine, unparalleled acceleration, and a lavish interior, affirming its status as a high-performance and stylish crossover.",
                    PricePerDayInSEK = 3099,
                    ImageUrl = "https://www.oneclickdrive.com/uploads/Lamborghini_Urus-Pearl-Capsule_2022_12394_12394_13220768648-2_small.jpg?ocd=5.15",
                    IsAvailable = true,
                    Booking = null
                },
                new CarModel
                {
                    Id = 2,
                    Name = "Range Rover Sport SVR 2020",
                    Description = "The 2020 Range Rover Sport SVR is a luxury SUV that seamlessly blends opulent craftsmanship with high-performance capabilities, featuring a robust supercharged V8 engine, advanced off-road prowess, and a refined interior for a thrilling yet comfortable driving experience.",
                    PricePerDayInSEK = 1699,
                    ImageUrl = "https://www.oneclickdrive.com/uploads/Land-Rover_Range-Rover-Sport-SVR_2020_9075_9075_6512373439-1_small.jpg?ocd=5.15",
                    IsAvailable = true,
                    Booking = null
                },
                new CarModel
                {
                    Id = 3,
                    Name = "Audi R8 Spyder 2021",
                    Description = "The 2021 Audi R8 Spyder is a high-performance convertible sports car that combines a breathtaking open-top driving experience with a powerful V10 engine, delivering exhilarating performance and cutting-edge technology in a stylish and aerodynamic design.",
                    PricePerDayInSEK = 2299,
                    ImageUrl = "https://www.oneclickdrive.com/application/views/img/watermark_img/Audi_R8-V10-Spyder_2022_10927_10927_3461148360-1_small.jpg?ocd=5.15",
                    IsAvailable = true,
                    Booking = null
                },
                new CarModel
                {
                    Id = 4,
                    Name = "Aston Martin Vantage 2019",
                    Description = "The 2019 Aston Martin Vantage is a captivating sports car that exemplifies British elegance and performance, featuring a distinctive design, a potent V8 engine, and a well-crafted interior, delivering a thrilling and refined driving experience.",
                    PricePerDayInSEK = 2199,
                    ImageUrl = "https://www.oneclickdrive.com/application/views/img/watermark_img/Aston-Martin-Vantage-2019_10776_22671623575-11_10776__small.jpg?ocd=5.15",
                    IsAvailable = true,
                    Booking = null
                },
                new CarModel
                {
                    Id = 5,
                    Name = "Mercedes Benz AMG G63 Brabus 2023",
                    Description = "The 2023 Mercedes-Benz AMG G63 Brabus is a luxurious and powerful SUV, showcasing a bespoke and aggressively styled exterior, a handcrafted high-performance engine by Brabus, and an opulent interior, combining refined comfort with unparalleled off-road capabilities.",
                    PricePerDayInSEK = 2999,
                    ImageUrl = "https://www.oneclickdrive.com/application/views/img/watermark_img/Mercedes-Benz_AMG-G63-Brabus_2023_27236_27236_19930451718-11_small.jpg?ocd=5.15",
                    IsAvailable = true,
                    Booking = null
                },
                new CarModel
                {
                    Id = 6,
                    Name = "Porsche 911 Carrera GTS 2019",
                    Description = "The 2019 Porsche 911 Carrera GTS is a precision-engineered sports car that epitomizes driving excellence, featuring a turbocharged flat-six engine, precise handling, and a timeless design, delivering an exhilarating and dynamic driving experience.",
                    PricePerDayInSEK = 1899,
                    ImageUrl = "https://www.oneclickdrive.com/application/views/img/watermark_img/Porsche_911-Carrera-GTS_2019_14793_14793_11734217763-1_small.jpg?ocd=5.15",
                    IsAvailable = true,
                    Booking = null
                });

            modelBuilder.Entity<BookingModel>().HasData( 
                new BookingModel 
                { 
                    Id = 1,
                    UserEmail = "elle@hotmail.se",
                    CarId = 3,
                });


        }
    }
}
