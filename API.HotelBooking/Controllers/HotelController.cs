using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Service.HotelFeatures.Commands;
using Service.HotelFeatures.Queries;

namespace API.HotelBooking.Controllers
{
   [ApiController]
   [Route("[controller]")]
    
    public class HotelController : BaseController
    {
        /// <summary>
        /// for adding new hotel
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>

        [HttpPost]
        public async Task<IActionResult> Create(CreateNewHotelCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
        /// <summary>
        /// SearchByName.
        /// </summary>
        /// <param name="hotilname"></param>
        /// <returns></returns>
        /// 


        [HttpGet]
        [Route("SearchByName")]
        public async Task<IActionResult> GetHotilByName(string hotilname)
        {
            return Ok(await Mediator.Send(new SearchHotelQuery {HotelName= hotilname }));
        }
        /// <summary>
        /// get hotel  by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            return Ok(await Mediator.Send(new GetHotelByIdQuery { hotelId = id }));
        }
        /// <summary>
        /// list of hotels
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllHotelQuery()));
        }

       
        /// <summary>
        /// delte hotel  by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Ok(await Mediator.Send(new DeleteHotelByIdCommand { hotelId = id }));
        }
       
    }
}
