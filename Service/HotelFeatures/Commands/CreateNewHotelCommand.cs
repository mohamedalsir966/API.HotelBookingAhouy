using AutoMapper;
using Domain.Entities;
using MediatR;
using Persistence.Repositories;
using Service.Dto;
using System.Threading;
using System.Threading.Tasks;

namespace Service.HotelFeatures.Commands
{
    public class CreateNewHotelCommand : IRequest<HotelResponse>
    {
        public string Name { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Rate { get; set; }
        public string ImageUrl { get; set; }
    }

    public class CreateNewHotelCommandHandler : IRequestHandler<CreateNewHotelCommand, HotelResponse>
    {
        private readonly IMapper _mapper;
        private readonly IHotelRepository _HotelRepository;
        public CreateNewHotelCommandHandler(IMapper mapper, IHotelRepository hotelrepository)
        {
            _mapper = mapper;
            _HotelRepository = hotelrepository;
        }
        public async Task<HotelResponse> Handle(CreateNewHotelCommand command, CancellationToken cancellationToken)
        {
            var hotel = _mapper.Map<Hotel>(command);
             await _HotelRepository.CreateNewHotelCommand(hotel);
            return new HotelResponse
            {
                Data = _mapper.Map<HotelDto>(hotel),
                StatusCode = 200,
                Message = "Data has been added"
            };
        }
    }


}
