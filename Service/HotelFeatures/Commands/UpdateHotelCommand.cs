using AutoMapper;
using MediatR;
using Persistence.Repositories;
using Service.Dto;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Service.HotelFeatures.Commands
{
    public class UpdateHotelCommand :IRequest<HotelResponse>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Rate { get; set; }
        public string ImageUrl { get; set; }
    }
    public class UpdateHotelCommandHanelar : IRequestHandler<UpdateHotelCommand, HotelResponse>
    {
        private readonly IMapper _mapper;
        private readonly IHotelRepository _HotelRepository;
        public UpdateHotelCommandHanelar(IMapper mapper, IHotelRepository hotelRepository )
        {
            _mapper = mapper;
            _HotelRepository = hotelRepository;

        }
        public async Task<HotelResponse> Handle(UpdateHotelCommand command, CancellationToken cancellationToken)
        {
            var existinghotel = await _HotelRepository.GetHotelByIdQuery(command.Id);

            if (existinghotel.Id != Guid.Empty)
            {
                existinghotel.Name = command.Name;
                existinghotel.City = command.City;
                existinghotel.State = command.State;
                existinghotel.Description = command.Description;
                existinghotel.Price = command.Price;
                existinghotel.Rate = command.Rate;
                existinghotel.ModifiedOn = DateTime.UtcNow;

                var updatedhotel = await _HotelRepository.UpdateHotelByIdCommand(existinghotel);

                return new HotelResponse
                {
                    Data = _mapper.Map<HotelDto>(updatedhotel),
                    StatusCode = 200,
                    Message = "Data has been Updated"
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
