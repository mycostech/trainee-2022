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

namespace todoAPI.Controllers
{
    [Route("api/{todo_id}/Tasks")]
    [ApiController]
    public class Tasks : ControllerBase
    {
        private readonly ITaskService _taskService;

        public Tasks(ITaskService taskService)
        {
            _taskService = taskService;
        }


        // GET: api/1/Tasks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Model.Task>> GetTask(int id)
        {
            var task = await _taskService.GetTask(id);

            if (task == null)
            {
                return NotFound();
            }

            return task;
        }

        // PUT: api/1/Tasks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTask(int id, Model.Task task)
        {
            //if (id != task.Id)
            //{
            //    return BadRequest();
            //}

            task = await _taskService.UpdateTask(id, task);

           if(task == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/1/Tasks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Model.Task>> PostTask(int todo_id,Model.Task task)
        {
     
            return await _taskService.CreateTask(todo_id, task);
        }

        // DELETE: api/1/Tasks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            var task = await _taskService.GetTask(id);
            if (task == null){
                return NotFound();
            }
            await _taskService.DeleteTask(id);
            return NoContent();
        }
    }
}
