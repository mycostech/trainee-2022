using todoapp_api.Models;

namespace todoapp_api.Services.Interfaces
{
    public interface ITaskService
    {
        public Task<bool> InsertTask(Item item);
        public List<Item> GetTaskByAmount(int amount);
    }
}
