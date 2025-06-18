using System.ComponentModel.DataAnnotations;

namespace PetshopAPISystem.Domain.Models;

public class Tutor
{
    public long Id { get; set; }
    
    [Required]
    public string Name { get; set; }
    
    [EmailAddress]
    [Required]
    public string Email { get; set; }
    
    [Required]
    public string Password { get; set; }
    
    [Required]
    public Role[] Roles { get; set; }
}