using todoAPI.Model;

namespace todoAPI.Services
{
    public interface ITodoService
    {
        public Task<List<TodoList>> GetTodoList();
        public Task<TodoList> GetTodoItem(int id);
        public Task<List<Model.Task>> GetTasks(int id);
        public Task<TodoList> UpdateTodoItem(int id, TodoList todoList);
        public Task<TodoList> CreateTodoItem(TodoList todoList);
        public Task<TodoList> DeleteTodoItem(int id);
        public Task<TodoList> ModifyTodoItem(int id, bool is_comp);

    }
}
