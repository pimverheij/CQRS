using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CQRS.CommandHandlers;
using CQRS.Commands;
using CQRS.Models;
using CQRS.Queries;
using CQRS.QueryHandlers;
using CQRS.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace CQRS
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ICommandExecutor, CommandExecutor>();
            services.AddScoped<IQueryExecutor, QueryExecutor>();
            services.AddScoped<ICommandHandler<RegisterCustomerCommand>, RegisterCustomerCommandHandler>();
            services.AddScoped<IQueryHandler<GetCustomerByIdQuery, Customer>, GetCustomerByIdQueryHandler>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
