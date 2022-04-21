using todoapp_api.Models;

namespace todoapp_api.Services.Interfaces
{
    public interface ITaskService
    {
        public Task<bool> InsertTask(Item item);
        public List<Item> GetTaskFromTo(int userId, int from, int to);
        public int GetTaskCount(int userId);
        public int GetCompletedTaskCount(int userId);
    }
}
