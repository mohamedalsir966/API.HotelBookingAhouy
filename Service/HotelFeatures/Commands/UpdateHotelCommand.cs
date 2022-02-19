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
    public class UpdateHotelCommand : IRequest<Guid>
    {
        public Guid hotelId { get; set; }
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
        public class UpdateHotelCommandHandler : IRequestHandler<UpdateHotelCommand, Guid>
        {
            private readonly IApplicationDbContext _context;
            public UpdateHotelCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<Guid> Handle(UpdateHotelCommand request, CancellationToken cancellationToken)
            {
                var hotil = _context.Hotel.Where(a => a.Id == request.hotelId).FirstOrDefault();

                if (hotil == null)
                {
                    return default;
                }
                else
                {
                    hotil.Name = request.Name;
                    _context.Hotel.Update(hotil);
                    await _context.SaveChangesAsync();
                    return hotil.Id;
                }
            }
        }
    }
}
