using Microsoft.EntityFrameworkCore;
using TodoApi.Models;
using TodoApi.Services.Interfaces;

namespace TodoApi.Services
{
    public class StepService : IStepService
    {
        private readonly TodoContext _context;
        public StepService(TodoContext context)
        {
            _context = context;
        }
        public async Task<Step> CreateItem(Step step)
        {
            _context.Step.Add(step);
            await _context.SaveChangesAsync();
            return step;

        }

        public async Task<Step> DeleteItem(int id)
        {
            var step = _context.Step.Find(id);
            if (step == null) 
                throw new KeyNotFoundException("Step is not found.");
            try   
            {
            _context.Remove(step);
            await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException err)
            {
            throw err;
            }

            return step;
        }

        public async Task<List<Step>> GetAllSteps()
        {
            return await _context.Step.ToListAsync();
        }

        public Task<List<Step>> GetItemSteps(int itemId)
        {
            throw new NotImplementedException();
        }

        public async Task<Step> GetStep(int id)
        {
            return await _context.Step.FindAsync(id);

        }

        public async Task<Step> UpdateSteps(int id,Step step)
        {
            if (_context.Step.Find(id)==null)
            {
                throw new KeyNotFoundException("Step not Found"+id);
            }
            var newStep = _context.Step.First( a => a.Id == id);
            newStep.Name = step.Name;
            newStep.Description = step.Description; 
            newStep.IsComplete = step.IsComplete;

            try
            {
                await _context.SaveChangesAsync();
            }catch (DbUpdateConcurrencyException err)
            {
                throw err;
            }
            return newStep;
        }
    }
}
