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

namespace Service.LookupFeaturs.Commands
{
    public class CreateFacilityCommand : IRequest<FacilityRespnse>
    {

        public string Name { get; set; }
        public class CreateFacilityCommandHandler : IRequestHandler<CreateFacilityCommand, FacilityRespnse>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;
            public CreateFacilityCommandHandler(IApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<FacilityRespnse> Handle(CreateFacilityCommand command, CancellationToken cancellationToken)
            {
                var facility = _mapper.Map<Facilities>(command);
                _context.Facilities.Add(facility);
                await _context.SaveChangesAsync();
                return new FacilityRespnse
                {
                    Data = _mapper.Map<FacilityDto>(facility),
                    StatusCode = 200,
                    Message = "Data has been added"
                };
               

            }
        }
    }
}

