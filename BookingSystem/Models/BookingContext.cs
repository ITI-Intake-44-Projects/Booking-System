
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookingSystem.Models
{
    public class BookingContext : IdentityDbContext<ApplicationUser>
    {


        public BookingContext() : base(){ }
       
        public BookingContext(DbContextOptions<BookingContext> options) : base(options)
        {
            
        }

        public DbSet<Booking>? Bookings { get; set; }

        public DbSet<FeedBack>? FeedBacks { get; set; }

        public DbSet<Dependant>? Dependants { get; set; }

        public DbSet<Hotel>? Hotels { get; set; }

        public DbSet<NonHotel> ?NonHotels { get; set; }

        public DbSet<Room> ?Rooms { get; set; }

        public DbSet<Payment>? Payments { get; set; }

        public DbSet<Location>? Locations { get; set; }

        public DbSet<HotelImages>? HotelImages { get; set; }

        public DbSet<NonHotelImages>? NonHotelImages { get; set; }

        public DbSet<RoomImages>? RoomImages { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dependant>().HasKey("DepId", "UserId");

            modelBuilder.Entity<HotelImages>().HasKey("HotelId", "Image");

            modelBuilder.Entity<NonHotelImages>().HasKey("NonHotelId", "Image");

            modelBuilder.Entity<RoomImages>().HasKey("RoomId", "Image");

            base.OnModelCreating(modelBuilder);
        }
    }
}
