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

namespace Service.BookingFeatures.Queries
{
    public class GetAllBookingQuery : IRequest<List<Booking>>
    {
        public class GetAllBookingQueryHandler : IRequestHandler<GetAllBookingQuery, List<Booking>>
        {
            private readonly IApplicationDbContext _context;
            public GetAllBookingQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<List<Booking>> Handle(GetAllBookingQuery request, CancellationToken cancellationToken)
            {
                var bookings = await _context.Booking.ToListAsync();
                if (bookings == null) return null;
                return bookings;
            }
        }
    }
}
