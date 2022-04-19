using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using todoapp_api.Data;
using todoapp_api.Models;
using todoapp_api.Contract.Task;
using todoapp_api.Utils;
using todoapp_api.Services.Interfaces;

namespace todoapp_api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create([FromBody] ItemModel model)
        {
            try
            {
                if (string.IsNullOrEmpty(model.Title))
                    return BadRequest(new Response { Success = false, Message = "Title is required" });
                var todoItem = new Item
                {
                    UserId = User.GetLoggedInUserId(),
                    Title = model.Title,
                    Description = model.Description ?? "",
                    Priority = model.Priority ?? 5,
                    IsCompleted = model.IsCompleted ?? false,
                    Color = model.Color ?? "#1A1A1A",
                    Status = model.Status.IsNull() ? Status.TODO : (Status)model?.Status,
                    LimitedAt = model.LimitedAt ?? DateTimeOffset.Now.AddDays(1),
                    SubItems = model.SubItems
                };
                var result = await _taskService.InsertTask(todoItem);
                if (!result)
                    return StatusCode(StatusCodes.Status400BadRequest, new Response { Success = false, Message = "Failed to insert task to the database" });
                return StatusCode(StatusCodes.Status200OK, new Response { Success = true, Message = "Successfully insert task to the database" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Success = false, Message = ex.Message });
            }
        }

        [HttpGet]
        [Route("get/{amount}")]
        public async Task<IActionResult> GetByAmount(int amount)
        {
            try
            {
                var tasks = _taskService.GetTaskByAmount(amount);
                if (tasks == null)
                    return StatusCode(StatusCodes.Status400BadRequest, new Response { Success = false, Message = "Failed to get task from the database" });
                return StatusCode(StatusCodes.Status200OK, new Response { Success = true, Message = "Successfully get task from the database" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Success = false, Message = ex.Message });
            }
        }
    }
}
