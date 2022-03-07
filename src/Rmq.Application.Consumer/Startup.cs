using System;
using System.Reflection;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using Rmq.Application.Consumer.Commands;
using Rmq.Application.Consumer.Commands.Handlers;
using WorkingWithMongoDB.WebAPI.Configuration;
using WorkingWithMongoDB.WebAPI.Services;

namespace Rmq.Application.Consumer
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .Configure<DeveloperDatabaseConfiguration>(Configuration.GetSection("DeveloperDatabaseConfiguration"))
                .AddMediatR(Assembly.GetExecutingAssembly())
                .AddTransient<IRequestHandler<LogCommand, Unit>, LogCommandHandler>()
                .AddHostedService<LogConsumer>()
                .AddSingleton<CustomerService>()
                .AddSingleton(serviceProvider =>
                {
                    var uri = new Uri("amqp://guest:guest@localhost:5672/CUSTOM_HOST");
                    return new ConnectionFactory
                    {
                        Uri = uri,
                        DispatchConsumersAsync = true
                    };
                });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
        }
    }
}
