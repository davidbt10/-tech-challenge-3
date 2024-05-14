using EMB.Domain.Domain;
using EMB.Domain.Interfaces;
using EMB.Infrastructure.Context;

namespace EMB.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public UserRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<User> GetAll()
        {
            return _dbContext.Users;
        }

        public User? GetByCode(string code)
        {
            return _dbContext.Users.FirstOrDefault(x => x.UserCode.Equals(code.Trim()));
        }
    }
}
