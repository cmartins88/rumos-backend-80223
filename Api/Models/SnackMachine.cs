using System.ComponentModel.DataAnnotations;

namespace Api.Models;

public class SnackMachine
{
    [Key]
    public Guid Id { get; set; }
    public string address { get; set; }

    public IList<Product>? products { get; set; }
}