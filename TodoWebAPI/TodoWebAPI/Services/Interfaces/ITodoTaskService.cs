using System.Collections.Generic;
using System.Threading.Tasks;
using TodoWebAPI.Models;

namespace TodoWebAPI.Services
{
    public interface ITodoTaskService
    {

        public Task<TodoTask> CreateTask(int listid, TodoTask TodoTask);

        public Task<TodoTask> GetTodoTask(int id);
        public Task<TodoTask> UpdateTask(int id, TodoTask TodoTask);
        public Task<TodoTask> DeleteTask(int id);
    }
}



