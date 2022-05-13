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

namespace Service.FacilityFeatures.Commands
{
    public class CreateHotelFacilityCommand: IRequest<FacilityHotelRespose>
    {
        public Guid HotelId { get; set; }
        public Guid Facilitiesid { get; set; }
        public class CreateHotelFacilityCommandHandler : IRequestHandler<CreateHotelFacilityCommand, FacilityHotelRespose>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;
            public CreateHotelFacilityCommandHandler(IApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<FacilityHotelRespose> Handle(CreateHotelFacilityCommand command, CancellationToken cancellationToken)
            {
                //get fasilty by id 
               // var QrmeResponseValueList =
               //await Processv2(command.facilitiesid);
                var any =  _context.Facilities.Where(a => a.Id == command.Facilitiesid).FirstOrDefault();

                var FacilitesHotel = new FacilitesHotel();
                FacilitesHotel.Id = new Guid();
                FacilitesHotel.hotelId = command.HotelId;
                FacilitesHotel.FacilitiesId = any.Id;
                //var hotel = _mapper.Map<FacilitesHotel>(command);

                _context.FacilitesHotel.Add(FacilitesHotel);
                await _context.SaveChangesAsync();


                return new FacilityHotelRespose
                {
                    Data = _mapper.Map<FacilityHotelDto>(FacilitesHotel),
                    StatusCode = 200,
                    Message = "Data has been added"
                };
            }

           
        }
    }
}

