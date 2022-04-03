using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using todoapp_api.Data;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<todoapp_apiContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("todoapp_apiContext")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
