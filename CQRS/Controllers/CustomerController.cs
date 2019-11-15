using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CQRS.CommandHandlers;
using CQRS.Commands;
using CQRS.Models;
using CQRS.Queries;
using CQRS.QueryHandlers;
using Microsoft.AspNetCore.Mvc;

namespace CQRS.Controllers
{
    [Route("api/[controller]")]
    public class CustomerController : Controller
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IQueryExecutor queryExecutor;

        public CustomerController(ICommandExecutor commandExecutor, IQueryExecutor queryExecutor)
        {
            this.commandExecutor = commandExecutor;
            this.queryExecutor = queryExecutor;
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterCustomerCommand command)
        {
            await commandExecutor.Execute(command);
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomerById([FromQuery] int id)
        {
            var query = new GetCustomerByIdQuery(id);
            return Ok(await queryExecutor.Execute(query));
        }
    }
}