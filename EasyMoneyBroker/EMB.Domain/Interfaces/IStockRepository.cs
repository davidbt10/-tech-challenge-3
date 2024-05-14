using EMB.Domain.Domain;

namespace EMB.Domain.Interfaces
{
    public interface IStockRepository
    {
        IEnumerable<Stock> GetAll();
        Stock GetByCode(string code);
    }
}
