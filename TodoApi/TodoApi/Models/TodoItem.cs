using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TodoApi.Models
{
    public class TodoItem
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public String Name { get; set; } = "";
        public String? Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsComplete { get; set; } = false;
        [ForeignKey("TodoItemId")]
        public List<Step>? Steps { get; set; }
    }
}