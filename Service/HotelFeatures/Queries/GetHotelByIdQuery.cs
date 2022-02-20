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
    public class GetHotelByIdQuery : IRequest<Hotel>
    {
        public Guid hotelId { get; set; }

        public class GetHotelByIdQueryHandler : IRequestHandler<GetHotelByIdQuery, Hotel>
        {
            private readonly IApplicationDbContext _context;
            public GetHotelByIdQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<Hotel> Handle(GetHotelByIdQuery request, CancellationToken cancellationToken)
            {
                var hotel = await _context.Hotel.Include(a=>a.Facilities).Where(a => a.Id == request.hotelId).FirstOrDefaultAsync();
                if (hotel == null) return null;
                return hotel;
            }
        }
    }
}

