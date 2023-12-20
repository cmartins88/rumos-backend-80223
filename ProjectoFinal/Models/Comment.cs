using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ProjectoFinal.Models
{
    public class Comment
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public string Description { get; set; }

        [Required]
        public virtual ApplicationUser User { get; set; }

        [Required]
        [DeleteBehavior(DeleteBehavior.NoAction)]
        public virtual Recipe Recipe { get; set; }
    }
}
