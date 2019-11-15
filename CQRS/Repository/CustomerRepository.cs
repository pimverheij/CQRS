using CQRS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRS.Repository
{
    public interface ICustomerRepository
    {
        Task RegisterCustomerAsync(Customer customer);
    }

    public class CustomerRepository : ICustomerRepository
    {
        public Task RegisterCustomerAsync(Customer customer)
        {
            //Add customer to database
            return Task.CompletedTask;
        }
    }
}
