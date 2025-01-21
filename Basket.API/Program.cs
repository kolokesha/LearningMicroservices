var builder = WebApplication.CreateBuilder(args);

//add services

var app = builder.Build();

// configure the http request pipeline

app.Run();