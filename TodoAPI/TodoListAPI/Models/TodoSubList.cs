using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TodoListAPI.Models;


namespace TodoListAPI.Models
{
    public class TodoSubList
    {
        public int Id { get; set; }
        [Required]
        public string Slist { get; set; }
        public bool IsComplete { get; set; }

        [ForeignKey(nameof(TodoList))]
        public int Id_list { get; set; }
        public TodoList TodoList { get; set; }

    }
}
