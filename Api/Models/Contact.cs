using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace Api.Models
{
    public class Contact
    {
        [Key]
        [DefaultValue(true)]
        public Guid Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Telefone { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Duvida { get; set; }


    }
}
