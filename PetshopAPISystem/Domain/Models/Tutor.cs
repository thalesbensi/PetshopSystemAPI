using System.ComponentModel.DataAnnotations;

namespace PetshopAPISystem.Domain.Models;

public class Tutor
{
    public long Id { get; set; }
    
    [Required]
    public string Name { get; set; }
    
    [EmailAddress]
    public string Email { get; set; }
    
    public List<Pet> Pets { get; set; } = new List<Pet>();
}