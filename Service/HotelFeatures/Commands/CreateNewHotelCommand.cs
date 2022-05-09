using AutoMapper;
using Domain.Entities;
using MediatR;
using Persistence;
using Service.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Service.HotelFeatures.Commands
{
    public class CreateNewHotelCommand : IRequest<HotelResponse>
    {
        public string Name { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Rate { get; set; }
        public string ImageUrl { get; set; }

        public class CreateNewHotelCommandHandler : IRequestHandler<CreateNewHotelCommand, HotelResponse>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;
            public CreateNewHotelCommandHandler(IApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<HotelResponse> Handle(CreateNewHotelCommand command, CancellationToken cancellationToken)
            {
                var hotel = _mapper.Map<Hotel>(command);
                _context.Hotel.Add(hotel);
                await _context.SaveChangesAsync();

               
                return new HotelResponse
                {
                    Data = _mapper.Map<HotelDto>(hotel),
                    StatusCode = 200,
                    Message = "Data has been added"
                };
            }
        }
    }

}
