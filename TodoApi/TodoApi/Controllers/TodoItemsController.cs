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
    public class TodoItemsController : ControllerBase
    {
        //private readonly TodoContext _context;
        private readonly ITodoService _todoService;
        public TodoItemsController(ITodoService todoService)
        {
            //_context = context;
            _todoService = todoService;
        }

        // GET: api/TodoItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoItem>>> GetTodoItems()
        {
            //return await _context.TodoItems.ToListAsync();
            return await _todoService.GetTodoItems();
        }

        // GET: api/TodoItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItem>> GetTodoItem(int id)
        {
            //var todoItem = await _context.TodoItems.FindAsync(id);
            var todoItem = await _todoService.GetTodoItem(id);
            if (todoItem == null)
            {
                return NotFound();
            }

            return todoItem;
        }

        // PUT: api/TodoItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<TodoItem>> PutTodoItem(int id, [FromBody] TodoItem newItem)
        {
            //if (id != todoItem.Id)
            //{
            //    return BadRequest();
            //}

            //_context.Entry(todoItem).State = EntityState.Modified;

            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!TodoItemExists(id))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            //return NoContent();
            return await _todoService.UpdateItem(id, newItem);
        }

        // POST: api/TodoItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TodoItem>> PostTodoItem([FromBody]TodoItem todoItem)
        {
            //_context.TodoItems.Add(todoItem);
            //await _context.SaveChangesAsync();

            //return CreatedAtAction("GetTodoItem", new { id = todoItem.Id }, todoItem);
            //return CreatedAtAction(nameof(GetTodoItem), new { id = todoItem.Id }, todoItem);
            var newtodo = await _todoService.CreateItem(todoItem);
            if (newtodo == null) return NotFound();
            return newtodo;
        }

        // DELETE: api/TodoItems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TodoItem>> DeleteTodoItem(int id)
        {
            //var todoItem = await _context.TodoItems.FindAsync(id);
            //if (todoItem == null)
            //{
            //    return NotFound();
            //}

            //_context.TodoItems.Remove(todoItem);
            //await _context.SaveChangesAsync();

            //return NoContent();

            return await _todoService.DeleteItem(id);
        }
    }
}
