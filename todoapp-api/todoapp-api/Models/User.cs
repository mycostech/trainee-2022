using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace todoapp_api.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [StringLength(50)]
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        [ForeignKey("FK_User_Item")]
        public List<Item>? Items { get; set; }
    }
}
