using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestingLegacyContext.Models;

namespace UnitTestingLegacyContext.SomeNewFunctionality
{
    public class DataOperations
    {
        private readonly ContextService _contextService;

        public DataOperations() : this(new ContextService())
        {

        }

        public DataOperations(ContextService contextServiceWrapper)
        {
            _contextService = contextServiceWrapper;
        }

        public int AddNewUser(string userName)
        {
            return _contextService.AddUser(userName);
        }

        public User GetUser(int id)
        {
            return _contextService.GetUserByID(id);
        }
    }

    //this class will be used for unit-testing
    //methods should be marked as virtual
    public class ContextService
    {
        private DbContextSimulator ctx = new DbContextSimulator();
        public virtual int AddUser(string name)
        {
            var user = new User { Id = ctx.Users.Count + 1, Name = name };
            ctx.Users.Add(user);
            return user.Id;
        }

        public virtual User GetUserByID(int id)
        {
            return ctx.Users.FirstOrDefault(x => x.Id == id);
        }
    }
}
