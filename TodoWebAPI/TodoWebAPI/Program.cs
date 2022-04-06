using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TodoWebAPI.Data;
using TodoWebAPI.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TodoWebAPIContext>(options =>
    options.UseInMemoryDatabase(databaseName: "Todo"));
    //options.UseSqlServer(builder.Configuration.GetConnectionString("TodoWebAPIContext")));

// Add services to the container.
builder.Services.AddScoped<ITodoListService, TodoListService>();
builder.Services.AddScoped<ITodoTaskService, TodoTaskService>();

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
