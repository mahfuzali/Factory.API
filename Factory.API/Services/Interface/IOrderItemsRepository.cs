using Factory.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Factory.API.Services.Interface
{
    public interface IOrderItemsRepository
    {
        Task<IEnumerable<OrderItem>> GetOrderItemsAsync();

        Task<OrderItem> GetOrderItemAsync(int id);

        void AddOrderItem(OrderItem orderToAdd);

        void DeleteOrderItem(OrderItem orderToDelete);

        Task<OrderItem> CheckOrderItemExists(OrderItem customerToAdd);

        Task<bool> SaveChangesAsync();
    }
}
