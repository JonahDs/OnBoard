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

    }
}