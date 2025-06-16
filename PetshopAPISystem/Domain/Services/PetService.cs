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

        public Pet CreatePet(Pet pet)
        {
            _context.Pets.Add(pet);
            _context.SaveChanges();
            return pet;
        }

        public List<Pet> GetAllPets()
        {
            return _context.Pets.ToList();
        }

        public Pet? GetPetById(long id)
        {
            return _context.Pets.Find(id);
        }

        public Pet? GetPetByName(string name)
        {
            return _context.Pets.FirstOrDefault(p => p.Name == name);
        }

        public Pet? UpdatePet(long id, Pet pet)
        {
            var petToUpdate = _context.Pets.Find(id);
            if (petToUpdate == null) return null;

            petToUpdate.Name = pet.Name;
            petToUpdate.Age = pet.Age;
            petToUpdate.Type = pet.Type;

            _context.Pets.Update(petToUpdate);
            _context.SaveChanges();

            return petToUpdate;
        }

        public bool DeletePet(long id)
        {
            var pet = _context.Pets.Find(id);
            if (pet == null) return false;

            _context.Pets.Remove(pet);
            _context.SaveChanges();
            return true;
        }
    }
}