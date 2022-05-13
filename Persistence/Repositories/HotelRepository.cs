using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class HotelRepository : IHotelRepository
    {
        private readonly IApplicationDbContext _context;
        public HotelRepository(IApplicationDbContext context)
        {
            _context = context;

        }

        public async Task<Hotel> CreateNewHotelCommand(Hotel hotel)
        {
            _context.Hotel.Add(hotel);
            await _context.SaveChangesAsync();
            return hotel;
        }

        public async Task<Hotel> DeleteHotelByIdCommand(Hotel hotel)
        {
            hotel.IsDeleted = true;
            await _context.SaveChangesAsync();
            return hotel;
        }

        public async Task<List<Hotel>> GetAllHotelsQuery()
        {
            var hotels = await _context.Hotel.Include(a => a.FacilitesHotel).ThenInclude(y => y.facilities).ToListAsync();
            return hotels;
        }

        public async Task<Hotel> GetHotelByIdQuery(Guid? id)
        {
            var hotel = await _context.Hotel.Include(a => a.FacilitesHotel).ThenInclude(y => y.facilities).Where(a => a.Id == id).FirstOrDefaultAsync();
            return hotel;
        }

        public async Task<List<Hotel>> GetSearchHotilQuery(string hotelname)
        {
            var hotel = await _context.Hotel.Include(a => a.FacilitesHotel)
                          .Where(h => h.Name.ToLower().Contains(hotelname.Trim().ToLower())).ToListAsync();
            return hotel;
        }

        public async Task<Hotel> UpdateHotelByIdCommand(Hotel existinghotel)
        {
            await _context.SaveChangesAsync();
            return existinghotel;
        }
    }
}
