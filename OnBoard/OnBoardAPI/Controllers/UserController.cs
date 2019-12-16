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

        /// <summary>
        /// returns 200 with the users from your group
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet("passenerGroup/{userId}")]
        public ActionResult<IEnumerable<User>> GetCompanionGroups(int userId)
        {
            IEnumerable<User> users = _userRepository.GetUsersWithSameGroup(userId);
            return new OkObjectResult(users.ToList().Where(t => t.Id != userId));
        }

        /// <summary>
        /// Returns 200 with a given crewmember instance
        /// </summary>
        /// <param name="crewmemberId"></param>
        /// <returns></returns>
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