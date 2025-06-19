using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetshopAPISystem.Domain.Models;
using PetshopAPISystem.Domain.Services;

namespace PetshopAPISystem.Api.Controllers;

[ApiController]
[Route("api/tutor")]
public class TutorController : ControllerBase
{
    private readonly TutorService _tutorService;

    public TutorController(TutorService tutorService)
    {
        _tutorService = tutorService;
    }

    [Authorize(Roles = "ADMIN")]
    [HttpGet]
    public async Task<ActionResult<List<Tutor>>> GetAllTutors()
    {
        var tutors = await _tutorService.GetTutorsAsync();
        return Ok(tutors);
    }

    [Authorize(Roles = "ADMIN")]
    [HttpGet("{id:long}")]
    public async Task<ActionResult<Tutor>> GetTutorById(long id)
    {
        var tutor = await _tutorService.GetTutorByIdAsync(id);
        if (tutor == null) return NotFound();
        return Ok(tutor);
    }

    [Authorize(Roles = "ADMIN")]
    [HttpGet("byName/{name}")]
    public async Task<ActionResult<Tutor>> GetTutorByName(string name)
    {
        var tutor = await _tutorService.GetTutorByNameAsync(name);
        if (tutor == null) return NotFound();
        return Ok(tutor);
    }
    
    [Authorize(Roles = "ADMIN")]
    [HttpPut("{id:long}")]
    public async Task<IActionResult> UpdateTutor(long id, [FromBody] Tutor tutor)
    {
        var updatedTutor = await _tutorService.UpdateTutorAsync(id, tutor);
        if (updatedTutor == null) return NotFound();
        return Ok(updatedTutor);
    }

    [Authorize(Roles = "ADMIN")]
    [HttpDelete("{id:long}")]
    public async Task<IActionResult> DeleteTutor(long id)
    {
        var success = await _tutorService.DeleteTutorAsync(id);
        if (!success) return NotFound();
        return NoContent();
    }
}