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
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public ActionResult<Seat> GetUserInstance()
        {
            Seat seat = _userRepository.GetUserInstanceForAppliction(GlobalVariables.loggedInCounter);
            GlobalVariables.IncrementLoggedCount();
            return new OkObjectResult(seat);
        }
    }
}