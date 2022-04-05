using System.ComponentModel.DataAnnotations;
namespace todoapp_api.Models.Task
{
    public class ItemModel
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public int? Priority { get; set; }
        public bool? IsCompleted { get; set; }
        public int? Status { get; set; }
        public string? Color { get; set; }
        public DateTimeOffset? LimitedAt { get; set; }
    }
}
