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
    public async Task<IActionResult> CreatePet([FromBody] Pet pet)
    {
        var createdPet = await _petService.CreatePetAsync(pet);
        return CreatedAtAction(nameof(GetPetById), new { id = createdPet.Id }, createdPet);
    }

    [HttpGet]
    public async Task<ActionResult<List<Pet>>> GetAllPets()
    {
        var pets = await _petService.GetAllPetsAsync();
        return Ok(pets);
    }

    [HttpGet("{id:long}")]
    public async Task<ActionResult<Pet>> GetPetById(long id)
    {
        var pet = await _petService.GetPetByIdAsync(id);
        if (pet == null) return NotFound();
        return Ok(pet);
    }

    [HttpGet("byName/{name}")]
    public async Task<ActionResult<Pet>> GetPetByName(string name)
    {
        var pet = await _petService.GetPetByNameAsync(name);
        if (pet == null) return NotFound();
        return Ok(pet);
    }

    [HttpPut("{id:long}")]
    public async Task<IActionResult> UpdatePet(long id, [FromBody] Pet pet)
    {
        var updatedPet = await _petService.UpdatePetAsync(id, pet);
        if (updatedPet == null) return NotFound();
        return Ok(updatedPet);
    }

    [HttpDelete("{id:long}")]
    public async Task<IActionResult> DeletePet(long id)
    {
        var success = await _petService.DeletePetAsync(id);
        if (!success) return NotFound();
        return NoContent();
    }
}