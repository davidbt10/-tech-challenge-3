using EMB.Domain.Domain;
using EMB.Domain.Interfaces;
using EMB.Infrastructure.Context;

namespace EMB.Infrastructure.Repositories
{
    public class StockRepository : IStockRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public StockRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Stock> GetAll()
        {
            return _dbContext.Stocks;
        }

        public Stock? GetByCode(string code)
        {
            return _dbContext.Stocks.FirstOrDefault(x => x.Name.Equals(code.Trim()));
        }
    }
}
