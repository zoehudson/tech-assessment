using CSharp.Models;
namespace CSharp.Services
{
    public interface IOrderService
    {
        Order GetOrder(int orderId);
        void UpdateOrder(Order updatedOrder);
        void CancelOrder(int orderId);
    }
}
