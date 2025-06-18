using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using PetshopAPISystem.Api.DTOs.Requests;
using PetshopAPISystem.Domain.Contexts;
using PetshopAPISystem.Domain.Models;

namespace PetshopAPISystem.Domain.Services;

public class AuthService
{
    private readonly AppDbContext _context;
    private readonly TutorService _tutorService;
    private readonly TokenService _tokenService;

    public AuthService(AppDbContext context, TutorService tutorService, TokenService tokenService)
    {
        _context = context;
        _tutorService = tutorService;
        _tokenService = tokenService;
    }

    public async Task<Tutor?> Register(Tutor tutor)
    {
        if (await _tutorService.GetTutorByEmailAsync(tutor.Email) != null)
            return null;

        var newTutor = new Tutor
        {
            Name = tutor.Name,
            Email = tutor.Email,
            Password = BCrypt.Net.BCrypt.HashPassword(tutor.Password),
            Roles = tutor.Roles
        };

        await _tutorService.CreateTutorAsync(newTutor);
        return newTutor;
    }
    
    public async Task<String?> Login(TutorLoginRequestDTO request)
    {
        var tutor = await _tutorService.GetTutorByEmailAsync(request.Email);
        if (tutor == null || !BCrypt.Net.BCrypt.Verify(request.Password, tutor.Password))
            return null;

        var token = _tokenService.GenerateToken(tutor);
        return token;
    }
}