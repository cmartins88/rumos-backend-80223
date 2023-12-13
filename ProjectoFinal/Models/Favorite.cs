using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ProjectoFinal.Models
{
    [PrimaryKey(nameof(RecipeID), nameof(UserId))]
    public class Favorite
    {
        public Guid RecipeID { get; set; }

        [DeleteBehavior(DeleteBehavior.NoAction)]
        public virtual Recipe Recipe { get; set; }

        public string UserId { get; set; }

        [DeleteBehavior(DeleteBehavior.NoAction)]
        public virtual ApplicationUser User { get; set; }
    }
}
