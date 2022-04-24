using System.ComponentModel.DataAnnotations;
using todoapp_api.Models;

namespace todoapp_api.Contract.Task
{
    public class ItemModel
    {
        public int? Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Priority { get; set; }
        public bool? IsCompleted { get; set; }
        public int? Status { get; set; }
        public string? Color { get; set; }
        public DateTimeOffset? LimitedAt { get; set; }
        public List<SubItem>? SubItems { get; set; }
    }
}
