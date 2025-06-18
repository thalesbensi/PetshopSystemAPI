using Microsoft.EntityFrameworkCore;
using PetshopAPISystem.Domain.Contexts;
using PetshopAPISystem.Domain.Models;

namespace PetshopAPISystem.Domain.Services;

public class TutorService
{
    private readonly AppDbContext _context;

    public TutorService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Tutor> CreateTutorAsync(Tutor tutor)
    {
        await _context.Tutors.AddAsync(tutor);
        await _context.SaveChangesAsync();
        return tutor;
    }

    public async Task<List<Tutor>> GetTutorsAsync() => await _context.Tutors.ToListAsync();
    
    public async Task<Tutor?> GetTutorByIdAsync(long id) => await _context.Tutors.FindAsync(id);
    
    public async Task<Tutor?> GetTutorByNameAsync(string name) => await _context.Tutors.FirstOrDefaultAsync(p => p.Name == name);
        
    public async Task<Tutor?> GetTutorByEmailAsync(string email) => await _context.Tutors.FirstOrDefaultAsync(p => p.Email == email);
    
    public async Task<Tutor?> UpdateTutorAsync(long id, Tutor tutor)
    {
        var tutorToUpdate = await _context.Tutors.FindAsync(id);
        if (tutorToUpdate == null) return null;

        tutorToUpdate.Name = tutor.Name;
        tutorToUpdate.Email = tutor.Email;
        tutorToUpdate.Password = tutor.Password;

        _context.Tutors.Update(tutorToUpdate);
        await _context.SaveChangesAsync();

        return tutorToUpdate;
    }

    public async Task<bool> DeleteTutorAsync(long id)
    {
        var tutorToDelete = await _context.Tutors.FindAsync(id);
        if (tutorToDelete == null) return false;

        _context.Tutors.Remove(tutorToDelete);
        await _context.SaveChangesAsync();

        return true;
    }
}