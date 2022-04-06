using TodoApi.Models;

namespace TodoApi.Services.Interfaces
{
    public interface IStepService
    {
        public Task<List<Step>> GetAllSteps();
        public Task<List<Step>> GetItemSteps(int itemId);
        public Task<Step> GetStep(int id);
        public Task<Step> UpdateSteps(int id, Step step);
        public Task<Step> CreateItem(Step step);
        public Task<Step> DeleteItem(int id);
    }
}
