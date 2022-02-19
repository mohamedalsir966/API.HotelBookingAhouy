using Domain.Entities;
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

    public class CreateNewHotelCommand : IRequest<Guid?>
    {
        public string Name { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Description { get; set; }
         public ICollection<Facilities> Facilities { get; set; }
        public int Rate { get; set; }
        public string ImageUrl { get; set; }
        public class Response : BaseResponse
        {

        }
        public class CreateNewHotelCommandHandler : IRequestHandler<CreateNewHotelCommand, Guid?>
        {
            private readonly IApplicationDbContext _context;
            public CreateNewHotelCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<Guid?> Handle(CreateNewHotelCommand request, CancellationToken cancellationToken)
            {
                var Hotel = new Hotel
                {
                    Id=Guid.NewGuid(),
                    Name = request.Name,
                    City = request.City,
                    State = request.State,
                    Description = request.Description,
                    Rate = request.Rate,
                    ImageUrl = request.ImageUrl


                };
                if (request.Facilities != null)
                {
                    foreach (var item in request.Facilities)
                    {
                        FacilitesHotel facilitesHotel = new FacilitesHotel();
                        facilitesHotel.Id = Guid.NewGuid();
                        facilitesHotel.hotelId = Hotel.Id;
                        if (Enum.IsDefined(typeof(Facilities), item))
                        {
                            facilitesHotel.facilities = item;
                        }

                        _context.FacilitesHotel.Add(facilitesHotel);
                    }
                }

                _context.Hotel.Add(Hotel);
                await _context.SaveChangesAsync();
                return Hotel.Id;
            }
        }
    }

}
