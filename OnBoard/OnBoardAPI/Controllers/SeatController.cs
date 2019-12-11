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


        [HttpGet("{seatNumber}")]
        public ActionResult<Seat> GetSeatInstance(int seatNumber)
        {
            return new OkObjectResult(_seatRepository.GetSeatInstanceWithSeatNumber(seatNumber));
        }

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