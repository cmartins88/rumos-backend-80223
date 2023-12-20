using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ProjectoFinal.Models
{
    [PrimaryKey(nameof(RecipeId), nameof(UserId))]
    public class Favorite
    {
        public Guid RecipeId { get; set; }

        [DeleteBehavior(DeleteBehavior.NoAction)]
        public virtual Recipe Recipe { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
