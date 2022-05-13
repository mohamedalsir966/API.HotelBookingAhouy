using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Persistence.Repositories;
using Service.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Service.HotelFeatures.Queries
{
    public class GetAllHotelQuery : IRequest<HotelsResponse>
    { }
    public class GetAllHotelQueryHandler : IRequestHandler<GetAllHotelQuery, HotelsResponse>
    {
        private readonly IMapper _mapper;
        private readonly IHotelRepository _hotelrepository;
        public GetAllHotelQueryHandler(IMapper mapper, IHotelRepository hotelrepository)
        {
            _mapper = mapper;
            _hotelrepository = hotelrepository;

        }
        public async Task<HotelsResponse> Handle(GetAllHotelQuery request, CancellationToken cancellationToken)
        {
            var hotels = await _hotelrepository.GetAllHotelsQuery();

            if (hotels == null)
            {
                return new HotelsResponse
                {
                    Data = null,
                    StatusCode = 404,
                    Message = "No data found"
                };
            }
            return new HotelsResponse
            {
                Data = _mapper.Map<List<HotelDto>>(hotels),
                StatusCode = 200,
                Message = "Data found"
            };
        }
    }


}

