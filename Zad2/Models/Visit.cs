namespace Zad2.Models;

public class Visit
{
    public int Id { get; set; }
    public DateTime VisitDate { get; set; }
    public int IdAnimal { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
}