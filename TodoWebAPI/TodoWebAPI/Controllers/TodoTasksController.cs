#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoWebAPI.Data;
using TodoWebAPI.Models;
using TodoWebAPI.Services;

namespace TodoWebAPI.Controllers
{
    [Route("api/TodoLists/{listid}/tasks")]
    [ApiController]
    public class TodoTasksController : ControllerBase
    {
        private readonly ITodoTaskService _todoTaskService;

        public TodoTasksController(ITodoTaskService todoTaskService)
        {
            _todoTaskService = todoTaskService;
        }

        // GET: api/TodoLists/5/tasks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TodoTask>> GetTodoList(int id)
        {
            var todoTask = await _todoTaskService.GetTodoTask(id);

            if (todoTask == null)
            {
                return NotFound();
            }

            return todoTask;
        }

        // POST: api/TodoItems
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TodoTask>> PostTodoTask([FromBody] TodoTask todoTask, int listid)
        {
            return await _todoTaskService.CreateTask(listid, todoTask);
        }

        // PUT: api/TodoItems
        [HttpPut("{id}")]
        public async Task<ActionResult<TodoTask>> PutTodoTasks(int id, [FromBody] TodoTask todoTasks)
        {
            return await _todoTaskService.UpdateTask(id, todoTasks);
        }

        

        // DELETE: api/TodoItems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TodoTask>> DeleteTodoTask(int id)
        {
            return await _todoTaskService.DeleteTask(id);
        }
    }
}
