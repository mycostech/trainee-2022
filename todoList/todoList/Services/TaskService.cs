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
using todoAPI.Services;

namespace todoAPI.Services
{

    public class TaskService : ITaskService
    {
        private readonly todoListContext _context;

        public TaskService(todoListContext context)
        {
            _context = context;
        }


        public async Task<Model.Task> GetTask(int id)
        {
            var task = await _context.Task.FindAsync(id);

            if (task == null)
            {
                return null;
            }

            return task;
        }

        public async Task<Model.Task> UpdateTask(int id, Model.Task task)
        {
            var taskTodo = await _context.Task.FindAsync(id);
            taskTodo.start_date = task.start_date;
            taskTodo.complete_date = task.complete_date;
            taskTodo.due_date = task.due_date;
            taskTodo.status = task.status;
            taskTodo.Name = task.Name;
            taskTodo.t_description = task.t_description;

            _context.Entry(taskTodo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaskExists(id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }

            return task;
        }


        public async Task<Model.Task> CreateTask(int todo_id, Model.Task task)
        {
            task.TodoListId = todo_id;
            try
            {
                _context.Task.Add(task);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException err)
            {
                throw err;
            }



            return task;
        }


        public async Task<Model.Task> DeleteTask(int id)
        {
            var task = await _context.Task.FindAsync(id);
            if (task == null)
            {
                return null;
            }

            _context.Task.Remove(task);
            await _context.SaveChangesAsync();

            return task;
        }

        private bool TaskExists(int id)
        {
            return _context.Task.Any(e => e.Id == id);
        }
    }
}
