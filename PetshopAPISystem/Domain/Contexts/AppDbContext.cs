using Microsoft.EntityFrameworkCore;
using PetshopAPISystem.Domain.Models;

namespace PetshopAPISystem.Domain.Contexts;

public class AppDbContext : DbContext
{
    public DbSet<Tutor> Tutors { get; set; }
    public DbSet<Pet> Pets { get; set; }
    
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

}