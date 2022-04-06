using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TodoWebAPI.Models
{
    public class TodoList : BaseModel
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Color { get; set; }

        public List<TodoTask> Task { get; set; }
    }
}
