using Microsoft.EntityFrameworkCore;
using TodoWebAPI.Data;
using TodoWebAPI.Models;

namespace TodoWebAPI.Services
{
    public class TodoTaskService : ITodoTaskService
    {

        private readonly TodoWebAPIContext _context;
        public TodoTaskService(TodoWebAPIContext context)
        {
            _context = context;
        }
        
        public async Task<TodoTask> CreateTask(int listid, TodoTask Task)
        {
            Task.TodoListId = listid;
            try
            {
                _context.Add(Task);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException err)
            {
                throw err;
            }
            return Task;
        }

        public async Task<TodoTask> GetTodoTask(int id)
        {
            var task = await _context.TodoTask.FindAsync(id);

            return task;
        }

        public async Task<TodoTask> UpdateTask(int id, TodoTask Task)
        {
            var task = _context.TodoTask.First(a => a.Id == id);
            task.Title = Task.Title;
            task.Status = Task.Status;
            task.Description = Task.Description;
            task.DueDate = Task.DueDate;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException err)
            {
                throw err;
            }
            return Task;
        }

        public async Task<TodoTask> DeleteTask(int id)
        {
            var task = _context.TodoTask.Find(id);
            try
            {
                _context.Remove(task);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException err)
            {
                throw err;
            }
            return new TodoTask()
            {
                Id = task.Id,
                Title = task.Title,
                Status = task.Status,
                Description = task.Description,
                DueDate = task.DueDate,
                TodoListId = task.TodoListId,
            };
        }

    }
}
