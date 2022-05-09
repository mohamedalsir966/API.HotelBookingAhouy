using AutoMapper;
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

namespace Service.FacilityFeatures.Queries
{
    public class GetAllHotelFacilityQuery : IRequest<FacilitiesHotelRespose>
    {
        public class GetHotelFacilityQueryHandler : IRequestHandler<GetAllHotelFacilityQuery, FacilitiesHotelRespose>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;
            public GetHotelFacilityQueryHandler(IApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;

            }
            public async Task<FacilitiesHotelRespose> Handle(GetAllHotelFacilityQuery request, CancellationToken cancellationToken)
            {
                var hotelfacilites = await _context.FacilitesHotel.Include(y=>y.facilities).ToListAsync();
                if (hotelfacilites == null)
                {
                    return new FacilitiesHotelRespose
                    {
                        Data = null,
                        StatusCode = 404,
                        Message = "No data found"
                    };
                }

                return new FacilitiesHotelRespose
                {
                    Data = _mapper.Map<List<FacilityHotelDto>>(hotelfacilites),
                    StatusCode = 200,
                    Message = "Data found"
                };
            }
        }
    }
}
