using Service.Infra.Shared;

namespace Service.Infra.Users
{
    public class UserContext : RavenContext
    {
        public UserContext() : base()
        {
            CreateUserContextIndexes();
        }

        private static void CreateUserContextIndexes()
        {

        }
    }
}
