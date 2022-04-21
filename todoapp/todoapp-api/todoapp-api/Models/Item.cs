using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace todoapp_api.Models
{

    public enum Status
    {
        TODO,
        IN_PROGRESS,
        DONE
    }

    public class Item
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("UserId")]
        [Required]
        public int UserId { get; set; }
        [StringLength(50)]
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Priority { get; set; }
        public bool? IsCompleted { get; set; }
        public Status? Status { get; set; }
        [StringLength(10)]
        public string? Color { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
        public DateTimeOffset LimitedAt { get; set; }
        [ForeignKey("ItemId")]
        public List<SubItem> SubItems { get; set; }
    }
}
