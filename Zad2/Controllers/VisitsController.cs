using Microsoft.AspNetCore.Mvc;
using Zad2.Models;

namespace Zad2.Controllers;

[Route("api/visits")]
[ApiController]
public class VisitsController : ControllerBase
{
    private static readonly List<Visit> _visits = new();

    [HttpGet("{idAnimal:int}")]
    public IActionResult GetVisitsByIdAnimal(int idAnimal)
    {
        var visitsByAnimal = _visits.Where(visit => visit.IdAnimal== idAnimal).ToList();

        if (visitsByAnimal == null)
        {
            return NotFound($"Visits with animalId was not found");
        }

        return Ok(visitsByAnimal);
    }
    
    [HttpPost]
    public IActionResult CreateVisit(Visit visit)
    {
        var animal = AnimalsController._animals.FirstOrDefault(animal => animal.Id == visit.IdAnimal);

        if (animal == null)
        {
            return NotFound($"Not found animal with id {visit.IdAnimal}");
        }
        
        _visits.Add(visit);
        return StatusCode(StatusCodes.Status201Created);
    }
}