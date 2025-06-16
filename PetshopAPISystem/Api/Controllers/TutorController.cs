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

    [HttpPost]
    public IActionResult CreateTutor([FromBody] Tutor tutor)
    {
        var createdTutor = _tutorService.CreateTutor(tutor);
        return CreatedAtAction(nameof(GetTutorById), new { id = createdTutor.Id }, createdTutor);
    }

    [HttpGet]
    public ActionResult<List<Tutor>> GetAllTutors()
    {
        var tutors = _tutorService.GetTutors();
        return Ok(tutors);
    }

    [HttpGet("{id:long}")]
    public ActionResult<Tutor> GetTutorById(long id)
    {
        var tutor = _tutorService.GetTutorById(id);
        if (tutor == null) return NotFound();
        return Ok(tutor);
    }

    [HttpGet("{name}")]
    public ActionResult<Tutor> GetTutorByName(string name)
    {
        var tutor = _tutorService.GetTutorByName(name);
        if (tutor == null) return NotFound();
        return Ok(tutor);
    }

    [HttpPut("{id:long}")]
    public IActionResult UpdateTutor(long id, [FromBody] Tutor tutor)
    {
        var updatedTutor = _tutorService.UpdateTutor(id, tutor);
        if (updatedTutor == null) return NotFound();
        return Ok(updatedTutor);
    }

    [HttpDelete("{id:long}")]
    public IActionResult DeleteTutor(long id)
    {
        var success = _tutorService.DeleteTutor(id);
        if (!success) return NotFound();
        return NoContent();
    }
}