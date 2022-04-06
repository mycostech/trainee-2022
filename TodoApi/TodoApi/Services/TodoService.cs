using Microsoft.EntityFrameworkCore;
using System.Linq;
using TodoApi.Models;
using TodoApi.Services.Interfaces;

namespace TodoApi.Services
{
    public class TodoService : ITodoService
    {
        private readonly TodoContext _context;

        public TodoService (TodoContext context)
        {
            _context = context;
        }

        public async Task<TodoItem> CreateItem(TodoItem newItem)
        {
            var item = new TodoItem
            {
                Name = newItem.Name,
                Description = newItem.Description,
                StartDate = newItem.StartDate,
                EndDate = newItem.EndDate,
                IsComplete = newItem.IsComplete,
            };
            try
            {
                _context.Add(item);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException err)
            {
                throw err;
            }

            return item;
        }

        public async Task<TodoItem> DeleteItem(int id)
        {
            var item = _context.TodoItems.Find(id);
            //var temp = new TodoItem
            //{
            //    Name = item.Name,
            //    Description = item.Description,
            //    StartDate=item.StartDate,
            //    EndDate = item.EndDate,
            //    IsComplete = item.IsComplete,
            //};
            try
            {
                _context.Remove(item);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException err)
            {
                throw err;
            }
            return new TodoItem()
            {
                Id = id,
                Name = item.Name,
                StartDate = item.StartDate, 
                EndDate=item.EndDate,
                IsComplete=item.IsComplete,
            };
        }

        public async Task<TodoItem> GetTodoItem(int id)
        {
            var todoItem = await _context.TodoItems.FindAsync(id);
            if(todoItem == null)
            {
                return null;
            }

            return new TodoItem() {
                Id = id,
                Name = todoItem.Name,
                StartDate = todoItem.StartDate,
                EndDate = todoItem.EndDate,
                IsComplete = todoItem.IsComplete,
            };
        }

        public async Task<List<TodoItem>> GetTodoItems()
        {
            var list = await _context.TodoItems.ToListAsync();
            //IEnumerable<TodoItem> itemQuery = from 
            return list;
        }

        public async Task<TodoItem> UpdateItem(int id, TodoItem newItem)
        {
            var item = _context.TodoItems.First(i => i.Id == id);
            //if (item == null) return null; 
            Console.WriteLine(item);
            newItem.Id = id;
            item.Name = newItem.Name;
            item.StartDate = newItem.StartDate;
            item.EndDate = newItem.EndDate;
            item.IsComplete = newItem.IsComplete;
            //item.Steps = newItem.Steps;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException err)
            {
                throw err;
            }
            return newItem;
        }
    }
}
