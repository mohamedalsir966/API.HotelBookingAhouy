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

namespace Service.LookupFeaturs.Queries
{
    public class GetAllFacilityQuery : IRequest<FacilitesRespnse>
    {
        public class GetAllFacilityQueryHandler : IRequestHandler<GetAllFacilityQuery, FacilitesRespnse>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;
            public GetAllFacilityQueryHandler(IApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<FacilitesRespnse> Handle(GetAllFacilityQuery request, CancellationToken cancellationToken)
            {
                var facilltys = await _context.Facilities.ToListAsync();
                if (facilltys == null)
                {
                    return new FacilitesRespnse
                    {
                        Data = null,
                        StatusCode = 404,
                        Message = "No data found"
                    };
                }

                return new FacilitesRespnse
                {
                    Data = _mapper.Map<List<FacilityDto>>(facilltys),
                    StatusCode = 200,
                    Message = "Data found"
                };
            }
        }

    }
}
