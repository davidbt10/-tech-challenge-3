using EMB.Domain.Enum;

namespace EMB.Domain.OrderDomain
{
    public class Order
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public int StockId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime OperationDate { get; set; }
        public StatusEnum Status { get; set; }
        public string StatusDescription { get; set; }
    }
}
