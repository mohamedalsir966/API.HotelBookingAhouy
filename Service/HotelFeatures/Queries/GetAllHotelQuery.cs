using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Service.HotelFeatures.Queries
{
    public class GetAllHotelQuery : IRequest<IEnumerable<Hotel>>
    {
        public class GetAllHotelQueryHandler : IRequestHandler<GetAllHotelQuery, IEnumerable< Hotel>>
        {
            private readonly IApplicationDbContext _context;
            public GetAllHotelQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<Hotel>> Handle(GetAllHotelQuery request, CancellationToken cancellationToken)
            {
                var hotels = await _context.Hotel.Include(a => a.Facilities).ToListAsync();
                //var hotel = await _context.Hotel.Include(a=>a.Facilities).Where(a => a.Id == request.hotelId).FirstOrDefaultAsync();
                if (hotels == null) return null;
                return hotels;
            }
        }
    }

}

