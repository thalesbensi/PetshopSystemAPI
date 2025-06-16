namespace PetshopAPISystem.Domain.Models;

public class Pet
{
    public long Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public PetType Type { get; set; }
    public string Race { get; set; }
    public long TutorId { get; set; }
}