using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectoFinal.Models
{
    public enum CATEGORIES {SOBREMESA, PRATO_PRINCIPAL, ENTRADA};

    public class Recipe
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public bool IsApproved { get; set; } = false;

        [Required]
        public int Difficulty { get; set; }

        [Required]
        public CATEGORIES Category { get; set; }

        public bool IsDeleted { get; set; } = false;

        private int _duration;
        [Required]
        public int Duration { 
            get { return _duration; } 
            set { if (_duration < 0) throw new Exception(""); else _duration = value; } }

        private int _evaluation_count = 0;
        public int Evaluation_count { 
            get { return _evaluation_count; } 
            set { _evaluation_count += 1; } 
        }

        public int Evaluation_sum { get; set; }

        [NotMapped]
        public double Evaluation_avg { get { return Evaluation_count == 0 ? 0 : (Evaluation_sum / Evaluation_count); } }

        //public string Ingredients { get; set; }

        public virtual ICollection<Ingredient> Ingredients { get; } = new List<Ingredient>();

        [Required]
        public string UserId { get; set; }
        public virtual ApplicationUser? User { get; set; }

        public virtual ICollection<Favorite>? Favorite { get; }

        public virtual ICollection<Comment>? Comments { get; }
    }
}
