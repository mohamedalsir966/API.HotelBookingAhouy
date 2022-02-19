using Domain.Entities;
using MediatR;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Service.BookingFeatures.Commands
{
    public class CreateBookingCommand : IRequest<Booking>
    {
        public Guid hotelId { get; set; }
        public string CustomerName { get; set; }
        public DateTime CheckinDate { get; set; }
        public DateTime CheckoutDate { get; set; }
        public int RoomNo { get; set; }
        public BedType BedType { get; set; }
        public class Response : BaseResponse
        {

        }
        public class CreateNewHotelCommandHandler : IRequestHandler<CreateBookingCommand, Booking>
        {
            private readonly IApplicationDbContext _context;
            public CreateNewHotelCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<Booking> Handle(CreateBookingCommand request, CancellationToken cancellationToken)
            {
                var hotel = _context.Hotel.Where(a => a.Id == request.hotelId).FirstOrDefault();
                Booking booking = new Booking()
                {
                    Id = Guid.NewGuid(),
                    HotelId = request.hotelId,
                    CustomerName = request.CustomerName,
                    CheckinDate = request.CheckinDate,
                    CheckoutDate = request.CheckoutDate,
                    RoomNo = request.RoomNo,
                    BedType = request.BedType


                };
                if (hotel != null)
                {
                    _context.Booking.Add(booking);
                    await _context.SaveChangesAsync();
                    return booking;
                }
                else
                {
                    return default;
                }

            }
        }
    }
}
