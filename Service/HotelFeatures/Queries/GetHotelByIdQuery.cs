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
    public class GetHotelByIdQuery : IRequest<HotelResponse>
    {
        public Guid Id { get; }
        public GetHotelByIdQuery(Guid id)
        {
            Id = id;
        }
    }

    public class GetHotelByIdQueryHandler : IRequestHandler<GetHotelByIdQuery, HotelResponse>
    {
        private readonly IMapper _mapper;
        private readonly IHotelRepository _HotelRepository;
        public GetHotelByIdQueryHandler(IMapper mapper, IHotelRepository hotelrepository)
        {
            _mapper = mapper;
            _HotelRepository = hotelrepository;
        }
        public async Task<HotelResponse> Handle(GetHotelByIdQuery request, CancellationToken cancellationToken)
        {
            var hotel = await _HotelRepository.GetHotelByIdQuery(request.Id);

            if (hotel == null)
            {
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

