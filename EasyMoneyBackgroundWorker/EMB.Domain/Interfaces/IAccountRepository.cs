using EMB.Domain.Domain;

namespace EMB.Domain.Interfaces
{
    public interface IAccountRepository
    {
        Account? GetByUserId(int userId);
        void Update(Account account);
    }
}
