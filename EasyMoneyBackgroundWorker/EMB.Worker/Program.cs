using EMB.Application.Interfaces;
using EMB.Application.Services;
using EMB.Domain.Interfaces;
using EMB.Infrastructure.Context;
using EMB.Infrastructure.Repositories;
using EMB.Worker;
using EMB.Worker.Providers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddSingleton<RabbitMQClient>(new RabbitMQClient(builder.Configuration.GetConnectionString("rabbitMQ")));

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("defaultConnection")));


builder.Services.AddSingleton<IConfiguration>(builder.Configuration);
builder.Services.AddHostedService<Worker>();

builder.Services.AddTransient<IOrderProcessorService, OrderProcessorService>();
builder.Services.AddTransient<IAccountRepository, AccountRepository>();
builder.Services.AddTransient<IOrderRepository, OrderRepository>();

var host = builder.Build();
host.Run();
