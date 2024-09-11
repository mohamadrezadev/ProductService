using Application.DependencyInjections;
using Application.Middlewares;
using Endpoint.Api;
using Endpoint.Api.Dependencies;
using Infrastructure.Dependencies;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services
    .AddApplication()
    .AddInfrastructure(builder.Configuration)
    .AddServices(builder.Configuration);


var app = builder.Build();
await StartupTasks.Init(app, builder.Configuration);

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseHsts();
app.UseMiddleware<ExceptionHandler>();
app.MapControllers();
app.MapSwagger ();


app.Run();
