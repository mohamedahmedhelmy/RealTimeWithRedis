using RealTimeServiceWithRedis.Models;

namespace RealTimeServiceWithRedis
{
    public class ClientRepository
    {
        public static Dictionary<string, UserModel> Data = new Dictionary<string, UserModel>()
        {
            { "John", new UserModel { UserId = "John", connectionIds =new List<string>{"abc123"}, groups = new List<string>{"Group1","Group2"} } },
            { "Alice", new UserModel { UserId = "Alice", connectionIds = new List<string>{"abc456"}, groups =new List<string>{"Group1","Group3"}} },
            { "Bob", new UserModel { UserId = "Bob", connectionIds =new List<string>{"abc678"}, groups = new List<string>{"Group2","Group3"} } }
        };
    }
}
