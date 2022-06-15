#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;

public class Dish
{
    [Key]
    public int DishId {get;set;}

    public string Name {get;set;}

    public string Chef {get;set;}
    public int Tastiness {get;set;}
    public int Calories {get;set;}
    public string Description {get;set;}
    public DateTime CreatedAt = DateTime.Now;
    public DateTime UpdatedAt = DateTime.Now;
}