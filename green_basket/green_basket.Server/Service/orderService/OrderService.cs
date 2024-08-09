using green_basket.Server.Entities;
using green_basket.Server.Repository.order;
using System.ComponentModel;

namespace green_basket.Server.Service.orderService
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task<List<Orders>> GetAllOrders() => await _orderRepository.GetAllOrders();
        public async Task<bool> InsertOrder(Orders orders) => await _orderRepository.InsertOrder(orders);
        public async  Task<bool> UpdateOrder(Orders o) => await _orderRepository.UpdateOrder(o);
        public async Task<bool> DeleteOrder(int Order_id) => await _orderRepository.DeleteOrder(Order_id);
    }
}