using Ordering.Api;
using Ordering.Application;
using Ordering.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddApplicationServices();
builder.Services.AddInfrasturctureServices(builder.Configuration);
builder.Services.AddApiServices();

var app = builder.Build();

// Configure the Http request pipeline

app.Run();