using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealTimeServiceWithRedis.Models;
using StackExchange.Redis;

namespace RealTimeServiceWithRedis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RedisController : ControllerBase
    {
        private readonly IConnectionMultiplexer _connectionMultiplexer;
        private readonly IDatabase _redisDatabase;

        public RedisController(IConnectionMultiplexer connectionMultiplexer)
        {
            _connectionMultiplexer = connectionMultiplexer;
            _redisDatabase = _connectionMultiplexer.GetDatabase();
        }

        [HttpPost]
        public async Task<IActionResult> SendMessageToChannel(MessageModel message)
        {
            // Publish message to specified channel
            await _redisDatabase.PublishAsync(message.ReciverId, (RedisValue)message.Body);
            return Ok();
        }
    }
}
