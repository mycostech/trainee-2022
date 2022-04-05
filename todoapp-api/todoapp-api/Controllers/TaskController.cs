using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using todoapp_api.Data;
using todoapp_api.Models;
using todoapp_api.Models.Task;
using todoapp_api.Utils;

namespace todoapp_api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly todoapp_apiContext _context;

        public TaskController(todoapp_apiContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create([FromBody] ItemModel model)
        {
            if (string.IsNullOrEmpty(model.Title))
                return BadRequest(new Response { Success = false, Message = "Title is required"});

            var todoItem = new Item
            {
                UserId = User.GetLoggedInUserId(),
                Title = model.Title,
                Description = model.Description ?? "",
                Priority = model.Priority ?? 5,
                IsCompleted = model.IsCompleted ?? false,
                Color = model.Color ?? "#1A1A1A",
                Status = model.Status.IsNull() ? Status.TODO : (Status)model?.Status,
                LimitedAt = model.LimitedAt ?? DateTimeOffset.Now.AddDays(1)
            };

            try
            {
                _context.Item.Add(todoItem);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest(new Response { Success = false, Message = ex.Message });
            }
            return Ok(new Response { Success = true, Message = "Successfully create task" });
        }

        [HttpGet]
        [Route("get/{amount}")]
        public async Task<IActionResult> GetByAmount(int amount)
        {
            var tasks = _context.Item.Take(amount);
            return Ok(tasks);

        }
    }
}
