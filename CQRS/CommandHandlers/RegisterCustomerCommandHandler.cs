using CQRS.Commands;
using CQRS.Models;
using CQRS.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRS.CommandHandlers
{
    public class RegisterCustomerCommandHandler : ICommandHandler<RegisterCustomerCommand>
    {
        private readonly ICustomerRepository customerRepository;

        public RegisterCustomerCommandHandler(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public Task HandleAsync(RegisterCustomerCommand command)
        {
            var customer = new Customer
            {
                FirstName = command.FirstName,
                LastName = command.LastName
            };

            return customerRepository.RegisterCustomerAsync(customer);
        }
    }
}
