using todoapp_api.Data;
using todoapp_api.Models;
using todoapp_api.Services.Interfaces;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using todoapp_api.Utils;

namespace todoapp_api.Services
{
    public class TaskService : ITaskService
    {
        private readonly todoapp_apiContext _context;
        private readonly ILogger _logger;

        public TaskService(todoapp_apiContext context, ILogger<ITaskService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public List<Item> GetTaskFromTo(int userId, int from, int to)
        {
            try
            {
                // get tasks from ... to ... order by limited at and priority
                var tasks = _context.Item.Where(x => x.UserId == userId).OrderBy(x => x.LimitedAt).ThenBy(x => x.Priority).Skip(from - 1).Take(to - from + 1).ToList();

                return tasks;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
            
        }

        public int GetTaskCount(int userId)
        {
            try
            {
                // get tasks count
                var tasks = _context.Item.Where(x => x.UserId == userId).Count();
                return tasks;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        public int GetIncompleteTaskCount(int userId)
        {
            try
            {
                // get incomplete tasks count
                var tasks = _context.Item.Where(x => x.UserId == userId && x.IsCompleted == false).Count();
                return tasks;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        public int GetCompletedTaskCount(int userId)
        {
            try
            {
                // get completed tasks count
                var tasks = _context.Item.Where(x => x.UserId == userId && x.IsCompleted == true).Count();
                return tasks;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        public async Task<bool> InsertTask(Item item)
        {
            try
            {
                _context.Item.Add(item);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        public async Task<bool> UpdateTask(Item item)
        {
            try
            {
                _context.Item.Update(item);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        public async Task<bool> DeleteTask(int id)
        {
            try
            {
                var item = await _context.Item.FindAsync(id);
                _context.Item.Remove(item);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

    }
}
