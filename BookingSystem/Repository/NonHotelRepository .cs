﻿using BookingSystem.Models;

namespace BookingSystem.Repository
{
    public class NonHotelRepository : Repository<NonHotel>,INonHotelRepository
    {
        public NonHotelRepository(BookingContext _context) :base(_context)
        {
            
        }

        public List<NonHotel> GetNonHotelsByCity(string city)
        {
            return context.NonHotels.Where(h=>h.Location.City == city).ToList();
        }
        public List<NonHotel> GetNonHotelsByType(string type , string city)
        {
            return context.NonHotels.Where(h => h.Location.City == city && h.Type == type).ToList();
        }

    }
}
