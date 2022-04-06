#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using todoAPI.Data;
using todoAPI.Model;

namespace todoAPI.Services
{
    public class TodoListService : ITodoService
    {
        private readonly todoListContext _context;

        public TodoListService(todoListContext context)
        {
            _context = context;
        }

        public async Task<List<TodoList>> GetTodoList()
        {
            return await _context.TodoList.ToListAsync();
        }

        public async Task<TodoList> GetTodoItem(int id)
        {
            if (!TodoItemExists(id))
            {
                return null;
            }
            //var todoItem = await _context.TodoList.FindAsync(id);
            return await _context.TodoList.Where(x => x.Id == id).Include(x => x.Tasks).FirstAsync();

        }
 


        public async Task<List<Model.Task>> GetTasks(int id)
        {
            //var todoList = _context.TodoList.Join(_context.Task, 
            //    todoList => todoList.Id, 
            //    task => task.TodoListId, 
            //    (todoList, task) => new 
            //    { task }).
            //    Where(a => a.task.TodoListId == id);
            
            return _context.Task.Where(predicate: u => u.TodoListId == id).ToList(); 
        }

        public async Task<TodoList>  UpdateTodoItem(int id, TodoList todoList)
        {
            var todo = await _context.TodoList.FindAsync(id);

            //
            todo.name = todoList.name;
            todo.is_complete = todoList.is_complete;
            todo.td_description = todoList.td_description;
            _context.Entry(todo).State = EntityState.Modified;
            //_context.Update(todo);
            //_context.SaveChanges();
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TodoItemExists(id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }
            return todoList;
        }

        public async Task<TodoList> CreateTodoItem(TodoList todoList)
        {
            _context.TodoList.Add(todoList);
            await _context.SaveChangesAsync();
            
            return todoList;
        }
        public async Task<TodoList> DeleteTodoItem(int id)
        {
            var todoItem = await _context.TodoList.FindAsync(id);
            _context.TodoList.Remove(todoItem);
            await _context.SaveChangesAsync();

            return todoItem;
        }
 
        public async Task<TodoList> ModifyTodoItem(int id, bool is_comp)
        {
            var todoItem = await _context.TodoList.FindAsync(id);
            

         
            todoItem.is_complete = is_comp;

            _context.Update(todoItem);
            _context.SaveChanges();

            return todoItem;
        }

        private bool TodoItemExists(int id)
        {
            return _context.TodoList.Any(e => e.Id == id);
        }
    }
}
