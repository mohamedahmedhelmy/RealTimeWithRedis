using RealTimeServiceWithRedis.Models;
using StackExchange.Redis;
using System.Text.Json;

namespace RealTimeServiceWithRedis.Services
{
    public class RedisMessageService : IMessageService
    {
        private readonly IConnectionMultiplexer _redisConnection;

        public RedisMessageService(IConnectionMultiplexer redisConnection)
        {
            _redisConnection = redisConnection;
            //TODO input must come from user id
            SubscribeToChannels();
        }

        private void SubscribeToChannels()  //we need take channel from out side(message model)
        {
            var redisSubscriber = _redisConnection.GetSubscriber();
            redisSubscriber.Subscribe("user1", async (channel, message) =>
            {
                // Handle incoming message, e.g., send to SignalR clients
                await HandleIncomingMessageAsync(channel, message);
            });
        }
        //hub=>db=>channel=>ch userid==ch yes user connections loop clients.client(connection).sendmessage(message.body) 
        //
        private async Task HandleIncomingMessageAsync(string channel, RedisValue message)
        {
            // Handle the incoming message, e.g., send to SignalR clients
        }

        public async Task PublishMessageAsync(MessageModel message)
        {
            var channel = message.ReciverId;
            var body = JsonSerializer.Serialize(message.Body);

            var redis = _redisConnection.GetDatabase();
            await redis.PublishAsync(channel,body);
        }
    }
}
