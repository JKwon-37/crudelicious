#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;

public class Dish
{
    [Key]
    [Required(ErrorMessage = " is required!")]
    public int DishId {get;set;}
    [Required(ErrorMessage = " is required!")]
    public string Name {get;set;}
    [Required(ErrorMessage = " is required!")]
    public string Chef {get;set;}
    [Required(ErrorMessage = " is required!")]
    public int Tastiness {get;set;}
    [Required(ErrorMessage = " is required!")]
    public int Calories {get;set;}
    [Required(ErrorMessage = " is required!")]
    public string Description {get;set;}
    public DateTime CreatedAt = DateTime.Now;
    public DateTime UpdatedAt = DateTime.Now;
}