using Microsoft.EntityFrameworkCore;
using TodoWebAPI.Data;
using TodoWebAPI.Models;

namespace TodoWebAPI.Services
{
    public class TodoListService : ITodoListService
    {

        private readonly TodoWebAPIContext _context;
        public TodoListService(TodoWebAPIContext context)
        {
            _context = context;
        }
        public async Task<List<TodoList>> GetTodoLists()
        {
            var list = await _context.TodoList.Include(x => x.Task).ToListAsync();
            return list.Select(a => new TodoList()
            {
                Id = a.Id,
                Title = a.Title,
                Color = a.Color,
                Task = a.Task

            }).ToList();
        }

        public async Task<TodoList> GetTodoList(int id)
        {
            var list = await _context.TodoList.Where(x => x.Id == id).Include(x => x.Task).FirstAsync();

            return list;
            
        }
        public async Task<List<TodoTask>> GetTodoTasks(int id)
        {
            var list = await _context.TodoList.Where(x => x.Id == id)
                .Include(x => x.Task)
                .Select(x => x.Task).SingleAsync();

            return list;
        }
        public async Task<TodoList> UpdateList(int id, TodoList List)
        {
            var todo = _context.TodoList.First(a => a.Id == id);
            todo.Title = List.Title;
            todo.Color = List.Color;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException err)
            {
                throw err;
            }
            return List;
        }

        public async Task<TodoList> CreateList(TodoList List)
        {
            try
            {
                _context.Add(List);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException err)
            {
                throw err;
            }
            return List;
        }

        public async Task<TodoList> DeleteList(int id)
        {
            var todo = _context.TodoList.Find(id);
            try
            {
                _context.Remove(todo);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException err)
            {
                throw err;
            }
            return new TodoList()
            {
                Id = todo.Id,
                Title = todo.Title,
                Color = todo.Color,
                Task = todo.Task
            };
        }

    }
}
