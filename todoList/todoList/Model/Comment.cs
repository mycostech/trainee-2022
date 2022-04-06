using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace todoAPI.Model
{
    public class Comment
    {
        [Required, Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string content { get; set; }
        public DateTime cm_date { get; set; }


        [ForeignKey(nameof(Task))]
        public int TaskId { get; set; }

    }
}
