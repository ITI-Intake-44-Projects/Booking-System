
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

            // locations class data 
            #region locations class data 
            modelBuilder.Entity<Location>().HasData(
            new Location
            {
                LocationId = 1,
                Country = "Indonesia",
                City = "Bali"
            },
            new Location
            {
                LocationId = 2,
                Country = "Norway",
                City = "Norway"
            },
            new Location
            {
                LocationId = 3,
                Country = "Switzerland",
                City = "Swiss Alps"
            },
            new Location
            {
                LocationId = 4,
                Country = "Morocco",
                City = "Marrakech"
            },
            new Location
            {
                LocationId = 5,
                Country = "USA",
                City = "New York City"
            },
            new Location
            {
                LocationId = 6,
                Country = "UK",
                City = "Scottish Highlands"
            },
            new Location
            {
                LocationId = 7,
                Country = "USA",
                City = "Napa Valley, California"
            },
            new Location
            {
                LocationId = 8,
                Country = "Maldives",
                City = "Maldives"
            },
            new Location
            {
                LocationId = 9,
                Country = "Brazil",
                City = "Amazon Rainforest"
            },
            new Location
            {
                LocationId = 10,
                Country = "Iceland",
                City = "Iceland"
            },
            new Location
            {
                LocationId = 11,
                Country = "Indonesia",
                City = "Ubud, Bali"
            },
            new Location
            {
                LocationId = 12,
                Country = "Argentina",
                City = "Patagonia"
            },
            new Location
            {
                LocationId = 13,
                Country = "Uzbekistan",
                City = "Uzbekistan"
            },
            new Location
            {
                LocationId = 14,
                Country = "Jordan",
                City = "Wadi Rum"
            },
            new Location
            {
                LocationId = 15,
                Country = "Australia",
                City = "Great Barrier Reef"
            },
            new Location
            {
                LocationId = 16,
                Country = "Costa Rica",
                City = "Rica"
            }
        );
            #endregion

            // hotel class data 
            #region hotel class data
            modelBuilder.Entity<Hotel>().HasData(
              new Hotel
              {
                  HotelId = 1,
                  Name = "Sun Kissed Villas",
                  HotelType = "Beachfront",
                  HotelDescription = "Private villas with stunning ocean views",
                  Address = "Bali, Indonesia",
                  LocationId = 1,
              },
              new Hotel
              {
                  HotelId = 2,
                  Name = "The Nordic Escape",
                  HotelType = "Eco-lodge",
                  HotelDescription = "Sustainable cabins nestled amidst the fjords",
                  Address = "Norway",
                  LocationId = 2,
              },
              new Hotel
              {
                  HotelId = 3,
                  Name = "Alpenglow Chalet",
                  HotelType = "Ski-in/Ski-out",
                  HotelDescription = "Luxury chalet with direct access to ski slopes",
                  Address = "Swiss Alps",
                  LocationId = 3,
              },
              new Hotel
              {
                  HotelId = 4,
                  Name = "Riad of Marrakech",
                  HotelType = "Riad",
                  HotelDescription = "Traditional Moroccan riad with a central courtyard",
                  Address = "Marrakech, Morocco",
                  LocationId = 4,
              },
              new Hotel
              {
                  HotelId = 5,
                  Name = "The Urban Oasis",
                  HotelType = "Boutique",
                  HotelDescription = "Stylish hotel in the heart of the city",
                  Address = "New York City, USA",
                  LocationId = 5,
              },
              new Hotel
              {
                  HotelId = 6,
                  Name = "Castle on the Hill",
                  HotelType = "Historic",
                  HotelDescription = "Converted medieval castle with modern amenities",
                  Address = "Scottish Highlands, UK",
                  LocationId = 6,
              },
              new Hotel
              {
                  HotelId = 7,
                  Name = "Vineyard Escape",
                  HotelType = "Winery",
                  HotelDescription = "Relaxing stay amidst rolling vineyards with wine tastings",
                  Address = "Napa Valley, California, USA",
                  LocationId = 7,
              },
              new Hotel
              {
                  HotelId = 8,
                  Name = "The Floating Bungalows",
                  HotelType = "Overwater Bungalows",
                  HotelDescription = "Unique bungalows perched above crystal-clear waters",
                  Address = "Maldives",
                  LocationId = 8,
              },
              new Hotel
              {
                  HotelId = 9,
                  Name = "The Jungle Lodge",
                  HotelType = "Eco-tourism",
                  HotelDescription = "Immerse yourself in nature with sustainable lodging in the rainforest",
                  Address = "Amazon Rainforest, Brazil",
                  LocationId = 9,
              },
              new Hotel
              {
                  HotelId = 10,
                  Name = "The Northern Lights Retreat",
                  HotelType = "Remote",
                  HotelDescription = "Secluded cabins with a chance to witness the aurora borealis",
                  Address = "Iceland",
                  LocationId = 10
              },
              new Hotel
              {
                  HotelId = 11,
                  Name = "Temple View Sanctuary",
                  HotelType = "Spiritual Retreat",
                  HotelDescription = "Tranquil retreat with meditation classes and yoga sessions",
                  Address = "Ubud, Bali, Indonesia",
                  LocationId = 11,
              },
              new Hotel
              {
                  HotelId = 12,
                  Name = "Patagonian Adventure Lodge",
                  HotelType = "Adventure",
                  HotelDescription = "Basecamp for exploring glaciers, mountains, and wildlife",
                  Address = "Patagonia, Argentina",
                  LocationId = 12,
              },
              new Hotel
              {
                  HotelId = 13,
                  Name = "Silk Road Oasis",
                  HotelType = "Historical",
                  HotelDescription = "Caravanserai-style hotel along the ancient Silk Road trade route",
                  Address = "Uzbekistan",
                  LocationId = 13,
              },
              new Hotel
              {
                  HotelId = 14,
                  Name = "Desert Stargazing Camp",
                  HotelType = "Glamping",
                  HotelDescription = "Luxurious tents under a canopy of stars in the desert",
                  Address = "Wadi Rum, Jordan",
                  LocationId = 14,
              },
              new Hotel
              {
                  HotelId = 15,
                  Name = "Underwater Sanctuary",
                  HotelType = "Underwater",
                  HotelDescription = "Unique hotel offering underwater views of marine life",
                  Address = "Great Barrier Reef, Australia",
                  LocationId = 15,
              },
              new Hotel
              {
                  HotelId = 16,
                  Name = "Treetop Canopy Cabins",
                  HotelType = "Ecotourism",
                  HotelDescription = "Sustainable cabins nestled amidst the rainforest canopy",
                  Address = "Costa Rica",
                  LocationId = 16,
              }
            );
            #endregion

            // Room class data 
            #region room class data
            modelBuilder.Entity<Room>().HasData(
              new Room
              {
                  RoomID = 1,
                  RoomType = "Luxury Cabin",
                  Description = "Modern cabin with a fireplace, jacuzzi, and private balcony",
                  PriceOfNight = 400,
                  RoomNumber = "Cabin 3",
                  HotelId = 1
              },
              new Room
              {
                  RoomID = 2,
                  RoomType = "Standard Room",
                  Description = "Comfortable room with mountain views",
                  PriceOfNight = 250,
                  RoomNumber = "Room 101",
                  HotelId = 1
              },
              new Room
              {
                  RoomID = 3,
                  RoomType = "Suite",
                  Description = "Spacious suite with a living area, fireplace, and balcony",
                  PriceOfNight = 500,
                  RoomNumber = "Suite 202",
                  HotelId = 2
              },
              new Room
              {
                  RoomID = 4,
                  RoomType = "Standard Riad Room",
                  Description = "Traditional Moroccan room with a central courtyard view",
                  PriceOfNight = 150,
                  RoomNumber = "Room A1",
                  HotelId = 3
              },
              new Room
              {
                  RoomID = 5,
                  RoomType = "Riad Suite",
                  Description = "Luxurious suite with a private hammam (steam bath)",
                  PriceOfNight = 300,
                  RoomNumber = "Suite B2",
                  HotelId = 4
              },
              new Room
              {
                  RoomID = 6,
                  RoomType = "City View Room",
                  Description = "Modern room with stunning city views",
                  PriceOfNight = 200,
                  RoomNumber = "Room 301",
                  HotelId = 5
              },
              new Room
              {
                  RoomID = 7,
                  RoomType = "Studio Apartment",
                  Description = "Compact apartment with a kitchenette and city views",
                  PriceOfNight = 250,
                  RoomNumber = "Suite 402",
                  HotelId = 6
              },
              new Room
              {
                  RoomID = 8,
                  RoomType = "Standard Room",
                  Description = "Cozy room with a historical feel",
                  PriceOfNight = 180,
                  RoomNumber = "Room 501",
                  HotelId = 7
              },
              new Room
              {
                  RoomID = 9,
                  RoomType = "Four-Poster Suite",
                  Description = "Luxury suite with a four-poster bed and a fireplace",
                  PriceOfNight = 400,
                  RoomNumber = "Suite 602",
                  HotelId = 8
              },
              new Room
              {
                  RoomID = 10,
                  RoomType = "Fine Suite",
                  Description = "Luxury suite with a four-poster bed and a fireplace",
                  PriceOfNight = 400,
                  RoomNumber = "Suite 610",
                  HotelId = 9
              },
              new Room
              {
                  RoomID = 11,
                  RoomType = "Jungle Bungalow",
                  Description = "Private bungalow nestled in the rainforest canopy with a balcony",
                  PriceOfNight = 250,
                  RoomNumber = "Bungalow 3",
                  HotelId = 10
              },
              new Room
              {
                  RoomID = 12,
                  RoomType = "Standard Cabin",
                  Description = "Cozy cabin with basic amenities and stunning aurora borealis views",
                  PriceOfNight = 180,
                  RoomNumber = "Cabin 4",
                  HotelId = 11
              },
              new Room
              {
                  RoomID = 13,
                  RoomType = "Luxury Chalet",
                  Description = "Spacious chalet with a fireplace, jacuzzi, and private balcony with aurora views",
                  PriceOfNight = 500,
                  RoomNumber = "Chalet 5",
                  HotelId = 12
              },
              new Room
              {
                  RoomID = 14,
                  RoomType = "Deluxe Room",
                  Description = "Comfortable room with a balcony overlooking the temple grounds",
                  PriceOfNight = 120,
                  RoomNumber = "Room 701",
                  HotelId = 13
              },
              new Room
              {
                  RoomID = 15,
                  RoomType = "Private Retreat",
                  Description = "Secluded bungalow with a private meditation garden",
                  PriceOfNight = 300,
                  RoomNumber = "Retreat 802",
                  HotelId = 14
              },
              new Room
              {
                  RoomID = 16,
                  RoomType = "Private Retreat",
                  Description = "Secluded bungalow with a private meditation garden",
                  PriceOfNight = 300,
                  RoomNumber = "Retreat 802",
                  HotelId = 15
              },
              new Room
              {
                  RoomID = 17,
                  RoomType = "Private Retreat",
                  Description = "Secluded bungalow with a private meditation garden",
                  PriceOfNight = 300,
                  RoomNumber = "Retreat 802",
                  HotelId = 16
              },
              new Room
              {
                  RoomID = 18,
                  RoomType = "Private Retreat",
                  Description = "Secluded bungalow with a private meditation garden",
                  PriceOfNight = 300,
                  RoomNumber = "Retreat 802",
                  HotelId = 2
              },
              new Room
              {
                  RoomID = 19,
                  RoomType = "Private Retreat",
                  Description = "Secluded bungalow with a private meditation garden",
                  PriceOfNight = 300,
                  RoomNumber = "Retreat 802",
                  HotelId = 3
              },
              new Room
              {
                  RoomID = 20,
                  RoomType = "Private Retreat",
                  Description = "Secluded bungalow with a private meditation garden",
                  PriceOfNight = 300,
                  RoomNumber = "Retreat 802",
                  HotelId = 4
              },
              new Room
              {
                  RoomID = 21,
                  RoomType = "Private Retreat",
                  Description = "Secluded bungalow with a private meditation garden",
                  PriceOfNight = 300,
                  RoomNumber = "Retreat 802",
                  HotelId = 1
              },
              new Room
              {
                  RoomID = 22,
                  RoomType = "Deluxe Room",
                  Description = "Comfortable room with a balcony overlooking the temple grounds",
                  PriceOfNight = 120,
                  RoomNumber = "Room 701",
                  HotelId = 1
              }

              );
            #endregion

            // Non Hotel class data
            #region NonHotel Class Data
            modelBuilder.Entity<NonHotel>().HasData(
                new NonHotel
                {
                    NonHotelId = 1,
                    Name = "The Rosewood Cottage",
                    Description = "Escape to a tranquil retreat in a picturesque village. This cozy cottage features a wood-burning fireplace, a private garden, and views of rolling hills.",
                    Type = "Cottage",
                    Address = "4 Lavender Lane, Willowbrook",
                    Reserved = false,
                    LocationId = 1
                },
                new NonHotel
                {
                    NonHotelId = 2,
                    Name = "The Redwood Hideaway",
                    Description = "Immerse yourself in nature at this secluded cabin nestled among towering redwood trees. Enjoy stargazing from the hot tub, hiking trails, and a cozy fireplace.",
                    Type = "Cabin",
                    Address = "Forest Road 12, Redwood National Park",
                    Reserved = false,
                    LocationId = 9
                },
                new NonHotel
                {
                    NonHotelId = 3,
                    Name = "Sunrise Farmstay",
                    Description = "Reconnect with nature and farm life at this charming farmhouse. Collect fresh eggs, help with farm chores, and enjoy home-cooked meals made with local produce.",
                    Type = "Farmstay",
                    Address = "154 Apple Orchard Lane, Sunnydale",
                    Reserved = true,
                    LocationId = 16
                },
                new NonHotel
                {
                    NonHotelId = 4,
                    Name = "The Tranquility",
                    Description = "Experience tranquility on a spacious houseboat with panoramic lake views. Relax on the sundeck, kayak to nearby islands, and unwind under starry skies.",
                    Type = "Houseboat",
                    Address = "Lake Serenity Marina, Slip 54",
                    Reserved = false,
                    LocationId = 14
                },
                new NonHotel
                {
                    NonHotelId = 5,
                    Name = "The Enchanted Canopy",
                    Description = "Escape to a magical world in this luxurious treehouse nestled among ancient pines. Enjoy panoramic forest views, a private hot tub, and a cozy fireplace.",
                    Type = "Treehouse",
                    Address = "Hidden Forest Trail, Treetop Haven",
                    Reserved = false,
                    LocationId = 4
                },
                new NonHotel
                {
                    NonHotelId = 6,
                    Name = "Isle of Serenity",
                    Description = "Immerse yourself in paradise on a private island villa surrounded by crystal-clear waters. Enjoy secluded beaches, snorkeling, kayaking, and breathtaking sunsets.",
                    Type = "Villa",
                    Address = "Isle of Serenity, Private Island",
                    Reserved = false,
                    LocationId = 8
                },
                new NonHotel
                {
                    NonHotelId = 7,
                    Name = "Stargazer Yurts",
                    Description = "Experience the peace of a yurt retreat in a breathtaking mountain setting. Enjoy stargazing from the clear mountain skies, hiking trails, and campfire gatherings.",
                    Type = "Yurt",
                    Address = "Mountain Meadows Yurt Village",
                    Reserved = false,
                    LocationId = 12
                }
            );
            #endregion

            base.OnModelCreating(modelBuilder);
        }
    }
}
