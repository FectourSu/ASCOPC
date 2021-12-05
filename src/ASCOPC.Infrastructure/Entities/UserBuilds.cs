using ASCOPC.Domain.Entities;
using ASCOPC.Infrastructure.Data.Entities;

namespace ASCOPC.Infrastructure.Entities
{
    public class UserBuilds
    {
        public UserBuilds()
        {
        }

        public UserBuilds(User user, Builds build)
        {
            User = user;
            UserId = user.Id;

            Build = build;
            BuildId = build.Id;
        }

        public string UserId { get; set; }
        public User User { get; set; }
        public int BuildId { get; set; }
        public Builds Build { get; set; }
    }
}
