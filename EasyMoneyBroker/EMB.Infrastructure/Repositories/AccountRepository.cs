using EMB.Domain.Domain;
using EMB.Domain.Interfaces;
using EMB.Infrastructure.Context;

namespace EMB.Infrastructure.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public AccountRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Account> GetAll()
        {
            return _dbContext.Accounts;
        }
    }
}
