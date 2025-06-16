using Microsoft.AspNetCore.Mvc;
using PetshopAPISystem.Domain.Models;
using PetshopAPISystem.Domain.Services;

namespace PetshopAPISystem.Api.Controllers;

[ApiController]
[Route("api/pet")]
public class PetController : ControllerBase
{
    private readonly PetService _petService;

    public PetController(PetService petService)
    {
        _petService = petService;
    }

    [HttpPost]
    public IActionResult CreatePet([FromBody] Pet pet)
    {
        var createdPet = _petService.CreatePet(pet);
        return CreatedAtAction(nameof(GetPetById), new { id = createdPet.Id }, createdPet);
    }

    [HttpGet]
    public ActionResult<List<Pet>> GetAllPets()
    {
        var pets = _petService.GetAllPets();
        return Ok(pets);
    }

    [HttpGet("{id:long}")]
    public ActionResult<Pet> GetPetById(long id)
    {
        var pet = _petService.GetPetById(id);
        if (pet == null) return NotFound();
        return Ok(pet);
    }

    [HttpGet("{name}")]
    public ActionResult<Pet> GetPetByName(string name)
    {
        var pet = _petService.GetPetByName(name);
        if (pet == null) return NotFound();
        return Ok(pet);
    }

    [HttpPut("{id:long}")]
    public IActionResult UpdatePet(long id, Pet pet)
    {
        var updatedPet = _petService.UpdatePet(id, pet);
        if (updatedPet == null) return NotFound();
        return Ok(updatedPet);
    }

    [HttpDelete("{id:long}")]
    public IActionResult DeletePet(long id)
    {
        var success = _petService.DeletePet(id);
        if (!success) return NotFound();
        return NoContent();
    }
}