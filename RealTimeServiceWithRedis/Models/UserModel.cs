namespace RealTimeServiceWithRedis.Models
{
    public class UserModel
    {
        public string UserId { get; set; } = null!;

        public IList<string> connectionIds = new List<string>();

        public IList<string> groups = new List<string>();
    }
}
