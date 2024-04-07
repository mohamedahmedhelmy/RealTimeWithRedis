using Microsoft.AspNetCore.SignalR;
using StackExchange.Redis;

namespace RealTimeServiceWithRedis.Hubs
{
    public class MainHub:Hub
    {
        private readonly IConnectionMultiplexer _connectionMultiplexer;
        private readonly IDatabase _redisDatabase;

        public MainHub(IConnectionMultiplexer connectionMultiplexer)
        {
            _connectionMultiplexer = connectionMultiplexer;
            _redisDatabase = _connectionMultiplexer.GetDatabase();
        }

        public async Task SendMessageToClient(string clientId, string message)
        {
            var sub = _connectionMultiplexer.GetSubscriber();
            await sub.SubscribeAsync(clientId, (clientId, message) =>
            {
                Console.Write(message); 
            });
            await Clients.Client(clientId).SendAsync("ReceiveMessage", message);

            // Publish message to client's Redis channel
        }

        public async Task SendMessageToGroup(string groupName, string message)
        {
            await Clients.Group(groupName).SendAsync("ReceiveMessage", message);

            // Publish message to group's Redis channel
            await _redisDatabase.PublishAsync(groupName, message);
        }
    }
}
