using Microsoft.EntityFrameworkCore;
using PetshopAPISystem.Domain.Contexts;
using PetshopAPISystem.Domain.Models;

namespace PetshopAPISystem.Domain.Services
{
    public class PetService
    {
        private readonly AppDbContext _context;

        public PetService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Pet> CreatePetAsync(Pet pet)
        {
            await _context.Pets.AddAsync(pet);
            await _context.SaveChangesAsync();
            return pet;
        }

        public async Task<List<Pet>> GetAllPetsAsync() => await _context.Pets.ToListAsync();
        

        public async Task<Pet?> GetPetByIdAsync(long id) => await _context.Pets.FindAsync(id);
        
        public async Task<Pet?> GetPetByNameAsync(string name) => await _context.Pets.FirstOrDefaultAsync(p => p.Name == name);
        
        public async Task<Pet?> UpdatePetAsync(long id, Pet pet)
        {
            var petToUpdate = await _context.Pets.FindAsync(id);
            if (petToUpdate == null) return null;

            petToUpdate.Name = pet.Name;
            petToUpdate.Age = pet.Age;
            petToUpdate.Type = pet.Type;
            petToUpdate.Race = pet.Race;

            _context.Pets.Update(petToUpdate);
            await _context.SaveChangesAsync();

            return petToUpdate;
        }

        public async Task<bool> DeletePetAsync(long id)
        {
            var pet = await _context.Pets.FindAsync(id);
            if (pet == null) return false;

            _context.Pets.Remove(pet);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}