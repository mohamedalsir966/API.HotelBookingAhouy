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
    public class GetAllHotelQuery : IRequest<List<Hotel>>
    {
        public class GetAllHotelQueryHandler : IRequestHandler<GetAllHotelQuery, List< Hotel>>
        {
            private readonly IApplicationDbContext _context;
            public GetAllHotelQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<List<Hotel>> Handle(GetAllHotelQuery request, CancellationToken cancellationToken)
            {
                var hotels = await _context.Hotel.Include(a => a.Facilities).ToListAsync();
                if (hotels == null) return null;
                return hotels;
            }
        }
    }

}

