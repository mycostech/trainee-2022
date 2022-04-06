using Microsoft.AspNetCore.Mvc;
using TodoListAPI.Models;
using TodoListAPI.Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TodoListAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoListController : ControllerBase
    {
        //private static List<TodoList> list = new List<TodoList>
        //    {
        //        new TodoList {
        //            Id = 1,
        //            Tlist = "test",
        //            IsComplete = true,
        //            DateAdd = DateTime.Now,
        //            DueDate = DateTime.Now
        //        },
        //        new TodoList {
        //            Id = 2,
        //            Tlist = "view",
        //            IsComplete = true,
        //            DateAdd = DateTime.Now,
        //            DueDate = DateTime.Now
        //        },
        //    };

        //private readonly DataContext _context;

        //public TodoListController(DataContext Context)
        //{
        //    _context = Context;
        //}

        private readonly ITodoService _todoService;

        public TodoListController(ITodoService todoService)
        {
            _todoService = todoService;
        }


        // GET: api/<TodoListController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoList>>> GetTodoList()
        {
            return await _todoService.GetTodoList();
        }

        // GET api/<TodoListController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TodoList>> GetTodoList(int id)
        {
            var todoItems = await _todoService.GetTodoList(id);
            if (todoItems == null)
                return BadRequest("Not found.");
            return Ok(todoItems);
        }

        // POST api/<TodoListController>
        [HttpPost]
        public async Task<ActionResult<TodoList>> PostTodoList([FromBody] TodoList todoItem)
        {
            return await _todoService.CreateList(todoItem);
        }


        // PUT api/<TodoListController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<TodoList>> PutTodoList(int id, [FromBody] TodoList todoItems)
        {
            var todo = await _todoService.UpdateList(id, todoItems);
            if (todo == null) return BadRequest("Not found.");
            return Ok(todo);
        }

        // DELETE api/<TodoListController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TodoList>> DeleteTodoList(int id)
        {
            var todo = await _todoService.DeleteList(id);
            if (todo == null) return BadRequest("Not found.");
            return Ok(todo);
        }

        
        // GET api/<TodoListController>/5/5
        [HttpGet("{id}/{ids}")]
        public async Task<ActionResult<TodoSubList>> GetTodoSubList(int id, int ids)
        {
            var todoSub = await _todoService.GetTodoSubList(ids, id);
            if(todoSub == null) return BadRequest("Not found.");
            return Ok(todoSub);
        }

        // POST api/<TodoListController>/5
        [HttpPost("{id}")]
        public async Task<ActionResult<TodoSubList>> PostTodoSubList(int id, [FromBody] TodoSubList todoItem)
        {
            var todoItems = await _todoService.GetTodoList(id);
            if (todoItems == null)
                return BadRequest("Not found.");
            return await _todoService.CreateSubList(id ,todoItem);
        }

        // PUT api/<TodoListController>/5
        [HttpPut("{id}/{ids}")]
        public async Task<ActionResult<TodoSubList>> PutTodoSubList(int id, int ids , [FromBody] TodoSubList todoItems)
        {
            var todo = await _todoService.UpdateSubList(ids, id, todoItems);
            if (todo == null)
                return BadRequest("Not found.");
            return Ok(todo);
        }

        // DELETE api/<TodoListController>/5
        [HttpDelete("{id}/{ids}")]
        public async Task<ActionResult<TodoSubList>> DeleteTodoSubList(int id,int ids)
        {
            var todo = await _todoService.DeleteSubList(ids, id);
            if (todo == null)
                return BadRequest("Not found.");
            return Ok(todo);
        }
    }
}
