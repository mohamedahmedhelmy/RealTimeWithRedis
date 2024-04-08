using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealTimeServiceWithRedis.Models;
using RealTimeServiceWithRedis.Services;
using StackExchange.Redis;

namespace RealTimeServiceWithRedis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RedisController : ControllerBase
    {
        private readonly IMessageService _messageService;

        public RedisController(IMessageService messageService)
        {
            _messageService = messageService;
        }
        [HttpPost]
        public async Task<IActionResult> SendMessage(MessageModel message)
        {
            await _messageService.PublishMessageAsync(message);
            return Ok();
        }
    }
}
