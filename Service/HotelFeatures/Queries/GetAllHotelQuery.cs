using AutoMapper;
using MediatR;
using Persistence.Repositories;
using Service.Cache;
using Service.Dto;
using Service.PaginationFilter;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Service.HotelFeatures.Queries
{
    public class GetAllHotelQuery : Pagination,IRequest<HotelsResponse>
    { }
    public class GetAllHotelQueryHandler : IRequestHandler<GetAllHotelQuery, HotelsResponse>
    {
        private readonly IMapper _mapper;
        private readonly IHotelRepository _hotelrepository;
        private readonly CacheService _cacheService;
        public GetAllHotelQueryHandler(IMapper mapper, IHotelRepository hotelrepository, CacheService cacheService)
        {
            _mapper = mapper;
            _hotelrepository = hotelrepository;
            _cacheService = cacheService;

        }
        public async Task<HotelsResponse> Handle(GetAllHotelQuery request, CancellationToken cancellationToken)
        {
            var cachedResponse = await _cacheService.GetCachedValue<HotelsResponse>(CachedEntity.Hotels, "1");

            if (cachedResponse != null)
            {
                return new HotelsResponse
                {
                    Data = _mapper.Map<List<HotelDto>>(cachedResponse),
                    StatusCode = 200,
                    Message = "Data found"
                };
            }

            var hotels = await _hotelrepository.GetAllHotelsQuery(request.PageNumber, request.PageSize);
            var tocash = _mapper.Map<List<HotelDto>>(hotels);

            await _cacheService.PutCacheValue(CachedEntity.Hotels, "1", tocash);


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

