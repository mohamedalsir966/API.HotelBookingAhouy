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
    public class GetFacilityByIdQuery : IRequest<FacilityRespnse>
    {
        public Guid FacilityId { get; set; }

        public class GetFacilityByIdQueryHandler : IRequestHandler<GetFacilityByIdQuery, FacilityRespnse>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;
            public GetFacilityByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<FacilityRespnse> Handle(GetFacilityByIdQuery request, CancellationToken cancellationToken)
            {
                var facillty = await _context.Facilities.Where(a => a.Id == request.FacilityId).FirstOrDefaultAsync();
                if (facillty == null)
                {
                    return new FacilityRespnse
                    {
                        Data = null,
                        StatusCode = 404,
                        Message = "No data found"
                    };
                }

                return new FacilityRespnse
                {
                    Data = _mapper.Map<FacilityDto>(facillty),
                    StatusCode = 200,
                    Message = "Data found"
                };
            }
        }

    }
}
