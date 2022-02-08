using UnitTestingLegacyContext.Models;

namespace UnitTestingLegacyContext
{
    public class DbContextSimulator
    {
        public IList<User> Users { get;set; }

        public DbContextSimulator()
        {
            Users = new List<User>()
            { 
                new User() { Id = 1, Name = "Obi Van Kenobi"},
                new User() { Id = 2, Name = "Luke Skywalker"}
            };

        }
    }
}
