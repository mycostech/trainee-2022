#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;
using TodoApi.Services.Interfaces;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StepsController : ControllerBase
    {
        //private readonly TodoContext _context;
        private readonly IStepService _stepService;
        public StepsController(IStepService stepService)
        {
            _stepService = stepService;
        }

        // GET: api/Steps
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Step>>> GetStep()
        {
            return await _stepService.GetAllSteps();
        }

        // GET: api/Steps/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Step>> GetStep(int id)
        {
            var step = await _stepService.GetStep(id);

            if (step == null)
            {
                return NotFound();
            }

            return step;
        }

        // PUT: api/Steps/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStep(int id,[FromBody] Step step)
        {
            //if (id != step.Id)
            //{
            //    return BadRequest();
            //}

            //_context.Entry(step).State = EntityState.Modified;

            try
            {
                //await _context.SaveChangesAsync();
                await _stepService.UpdateSteps(id, step);
            }
            catch (DbUpdateConcurrencyException err)
            {
                return NotFound(err.Message);
            }
            catch (KeyNotFoundException err){ 
                return NotFound(err.Message);
            }

            return NoContent();
        }

        // POST: api/Steps
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Step>> PostStep(Step step)
        {
            //_context.Step.Add(step);
            //await _context.SaveChangesAsync();
         
            var newStep = await _stepService.CreateItem(step);
            //return CreatedAtAction("CreatedStep", new { id = step.Id }, newStep);
            return newStep;
        }

        // DELETE: api/Steps/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStep(int id)
        {
            //var step = await _context.Step.FindAsync(id);
            //if (step == null)
            //{
            //    return NotFound();
            //}

            //_context.Step.Remove(step);
            //await _context.SaveChangesAsync();

            try { await _stepService.DeleteItem(id); }
            catch (DbUpdateConcurrencyException err)
            {
                return BadRequest(err.Message);
            }
            catch (KeyNotFoundException err)
            {
                return NotFound(err.Message);
            }
            return NoContent();
        }
    }
}
