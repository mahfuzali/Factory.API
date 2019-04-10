using Factory.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Factory.API.Services
{
    public interface ICustomersRepository
    {
        Task<IEnumerable<Customer>> GetCustomersAsync();

        Task<IEnumerable<Customer>> GetCustomersAsync(IEnumerable<int> customerIds);
        IEnumerable<Customer> GetCustomers();


        Task<Customer> GetCustomerAsync(int id);

        

        void AddCustomer(Customer customerToAdd);
        Task<bool> SaveChangesAsync();
    }
}
