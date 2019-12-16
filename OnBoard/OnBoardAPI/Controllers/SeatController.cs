using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnBoardAPI.Data.Repositories;
using OnBoardAPI.Models;

namespace OnBoardAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeatController : ControllerBase
    {

        private readonly ISeatRepository _seatRepository;

        public SeatController(ISeatRepository seatRepository)
        {
            _seatRepository = seatRepository;
        }

        /// <summary>
        /// Returns a seat with receiver seatnr, returns 200 code with it
        /// </summary>
        /// <param name="seatNumber"></param>
        /// <returns></returns>
        [HttpGet("{seatNumber}")]
        public ActionResult<Seat> GetSeatInstance(int seatNumber)
        {
            Seat s = _seatRepository.GetSeatInstanceWithSeatNumber(seatNumber);
            if(s == null)
            {
                return BadRequest();
            }
            return new OkObjectResult(s);
        }

        /// <summary>
        /// Returns 200 if the swap of users is possible
        /// </summary>
        /// <param name="seatNrOne"></param>
        /// <param name="seatNrTwo"></param>
        /// <returns></returns>
        [HttpPut("switchSeats/{seatNrOne}/{seatNrTwo}")]
        public ActionResult SwitchSeats(int seatNrOne, int seatNrTwo)
        {
            try
            {
                Seat seatInstanceOne = _seatRepository.GetSeatInstanceWithSeatNumber(seatNrOne);
                Seat seatInstanceTwo = _seatRepository.GetSeatInstanceWithSeatNumber(seatNrTwo);
                User bufferUser = seatInstanceOne.User;
                seatInstanceOne.User = seatInstanceTwo.User;
                seatInstanceTwo.User = bufferUser;
                _seatRepository.SwitchUsersFromSeats(seatInstanceOne, seatInstanceTwo);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
            return Ok();
        }

    }
}