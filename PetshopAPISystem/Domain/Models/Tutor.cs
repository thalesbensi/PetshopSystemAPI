using System.ComponentModel.DataAnnotations;

namespace PetshopAPISystem.Domain.Models;

public class Tutor
{
    public long Id { get; set; }
    
    [Required(ErrorMessage = "Name is required")]
    [StringLength(20, MinimumLength = 5, ErrorMessage = "Name must be between 5 and 20 characters")]
    public string Name { get; set; }
    
    [EmailAddress]
    [Required (ErrorMessage = "Email is required")]
    public string Email { get; set; }
    
    [Required (ErrorMessage = "Password is required")]
    [StringLength(50, MinimumLength = 8, ErrorMessage = "Password must be between 8 and 50 characters")]
    public string Password { get; set; }
    
    [Required(ErrorMessage = "At least one role is required")]
    [MinLength(1, ErrorMessage = "At least one role is required")]
    public List<Role> Roles { get; set; }
}