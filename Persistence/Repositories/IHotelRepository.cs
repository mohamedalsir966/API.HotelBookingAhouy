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
        Task<Hotel> GetHotilByIdQuery(Guid? id);
        Task<Hotel> DeleteHotilByIdCommand(Hotel hotel);
        Task<Hotel> CreateNewHotelCommand(Hotel hotel);
        Task<List<Hotel>> GetAllHotilsQuery();
        Task<List<Hotel>> GetSearchHotilQuery(string hotelname);
    }
}
