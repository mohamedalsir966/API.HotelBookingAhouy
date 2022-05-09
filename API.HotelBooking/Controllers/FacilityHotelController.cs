using Microsoft.AspNetCore.Mvc;
using Service.FacilityFeatures.Commands;
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
       
        public async Task<IActionResult> AddHotelFacility(CreateHotelFacilityCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

    }



}
