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
    public class SearchHotelQuery : IRequest<List<Hotel>>
    {
        public string HotelName { get; set; }
        public class SearchHotelQueryHandler : IRequestHandler<SearchHotelQuery, List<Hotel>>
        {
            private readonly IApplicationDbContext _context;
            public SearchHotelQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<List<Hotel>> Handle(SearchHotelQuery request, CancellationToken cancellationToken)
            {
                var hotelname = request.HotelName;
                if (!string.IsNullOrWhiteSpace(request.HotelName))
                {
                    var hotels = await _context.Hotel.Include(a => a.FacilitesHotel)
                              .Where(h=>h.Name.ToLower().Contains(hotelname.Trim().ToLower())).ToListAsync();
                    if (hotels == null) return null;
                    return hotels;
                }
                else
                {
                    return null;
                }

            }
        }
    }
}
