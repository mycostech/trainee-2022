using todoapp_api.Data;
using todoapp_api.Models;
using todoapp_api.Services.Interfaces;
using System.Linq;
using Microsoft.EntityFrameworkCore;

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

        public List<Item> GetTaskByAmount(int amount)
        {
            try
            {
                var tasks = _context.Item.Include(i => i.SubItems).Take(amount).ToList();
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

    }
}
