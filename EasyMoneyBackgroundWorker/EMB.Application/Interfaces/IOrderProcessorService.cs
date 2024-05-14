namespace EMB.Application.Interfaces
{
    public interface IOrderProcessorService
    {
        void ProcessPurchaseOrders(string message);
    }
}
