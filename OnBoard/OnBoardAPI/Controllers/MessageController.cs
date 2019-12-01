using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using OnBoardAPI.Data.Repositories;
using OnBoardAPI.Models;

namespace OnBoardAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public MessageController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet("{fetchingUserId}")]
        public ActionResult<IEnumerable<Message>> FetchMessages(int fetchingUserId)
        {
            return new OkObjectResult(_userRepository.GetUserMessages(fetchingUserId));
        }

        [HttpPost("sendMessage/{message}")]
        public ActionResult SendMessage(Message message)
        {
            try
            {
                _userRepository.StoreMessage(message);

            }
            catch (Exception e)
            {
                return BadRequest();
            }
            return Ok();
        }
    }
}