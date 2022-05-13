﻿using AutoMapper;
using MediatR;
using Persistence;
using Persistence.Repositories;
using Service.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Service.HotelFeatures.Commands
{
    public class DeleteHotelByIdCommand : IRequest<HotelResponse>
    {
        public DeleteHotelByIdCommand(Guid id)
        {
            hotelId = id;
        }

        public Guid hotelId { get;  }
    }

    public class DeleteHotelByIdCommandHandler : IRequestHandler<DeleteHotelByIdCommand, HotelResponse>
    {
        private readonly IMapper _mapper;
        private readonly IHotelRepository _HotelRepository;
        public DeleteHotelByIdCommandHandler(IMapper mapper, IHotelRepository hotelrepository)
        {
            _mapper = mapper;
            _HotelRepository = hotelrepository;
        }
        public async Task<HotelResponse> Handle(DeleteHotelByIdCommand request, CancellationToken cancellationToken)
        {
            var hotel = await _HotelRepository.GetHotelByIdQuery(request.hotelId);
            if (hotel.Id != Guid.Empty)
            {
                var deletedhotel = await _HotelRepository.DeleteHotelByIdCommand(hotel);

                return new HotelResponse
                {
                    Data = _mapper.Map<HotelDto>(deletedhotel),
                    StatusCode = 200,
                    Message = "Data has been Deleted"
                };
            }
            else
            {
                return new HotelResponse
                {
                    Data = null,
                    StatusCode = 404,
                    Message = "No data found"
                };
            }
           
        }
    }

}
