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
    
    [Route("api/todo")]
    [ApiController]
    

    public class TodoLists : ControllerBase
    {
        private readonly ITodoService _todoService;

        public TodoLists(ITodoService todoService)
        {
            _todoService = todoService;
        }

        // GET: api/TodoLists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoList>>> GetTodoList()
        {
            return await _todoService.GetTodoList();
        }
        // GET: api/TodoLists/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTodoItem(int id)
        {

            var todoItem = await _todoService.GetTodoItem(id);
            if (todoItem == null)
            {
                return NotFound();
            }
            //var todoList = await _context.TodoList.FindAsync(id);


            return Ok(todoItem);
        }
        // GET: api/TodoLists/5/Tasks
        [HttpGet("{id}/Tasks")]
        public async Task<IActionResult> GetTasks(int id)
        {
           
            var todoItem = await _todoService.GetTodoItem(id);
            if (todoItem == null)
            {
                return NotFound();
            }
            //var todoList = await _context.TodoList.FindAsync(id);

           
            return Ok(await _todoService.GetTasks(id));
        }

        // PUT: api/TodoLists/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoList(int id, [FromBody] TodoList todoList)
        {
            var todoItem = await _todoService.GetTodoItem(id);
            if (todoItem == null)
            {
                return NotFound();
            }
            await _todoService.UpdateTodoItem(id, todoList);

            return NoContent();
        }

        // POST: api/TodoLists
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TodoList>> PostTodoList([FromBody] TodoList todoList)
        {
            var todoItem = await _todoService.GetTodoItem(todoList.Id);
            if (todoItem != null)
            {
                return Conflict();
            }
            return await _todoService.CreateTodoItem(todoList);
        }

        // DELETE: api/TodoLists/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoList(int id)
        {
            var todoItem = await _todoService.GetTodoItem(id);
            if (todoItem == null)
            {
                return NotFound();
            }
            await _todoService.DeleteTodoItem(id);
            return NoContent();

        }
        // PATCH : api/TodoLists/5
        [HttpPatch ("{id}")]
        public async Task<ActionResult<TodoList>> PatchTodoList(int id, bool is_comp)
        {
            var todoItem = await _todoService.GetTodoItem(id);
            if (todoItem == null)
            {
                return NotFound();
            }
            return await _todoService.ModifyTodoItem(id, is_comp);

        }
    }
}
