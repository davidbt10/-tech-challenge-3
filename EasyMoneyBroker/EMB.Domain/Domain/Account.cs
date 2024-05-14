namespace EMB.Domain.Domain
{
    public class Account
    {
        public int AccountID { get; set; }
        public int UserID { get; set; }
        public decimal Balance { get; set; }
        public bool Active { get; set; }
    }
}
