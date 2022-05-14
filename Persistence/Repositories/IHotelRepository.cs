using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public interface IHotelRepository
    {
        Task<Hotel> GetHotelByIdQuery(Guid? id);
        Task<Hotel> DeleteHotelByIdCommand(Hotel hotel);
        Task<Hotel> UpdateHotelByIdCommand(Hotel hotel);
        Task<Hotel> CreateNewHotelCommand(Hotel hotel);
        Task<List<Hotel>> GetAllHotelsQuery(int PageNumber, int PageSize);
        Task<List<Hotel>> GetSearchHotilQuery(string hotelname, int PageSize, int PageNumber);
    }
}
