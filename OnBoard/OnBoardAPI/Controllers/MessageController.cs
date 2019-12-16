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

        /// <summary>
        /// Get all messages from the user
        /// </summary>
        /// <param name="fetchingUserId"></param>
        /// <returns></returns>
        [HttpGet("{fetchingUserId}")]
        public ActionResult<IEnumerable<Message>> FetchMessages(int fetchingUserId)
        {
            var list = _userRepository.GetUserMessages(fetchingUserId);
            return new OkObjectResult(_userRepository.GetUserMessages(fetchingUserId));
        }

        /// <summary>
        /// Stores a messge to given user embedded in message,
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
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