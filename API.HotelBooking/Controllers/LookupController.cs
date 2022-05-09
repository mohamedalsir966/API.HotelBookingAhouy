using Microsoft.AspNetCore.Mvc;
using Service.LookupFeaturs.Commands;
using Service.LookupFeaturs.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.HotelBooking.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LookupController : BaseController
    {
        [HttpPost]
        [Route("/addfacility")]
        public async Task<IActionResult> AddFacility(CreateFacilityCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
        /// <summary>
        /// get hotel  by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("/getfacilityById")]
        public async Task<IActionResult> GetFacility(Guid id)
        {
            return Ok(await Mediator.Send(new GetFacilityByIdQuery { FacilityId = id }));
        }
        [HttpGet]
        [Route("/getallfacility")]
        public async Task<IActionResult> GetAllFacility()
        {
            return Ok(await Mediator.Send(new GetAllFacilityQuery() ));
        }
    }
}
