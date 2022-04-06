using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TodoApi.Models
{
    public class Step
    {
        [Key]
        public int Id { get; set; }
        public int TodoItemId { get; set;}
        public string Name { get; set; } = "";
        public string? Description { get; set; }
        public Boolean IsComplete { get; set; } = false;
    }
}
