using Microsoft.AspNetCore.Mvc;
using Service.FacilityFeatures.Commands;
using Service.FacilityFeatures.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.HotelBooking.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FacilityHotelController : BaseController
    {
        /// <summary>
        /// for adding new hotel
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>

        [HttpPost]
        [Route("/Addhotelfacility")]
        public async Task<IActionResult> AddHotelFacility(CreateHotelFacilityCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpGet]
        [Route("/getallhotelfacility")]
        public async Task<IActionResult> GetALlHotelFacility()
        {
            return Ok(await Mediator.Send(new GetAllHotelFacilityQuery()));
        }

    }



}
