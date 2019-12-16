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
    public class FlightController : ControllerBase
    {
        private readonly IFlightRepository _flightRepository;

        public FlightController(IFlightRepository flightRepository)
        {
            _flightRepository = flightRepository;
        }

        /// <summary>
        /// Get the current flight and return it with a status code of 200
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<Flight> GetCurrentFlight()
        {
            return new OkObjectResult(_flightRepository.GetCurrentFlight());
        }


    }
}