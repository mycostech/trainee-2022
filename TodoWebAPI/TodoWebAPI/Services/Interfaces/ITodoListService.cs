using System.Collections.Generic;
using System.Threading.Tasks;
using TodoWebAPI.Models;

namespace TodoWebAPI.Services
{
    public interface ITodoListService
    {
        public Task<List<TodoList>> GetTodoLists();
        public Task<TodoList> GetTodoList(int id);
        public Task<List<TodoTask>> GetTodoTasks(int id);
        public Task<TodoList> UpdateList(int id, TodoList TodoList);
        public Task<TodoList> CreateList(TodoList TodoList);
        public Task<TodoList> DeleteList(int id);
    }
}



