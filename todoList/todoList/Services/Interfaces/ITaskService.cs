namespace todoAPI.Services
{
    public interface ITaskService
    {
        public Task<Model.Task> GetTask(int id);
        public Task<Model.Task> UpdateTask(int id, Model.Task task);
        public Task<Model.Task> CreateTask(int todo_id, Model.Task task);
        public Task<Model.Task> DeleteTask(int id);
    }
}
