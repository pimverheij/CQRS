using CQRS.Models;
using CQRS.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRS.QueryHandlers
{
    public class GetCustomerByIdQueryHandler : IQueryHandler<GetCustomerByIdQuery, Customer>
    {
        public Task<Customer> HandleAsync(GetCustomerByIdQuery query)
        {
            //Get Customer with Dapper for example
            return Task.Run(() => new Customer
            {
                Id = query.Id,
                FirstName = "John",
                LastName = "Doe"
            });
        }
    }
}
