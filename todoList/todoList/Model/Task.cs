
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace todoAPI.Model
{
    public class Task
    {
        [Required, Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string status { get; set; }
        public string t_description { get; set; }
        public DateTime start_date { get; set; }
        public DateTime due_date { get; set; }
        public DateTime complete_date { get; set; }
       
        //public Task Task { get; set; }
        [ForeignKey(nameof(TodoList))]
        public int TodoListId { get; set; }

        public List<Comment> Comments { get; set; }



    }
}
