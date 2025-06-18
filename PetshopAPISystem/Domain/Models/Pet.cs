using System.ComponentModel.DataAnnotations;

namespace PetshopAPISystem.Domain.Models;

public class Pet
{
    public long Id { get; set; }
    
    [Required (ErrorMessage = "Name is required")]
    public string Name { get; set; }
    
    [Required (ErrorMessage = "Age is required")]
    public int Age { get; set; }
    
    [Required (ErrorMessage = "Type is required")]
    public PetType Type { get; set; }
    public string Race { get; set; }
    
    public long TutorId { get; set; }
}