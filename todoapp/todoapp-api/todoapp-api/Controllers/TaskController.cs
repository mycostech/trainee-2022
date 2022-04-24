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
                    Priority = model.Priority ?? "LOW",
                    IsCompleted = model.IsCompleted ?? false,
                    Color = model.Color ?? "#1A1A1A",
                    CreatedAt = DateTimeOffset.UtcNow,
                    UpdatedAt = DateTimeOffset.UtcNow,
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
        [Route("getTaskCount")]
        public IActionResult GetTaskCount()
        {
            try
            {
                var userId = User.GetLoggedInUserId();
                var count = _taskService.GetTaskCount(userId);
                return StatusCode(StatusCodes.Status200OK, new Response { Success = true, Message = "Success", Object = count });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Success = false, Message = ex.Message });
            }
        }

        [HttpGet]
        [Route("getIncompleteTaskCount")]
        public IActionResult GetIncompleteTaskCount()
        {
            try
            {
                var userId = User.GetLoggedInUserId();
                var count = _taskService.GetIncompleteTaskCount(userId);
                return StatusCode(StatusCodes.Status200OK, new Response { Success = true, Message = "Success", Object = count });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Success = false, Message = ex.Message });
            }
        }

        [HttpGet]
        [Route("getCompletedTaskCount")]
        public IActionResult GetCompletedTaskCount()
        {
            try
            {
                var userId = User.GetLoggedInUserId();
                var count = _taskService.GetCompletedTaskCount(userId);
                return StatusCode(StatusCodes.Status200OK, new Response { Success = true, Message = "Success", Object = count });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Success = false, Message = ex.Message });
            }
        }

        [HttpGet]
        [Route("getTaskFromTo/{from}/{to}")]
        public async Task<IActionResult> GetTaskFromTo(int from, int to)
        {
            try
            {
                var tasks = _taskService.GetTaskFromTo(User.GetLoggedInUserId(), from, to);
                if (tasks == null)
                    return StatusCode(StatusCodes.Status400BadRequest, new Response { Success = false, Message = "Failed to get task from the database" });
                return StatusCode(StatusCodes.Status200OK, new Response { Success = true, Message = "Successfully get task from the database", Object = tasks });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Success = false, Message = ex.Message });
            }
        }

        [HttpPost]
        [Route("update")]

        public async Task<IActionResult> Update([FromBody] ItemModel model)
        {
            try
            {
                if (string.IsNullOrEmpty(model.Title))
                    return BadRequest(new Response { Success = false, Message = "Title is required" });
                var todoItem = new Item
                {
                    Id = model.Id ?? 0,
                    UserId = User.GetLoggedInUserId(),
                    Title = model.Title,
                    Description = model.Description ?? "",
                    Priority = model.Priority ?? "LOW",
                    IsCompleted = model.IsCompleted ?? false,
                    Color = model.Color ?? "#1A1A1A",
                    UpdatedAt = DateTimeOffset.UtcNow,
                    LimitedAt = model.LimitedAt ?? DateTimeOffset.Now.AddDays(1),
                    SubItems = model.SubItems
                };
                var result = await _taskService.UpdateTask(todoItem);
                if (!result)
                    return StatusCode(StatusCodes.Status400BadRequest, new Response { Success = false, Message = "Failed to update task to the database" });
                return StatusCode(StatusCodes.Status200OK, new Response { Success = true, Message = "Successfully update task to the database" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Success = false, Message = ex.Message });
            }
        }

        [HttpPost]
        [Route("delete")]

        public async Task<IActionResult> Delete([FromBody] ItemModel model)
        {
            try
            {
                var result = await _taskService.DeleteTask(model.Id ?? 0);
                if (!result)
                    return StatusCode(StatusCodes.Status400BadRequest, new Response { Success = false, Message = "Failed to delete task to the database" });
                return StatusCode(StatusCodes.Status200OK, new Response { Success = true, Message = "Successfully delete task to the database" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Success = false, Message = ex.Message });
            }
        }
    }
}
