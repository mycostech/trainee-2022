using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using todoAPI.Data;
using todoAPI.Services;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<todoListContext>(options =>
    options.UseInMemoryDatabase(databaseName: "todolist")
    //options.UseSqlServer(builder.Configuration.GetConnectionString("todoListContext"))
);

// Add services to the container.
builder.Services.AddScoped<ITodoService, TodoListService>();
builder.Services.AddScoped<ITaskService, TaskService>();
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
