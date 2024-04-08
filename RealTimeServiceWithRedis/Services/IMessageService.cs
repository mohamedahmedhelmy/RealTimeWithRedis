using RealTimeServiceWithRedis.Models;

namespace RealTimeServiceWithRedis.Services
{
    public interface IMessageService
    {
        Task PublishMessageAsync(MessageModel message);
    }
}
