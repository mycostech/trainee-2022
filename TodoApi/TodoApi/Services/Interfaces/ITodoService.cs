using TodoApi.Models;

namespace TodoApi.Services.Interfaces
{
    public interface ITodoService
    {
        public Task<List<TodoItem>> GetTodoItems();
        public Task<TodoItem> GetTodoItem(int id);
        public Task<TodoItem> UpdateItem(int id, TodoItem newItem);
        public Task<TodoItem> CreateItem(TodoItem newItem);
        public Task<TodoItem> DeleteItem(int id);
    }
}
