using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookingSystem.Migrations
{
    /// <inheritdoc />
    public partial class locationhotelroomnonhoteldata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "LocationId", "City", "CityImage", "Country" },
                values: new object[,]
                {
                    { 1, "Bali", null, "Indonesia" },
                    { 2, "Norway", null, "Norway" },
                    { 3, "Swiss Alps", null, "Switzerland" },
                    { 4, "Marrakech", null, "Morocco" },
                    { 5, "New York City", null, "USA" },
                    { 6, "Scottish Highlands", null, "UK" },
                    { 7, "Napa Valley, California", null, "USA" },
                    { 8, "Maldives", null, "Maldives" },
                    { 9, "Amazon Rainforest", null, "Brazil" },
                    { 10, "Iceland", null, "Iceland" },
                    { 11, "Ubud, Bali", null, "Indonesia" },
                    { 12, "Patagonia", null, "Argentina" },
                    { 13, "Uzbekistan", null, "Uzbekistan" },
                    { 14, "Wadi Rum", null, "Jordan" },
                    { 15, "Great Barrier Reef", null, "Australia" },
                    { 16, "Rica", null, "Costa Rica" }
                });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "HotelId", "Address", "HotelDescription", "HotelType", "LocationId", "Name", "RoomNumber" },
                values: new object[,]
                {
                    { 1, "Bali, Indonesia", "Private villas with stunning ocean views", "Beachfront", 1, "Sun Kissed Villas", null },
                    { 2, "Norway", "Sustainable cabins nestled amidst the fjords", "Eco-lodge", 2, "The Nordic Escape", null },
                    { 3, "Swiss Alps", "Luxury chalet with direct access to ski slopes", "Ski-in/Ski-out", 3, "Alpenglow Chalet", null },
                    { 4, "Marrakech, Morocco", "Traditional Moroccan riad with a central courtyard", "Riad", 4, "Riad of Marrakech", null },
                    { 5, "New York City, USA", "Stylish hotel in the heart of the city", "Boutique", 5, "The Urban Oasis", null },
                    { 6, "Scottish Highlands, UK", "Converted medieval castle with modern amenities", "Historic", 6, "Castle on the Hill", null },
                    { 7, "Napa Valley, California, USA", "Relaxing stay amidst rolling vineyards with wine tastings", "Winery", 7, "Vineyard Escape", null },
                    { 8, "Maldives", "Unique bungalows perched above crystal-clear waters", "Overwater Bungalows", 8, "The Floating Bungalows", null },
                    { 9, "Amazon Rainforest, Brazil", "Immerse yourself in nature with sustainable lodging in the rainforest", "Eco-tourism", 9, "The Jungle Lodge", null },
                    { 10, "Iceland", "Secluded cabins with a chance to witness the aurora borealis", "Remote", 10, "The Northern Lights Retreat", null },
                    { 11, "Ubud, Bali, Indonesia", "Tranquil retreat with meditation classes and yoga sessions", "Spiritual Retreat", 11, "Temple View Sanctuary", null },
                    { 12, "Patagonia, Argentina", "Basecamp for exploring glaciers, mountains, and wildlife", "Adventure", 12, "Patagonian Adventure Lodge", null },
                    { 13, "Uzbekistan", "Caravanserai-style hotel along the ancient Silk Road trade route", "Historical", 13, "Silk Road Oasis", null },
                    { 14, "Wadi Rum, Jordan", "Luxurious tents under a canopy of stars in the desert", "Glamping", 14, "Desert Stargazing Camp", null },
                    { 15, "Great Barrier Reef, Australia", "Unique hotel offering underwater views of marine life", "Underwater", 15, "Underwater Sanctuary", null },
                    { 16, "Costa Rica", "Sustainable cabins nestled amidst the rainforest canopy", "Ecotourism", 16, "Treetop Canopy Cabins", null }
                });

            migrationBuilder.InsertData(
                table: "NonHotels",
                columns: new[] { "NonHotelId", "Address", "Description", "LocationId", "Name", "Reserved", "Type" },
                values: new object[,]
                {
                    { 1, "4 Lavender Lane, Willowbrook", "Escape to a tranquil retreat in a picturesque village. This cozy cottage features a wood-burning fireplace, a private garden, and views of rolling hills.", 1, "The Rosewood Cottage", false, "Cottage" },
                    { 2, "Forest Road 12, Redwood National Park", "Immerse yourself in nature at this secluded cabin nestled among towering redwood trees. Enjoy stargazing from the hot tub, hiking trails, and a cozy fireplace.", 9, "The Redwood Hideaway", false, "Cabin" },
                    { 3, "154 Apple Orchard Lane, Sunnydale", "Reconnect with nature and farm life at this charming farmhouse. Collect fresh eggs, help with farm chores, and enjoy home-cooked meals made with local produce.", 16, "Sunrise Farmstay", true, "Farmstay" },
                    { 4, "Lake Serenity Marina, Slip 54", "Experience tranquility on a spacious houseboat with panoramic lake views. Relax on the sundeck, kayak to nearby islands, and unwind under starry skies.", 14, "The Tranquility", false, "Houseboat" },
                    { 5, "Hidden Forest Trail, Treetop Haven", "Escape to a magical world in this luxurious treehouse nestled among ancient pines. Enjoy panoramic forest views, a private hot tub, and a cozy fireplace.", 4, "The Enchanted Canopy", false, "Treehouse" },
                    { 6, "Isle of Serenity, Private Island", "Immerse yourself in paradise on a private island villa surrounded by crystal-clear waters. Enjoy secluded beaches, snorkeling, kayaking, and breathtaking sunsets.", 8, "Isle of Serenity", false, "Villa" },
                    { 7, "Mountain Meadows Yurt Village", "Experience the peace of a yurt retreat in a breathtaking mountain setting. Enjoy stargazing from the clear mountain skies, hiking trails, and campfire gatherings.", 12, "Stargazer Yurts", false, "Yurt" }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "RoomID", "Description", "HotelId", "PriceOfNight", "Reserved", "RoomNumber", "RoomType" },
                values: new object[,]
                {
                    { 1, "Modern cabin with a fireplace, jacuzzi, and private balcony", 1, 400, null, "Cabin 3", "Luxury Cabin" },
                    { 2, "Comfortable room with mountain views", 1, 250, null, "Room 101", "Standard Room" },
                    { 3, "Spacious suite with a living area, fireplace, and balcony", 2, 500, null, "Suite 202", "Suite" },
                    { 4, "Traditional Moroccan room with a central courtyard view", 3, 150, null, "Room A1", "Standard Riad Room" },
                    { 5, "Luxurious suite with a private hammam (steam bath)", 4, 300, null, "Suite B2", "Riad Suite" },
                    { 6, "Modern room with stunning city views", 5, 200, null, "Room 301", "City View Room" },
                    { 7, "Compact apartment with a kitchenette and city views", 6, 250, null, "Suite 402", "Studio Apartment" },
                    { 8, "Cozy room with a historical feel", 7, 180, null, "Room 501", "Standard Room" },
                    { 9, "Luxury suite with a four-poster bed and a fireplace", 8, 400, null, "Suite 602", "Four-Poster Suite" },
                    { 10, "Luxury suite with a four-poster bed and a fireplace", 9, 400, null, "Suite 610", "Fine Suite" },
                    { 11, "Private bungalow nestled in the rainforest canopy with a balcony", 10, 250, null, "Bungalow 3", "Jungle Bungalow" },
                    { 12, "Cozy cabin with basic amenities and stunning aurora borealis views", 11, 180, null, "Cabin 4", "Standard Cabin" },
                    { 13, "Spacious chalet with a fireplace, jacuzzi, and private balcony with aurora views", 12, 500, null, "Chalet 5", "Luxury Chalet" },
                    { 14, "Comfortable room with a balcony overlooking the temple grounds", 13, 120, null, "Room 701", "Deluxe Room" },
                    { 15, "Secluded bungalow with a private meditation garden", 14, 300, null, "Retreat 802", "Private Retreat" },
                    { 16, "Secluded bungalow with a private meditation garden", 15, 300, null, "Retreat 802", "Private Retreat" },
                    { 17, "Secluded bungalow with a private meditation garden", 16, 300, null, "Retreat 802", "Private Retreat" },
                    { 18, "Secluded bungalow with a private meditation garden", 2, 300, null, "Retreat 802", "Private Retreat" },
                    { 19, "Secluded bungalow with a private meditation garden", 3, 300, null, "Retreat 802", "Private Retreat" },
                    { 20, "Secluded bungalow with a private meditation garden", 4, 300, null, "Retreat 802", "Private Retreat" },
                    { 21, "Secluded bungalow with a private meditation garden", 1, 300, null, "Retreat 802", "Private Retreat" },
                    { 22, "Comfortable room with a balcony overlooking the temple grounds", 1, 120, null, "Room 701", "Deluxe Room" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "NonHotels",
                keyColumn: "NonHotelId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "NonHotels",
                keyColumn: "NonHotelId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "NonHotels",
                keyColumn: "NonHotelId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "NonHotels",
                keyColumn: "NonHotelId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "NonHotels",
                keyColumn: "NonHotelId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "NonHotels",
                keyColumn: "NonHotelId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "NonHotels",
                keyColumn: "NonHotelId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomID",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomID",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomID",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomID",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomID",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomID",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomID",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomID",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomID",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomID",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomID",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomID",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: 16);
        }
    }
}
