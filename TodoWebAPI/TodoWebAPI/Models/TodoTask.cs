using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TodoWebAPI.Models
{
    public class TodoTask
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Status { get; set; }

        public DateTime DueDate { get; set; }

        [ForeignKey(nameof(TodoListId))]
        public int TodoListId { get; set; }
    }
}
