using EMB.Domain.Domain;
using EMB.Domain.Interfaces;
using EMB.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EMB.Infrastructure.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private ApplicationDbContext _dbContext;

        public AccountRepository(IConfiguration configuration)
        {
            DbContextOptionsBuilder<ApplicationDbContext> optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("defaultConnection"));
            _dbContext = new ApplicationDbContext(optionsBuilder.Options);
        }

        public Account? GetByUserId(int userId)
        {
            return _dbContext.Accounts.FirstOrDefault(x => x.UserID == userId);
        }

        public void Update(Account account)
        {
            _dbContext.Accounts.Attach(account);
            _dbContext.SaveChanges();
        }
    }
}
