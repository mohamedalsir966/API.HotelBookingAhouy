﻿using AutoMapper;
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
    public class GetAllHotelQuery : IRequest<HotelsResponse>
    {
        public class GetAllHotelQueryHandler : IRequestHandler<GetAllHotelQuery, HotelsResponse>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;
            public GetAllHotelQueryHandler(IApplicationDbContext context,IMapper mapper)
            {
                _context = context;
                _mapper = mapper;

            }
            public async Task<HotelsResponse> Handle(GetAllHotelQuery request, CancellationToken cancellationToken)
            {
                var hotels = await _context.Hotel.Include(a => a.FacilitesHotel).ThenInclude(y=>y.facilities).AsNoTracking().ToListAsync();
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

}

