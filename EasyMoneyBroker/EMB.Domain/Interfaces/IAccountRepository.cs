using EMB.Domain.Domain;

namespace EMB.Domain.Interfaces
{
    public interface IAccountRepository
    {
        IEnumerable<Account> GetAll();
    }
}
