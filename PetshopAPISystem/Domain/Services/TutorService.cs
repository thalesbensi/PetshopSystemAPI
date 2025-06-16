using PetshopAPISystem.Domain.Contexts;
using PetshopAPISystem.Domain.Models;

namespace PetshopAPISystem.Domain.Services;

public class TutorService
{
    private AppDbContext _context;

    public TutorService(AppDbContext context)
    {
        _context = context;
    }

    public Tutor CreateTutor(Tutor tutor)
    {
        _context.Tutors.Add(tutor);
        _context.SaveChanges();
        return tutor;
    }

    public List<Tutor> GetTutors() => _context.Tutors.ToList();
    
    public Tutor? GetTutorById(long id) => _context.Tutors.Find(id);
    
    public Tutor? GetTutorByName(string name) => _context.Tutors.FirstOrDefault(p => p.Name == name);

    public Tutor? UpdateTutor(long id, Tutor tutor)
    {
        var tutorToUpdate = _context.Tutors.Find(id);
        if (tutorToUpdate == null) return null;
        
        tutorToUpdate.Name = tutor.Name;
        tutorToUpdate.Email = tutor.Email;

        _context.Update(tutorToUpdate);
        _context.SaveChanges();
        
        return tutorToUpdate;
    }

    public bool DeleteTutor(long id)
    {
        var tutorToDelete = _context.Tutors.Find(id);
        if (tutorToDelete == null) return false;
        
        _context.Tutors.Remove(tutorToDelete);
        _context.SaveChanges();
        return true;
    }
    
}