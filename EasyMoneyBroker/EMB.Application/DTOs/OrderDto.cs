namespace EMB.Application.DTOs
{
    public class OrderDto
    {
        public string Ticker { get; set; }
        public int Quantity { get; set; }
        public decimal PricePerUnit { get; set; }
        public string ClientId { get; set; }

        public void Validate()
        {
            if (string.IsNullOrEmpty(Ticker))
            {
                throw new ArgumentException("Ticker não pode ser vazio.");
            }

            if (Quantity <= 0)
            {
                throw new ArgumentException("Quantidade precisa ser maior que zero.");
            }

            if (PricePerUnit <= 0)
            {
                throw new ArgumentException("Preço unitário, precisa ser maior que zero.");
            }

            if (string.IsNullOrEmpty(ClientId))
            {
                throw new ArgumentException("Código do cliente não pode ser vazio.");
            }
        }
    }
}
