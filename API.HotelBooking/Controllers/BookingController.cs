using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Service.BookingFeatures.Commands;
using Service.BookingFeatures.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.HotelBooking.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookingController : BaseController
    {
        /// <summary>
        /// Creates a New Booking.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create(CreateBookingCommand command, Guid hotelId)
        {
            if (hotelId == Guid.Empty)
            {
                return BadRequest();
            }
            else
            {
                command.HotelId = hotelId;
                return Ok(await Mediator.Send(command));
            }
        }
        /// <summary>
        /// list of bookings
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllBookingQuery()));
        }
    }
}
