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

        [HttpGet("passenerGroup/{userId}")]
        public ActionResult<IEnumerable<User>> GetCompanionGroups(int userId)
        {
            IEnumerable<User> users = _userRepository.GetUsersWithSameGroup(userId);
            return new OkObjectResult(users.ToList().Where(t => t.Id != userId));
        }

        [HttpGet("crewmember/{crewmemberId}")]
        public ActionResult<CrewMember> GetCrewMemberInstance(int crewmemberId)
        {
            User c = _userRepository.GetCrewMemberInstance(crewmemberId);
            if(c == null)
            {
                return BadRequest();
            }
            return new OkObjectResult(c);
        }
    }
}