using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace todoAPI.Model
{
    public class TodoList
    {
        [Required, Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string name { get; set; }
        public string td_description { get; set; }
        public bool is_complete { get; set; }
        //[ForeignKey(nameof(TodoList))]
        public List<Task> Tasks { get; set; }

    }
}
