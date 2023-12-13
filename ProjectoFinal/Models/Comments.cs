using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ProjectoFinal.Models
{
    public class Comments
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public string Description { get; set; }

        [DeleteBehavior(DeleteBehavior.NoAction)]
        public virtual ApplicationUser User { get; set; }

        [DeleteBehavior(DeleteBehavior.NoAction)]
        public virtual Recipe Recipe { get; set; }
    }
}
