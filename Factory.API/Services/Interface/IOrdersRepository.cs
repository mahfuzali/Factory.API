using Factory.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Factory.API.Services.Interface
{
    public interface IOrdersRepository
    {
        Task<IEnumerable<Order>> GetOrdersAsync();
        Task<Order> GetOrderAsync(int id);
    }
}
