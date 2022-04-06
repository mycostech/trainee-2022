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
    [Route("api/[controller]")]
    [ApiController]
    public class TodoListsController : ControllerBase
    {
        private readonly ITodoListService _todoListService;

        public TodoListsController(ITodoListService todoListService)
        {
            _todoListService = todoListService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoList>>> GetTodoLists()
        {
            return await _todoListService.GetTodoLists();
        }

        // GET: api/TodoLists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TodoList>> GetTodoList(int id)
        {
            var todoList = await _todoListService.GetTodoList(id);

            if (todoList == null)
            {
                return NotFound();
            }

            return todoList;
        }

        [HttpGet("{id}/tasks")]
        public async Task<ActionResult<IEnumerable<TodoTask>>> GetTodoTasks(int id)
        {
            var todoTasks = await _todoListService.GetTodoTasks(id);

            if (todoTasks == null)
            {
                return NotFound();
            }

            return todoTasks;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TodoList>> PutTodoLists(int id, [FromBody] TodoList todoLists)
        {
            return await _todoListService.UpdateList(id, todoLists);
        }

        // POST: api/TodoItems
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TodoList>> PostTodoList([FromBody] TodoList todoList)
        {
            return await _todoListService.CreateList(todoList);
        }

        // DELETE: api/TodoItems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TodoList>> DeleteTodoList(int id)
        {
            return await _todoListService.DeleteList(id);
        }
    }
}
