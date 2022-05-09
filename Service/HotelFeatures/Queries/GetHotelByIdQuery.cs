using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Service.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Service.HotelFeatures.Queries
{
    public class GetHotelByIdQuery : IRequest<HotelResponse>
    {
        public Guid hotelId { get; set; }

        public class GetHotelByIdQueryHandler : IRequestHandler<GetHotelByIdQuery, HotelResponse>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;
            public GetHotelByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<HotelResponse> Handle(GetHotelByIdQuery request, CancellationToken cancellationToken)
            {
                var hotel = await _context.Hotel.Include(a => a.FacilitesHotel).ThenInclude(y=>y.facilities).Where(a => a.Id == request.hotelId).AsNoTracking().FirstOrDefaultAsync();
                //var any = _mapper.Map<HotelDto>(hotel);
                if (hotel == null) {
                    return new HotelResponse
                    {
                        Data = null,
                        StatusCode = 404,
                        Message = "No data found"
                    };
                }

                return new HotelResponse
                {
                    Data = _mapper.Map<HotelDto>(hotel),
                    StatusCode = 200,
                    Message = "Data found"
                };
            }
        }
    }
}

