using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
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
            var qurey = new SearchHotelQuery(hotilname);
            var result = await Mediator.Send(qurey);
            return Ok(result);
        }
        /// <summary>
        /// get hotel  by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var qurey = new GetHotelByIdQuery(id);
            var result = await Mediator.Send(qurey);
            return Ok(result);
        }
        /// <summary>
        /// list of hotels
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAll()
        {
            var qurey = new GetAllHotelQuery();
            var result = await Mediator.Send(qurey);
            return Ok(result);
        }
       
        /// <summary>
        /// delte hotel  by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
           
            var qurey = new DeleteHotelByIdCommand(id);
            var result = await Mediator.Send(qurey);
            return Ok(result);
        }
        /// <summary>
        /// Updates the  Entity based on Id.   
        /// </summary>
        /// <param name="id"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        /// 
        [HttpPut]
        public async Task<IActionResult> Update(UpdateHotelCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

    }
}
