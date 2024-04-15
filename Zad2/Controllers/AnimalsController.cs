using Microsoft.AspNetCore.Mvc;
using Zad2.Models;

namespace Zad2.Controllers;

[Route("api/animals")]
[ApiController]
public class AnimalsController : ControllerBase
{
    public static readonly List<Animal> _animals = new()
    {
        new Animal { Id = 1, Name = "Kanita", Type = "Cat", Weight = 5.0f, ColorCoat = "Grey" },
        new Animal { Id = 2, Name = "Neptun", Type = "Cat", Weight = 4.5f, ColorCoat = "Brown" },
        new Animal { Id = 3, Name = "Kaizen", Type = "Dog", Weight = 42.0f, ColorCoat = "Redhead" },
        new Animal { Id = 4, Name = "Fluffy", Type = "Canary", Weight = 0.1f, ColorCoat = "Yellow" },
    };

    [HttpGet]
    public IActionResult GetAnimals()
    {
        return Ok(_animals);
    }
    
    [HttpGet("{id:int}")]
    public IActionResult GetAnimal(int id)
    {
        var animal = _animals.FirstOrDefault(animal => animal.Id == id);
        if (animal == null)
        {
            return NotFound($"Animal with id {id} was not found");
        }
        
        return Ok(animal);
    }
    
    [HttpPost]
    public IActionResult CreateAnimal(Animal animal)
    {
        _animals.Add(animal);
        return StatusCode(StatusCodes.Status201Created);
    }
    
    [HttpPut("{id:int}")]
    public IActionResult UpdateAnimal(int id, Animal animal)
    {
        var animalToEdit= _animals.FirstOrDefault(anim => anim.Id == id);

        if (animalToEdit == null)
        {
            return NotFound($"Animal with id {id} was not found");
        }
        
        _animals.Remove(animalToEdit);
        _animals.Add(animal);
        return NoContent();
    }
    
    [HttpDelete("{id:int}")]
    public IActionResult DeleteAnimal(int id)
    {
        var animalToEdit = _animals.FirstOrDefault(anim => anim.Id == id);
        if (animalToEdit == null)
        {
            return NotFound($"Animal with id {id} was not found");
        }

        _animals.Remove(animalToEdit);
        return NoContent();
    }
}