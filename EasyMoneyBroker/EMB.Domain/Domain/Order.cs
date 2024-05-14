using EMB.Domain.Enun;

namespace EMB.Domain.OrderDomain
{
    public class Order
    {
        public Order() { }

        public Order(int accountId, int stockId, int quantity, decimal price)
        {
            AccountId = accountId;
            StockId = stockId;
            Quantity = quantity;
            Price = price;
            OperationDate = DateTime.UtcNow;
            CalculateTotalPrice();
            Status = StatusEnum.Pending;
            StatusDescription = PendingStatus;
            Validate();
        }

        public int Id { get; set; }
        public int AccountId { get;  set; }
        public int StockId { get;  set; }
        public int Quantity { get;  set; }
        public decimal Price { get;  set; }
        public decimal TotalPrice { get;  set; }
        public DateTime OperationDate { get;  set; }
        public StatusEnum Status { get;  set; }
        public string StatusDescription { get; set; }

        private void CalculateTotalPrice()
        {
            TotalPrice = Quantity * Price;
        }

        private string PendingStatus =>
            "Ordem pendente de processamento";

        private void Validate()
        {
            if (Quantity <= 0)
            {
                throw new ArgumentException("Quantidade precisa ser maior que zero.");
            }

            if (Price <= 0)
            {
                throw new ArgumentException("Preço unitário, precisa ser maior que zero.");
            }
        }
    }
}
