using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WeDriveRental.Migrations
{
    /// <inheritdoc />
    public partial class CarModelBookingModelAndSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PricePerDayInSEK = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CarId = table.Column<int>(type: "int", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bookings_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Bookings_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "Description", "ImageUrl", "IsAvailable", "Name", "PricePerDayInSEK" },
                values: new object[,]
                {
                    { 1, "The 2022 Lamborghini Urus is a cutting-edge luxury SUV that merges striking Italian design with exceptional performance, boasting a potent V8 engine, unparalleled acceleration, and a lavish interior, affirming its status as a high-performance and stylish crossover.", "https://www.oneclickdrive.com/uploads/Lamborghini_Urus-Pearl-Capsule_2022_12394_12394_13220768648-2_small.jpg?ocd=5.15", true, "Lamborghini Urus 2022", 3099m },
                    { 2, "The 2020 Range Rover Sport SVR is a luxury SUV that seamlessly blends opulent craftsmanship with high-performance capabilities, featuring a robust supercharged V8 engine, advanced off-road prowess, and a refined interior for a thrilling yet comfortable driving experience.", "https://www.oneclickdrive.com/uploads/Land-Rover_Range-Rover-Sport-SVR_2020_9075_9075_6512373439-1_small.jpg?ocd=5.15", true, "Range Rover Sport SVR 2020", 1699m },
                    { 3, "The 2021 Audi R8 Spyder is a high-performance convertible sports car that combines a breathtaking open-top driving experience with a powerful V10 engine, delivering exhilarating performance and cutting-edge technology in a stylish and aerodynamic design.", "https://www.oneclickdrive.com/application/views/img/watermark_img/Audi_R8-V10-Spyder_2022_10927_10927_3461148360-1_small.jpg?ocd=5.15", true, "Audi R8 Spyder 2021", 2299m },
                    { 4, "The 2019 Aston Martin Vantage is a captivating sports car that exemplifies British elegance and performance, featuring a distinctive design, a potent V8 engine, and a well-crafted interior, delivering a thrilling and refined driving experience.", "https://www.oneclickdrive.com/application/views/img/watermark_img/Aston-Martin-Vantage-2019_10776_22671623575-11_10776__small.jpg?ocd=5.15", true, "Aston Martin Vantage 2019", 2199m },
                    { 5, "The 2023 Mercedes-Benz AMG G63 Brabus is a luxurious and powerful SUV, showcasing a bespoke and aggressively styled exterior, a handcrafted high-performance engine by Brabus, and an opulent interior, combining refined comfort with unparalleled off-road capabilities.", "https://www.oneclickdrive.com/application/views/img/watermark_img/Mercedes-Benz_AMG-G63-Brabus_2023_27236_27236_19930451718-11_small.jpg?ocd=5.15", true, "Mercedes Benz AMG G63 Brabus 2023", 2999m },
                    { 6, "The 2019 Porsche 911 Carrera GTS is a precision-engineered sports car that epitomizes driving excellence, featuring a turbocharged flat-six engine, precise handling, and a timeless design, delivering an exhilarating and dynamic driving experience.", "https://www.oneclickdrive.com/application/views/img/watermark_img/Porsche_911-Carrera-GTS_2019_14793_14793_11734217763-1_small.jpg?ocd=5.15", true, "Porsche 911 Carrera GTS 2019", 1899m }
                });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "Id", "ApplicationUserId", "CarId", "UserEmail" },
                values: new object[] { 1, null, 3, "elle@hotmail.se" });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_ApplicationUserId",
                table: "Bookings",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_CarId",
                table: "Bookings",
                column: "CarId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "Cars");
        }
    }
}
