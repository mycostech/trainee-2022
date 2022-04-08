
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace todoapp_api.Models
{
    public class User : IdentityUser<int>
    {
        [Required, Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override int Id { get; set; }
        [ForeignKey("UserId")]
        public List<Item>? Items { get; set; }
    }
}
