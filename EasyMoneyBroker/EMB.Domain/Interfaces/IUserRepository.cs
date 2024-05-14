using EMB.Domain.Domain;

namespace EMB.Domain.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();
        User? GetByCode(string code);
    }
}
