using MediatR;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Service.HotelFeatures.Commands
{
    public class DeleteHotelByIdCommand : IRequest<Guid?>
    {
        public Guid hotelId { get; set; }

        public class DeleteHotelByIdCommandHandler : IRequestHandler<DeleteHotelByIdCommand, Guid?>
        {
            private readonly IApplicationDbContext _context;
            public DeleteHotelByIdCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<Guid?> Handle(DeleteHotelByIdCommand request, CancellationToken cancellationToken)
            {
                var hotel = _context.Hotel.Where(a => a.Id == request.hotelId).FirstOrDefault();
                if (hotel == null) return default;
                if (hotel.Facilities!=null)
                {
                    var faciliteshotel = _context.FacilitesHotel.Where(a => a.hotelId == request.hotelId);

                    foreach (var item in faciliteshotel)
                    {
                        _context.FacilitesHotel.Remove(item);
                    }

                }
                _context.Hotel.Remove(hotel);
                await _context.SaveChangesAsync();
                return hotel.Id;
            }
        }
    }
}
