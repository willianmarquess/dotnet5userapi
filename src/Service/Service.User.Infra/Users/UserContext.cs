using Service.Infra.Shared;

namespace Service.Infra.Users
{
    public class UserContext : RavenContext
    {
        public UserContext()
        {
            CreateUserContextIndexes();
        }

        private static void CreateUserContextIndexes()
        {

        }
    }
}
