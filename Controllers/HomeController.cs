using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Crudelicious.Models;

namespace Crudelicious.Controllers;

public class HomeController : Controller
{
    private CrudeliciousContext _context;

    public HomeController(CrudeliciousContext context)
    {
        _context = context;
    }

    [HttpGet("")]
    public IActionResult Index()
    {
        List<Dish> AllDishes = _context.Dishes.ToList();
        return View("Index", AllDishes);
    }

    [HttpGet("dish/{id}")]
    public IActionResult Details(int id)
    {
        Dish? dish = _context.Dishes.FirstOrDefault(dish => dish.DishId == id);

        if (dish == null)
        {
            return RedirectToAction("Index");
        }
        return View("Details", dish);
    }

    [HttpGet("dish/new")]
    public IActionResult New()
    {
        return View("New");
    }

    [HttpPost("dish/create")]
    public IActionResult Create(Dish newDish)
    {
        if(ModelState.IsValid)
        {
            _context.Dishes.Add(newDish);
            _context.SaveChanges();
            return RedirectToAction("New");
        } else
        {
            return New();
        }
    }

    [HttpPost("dish/{id}/delete")]
    public IActionResult DeleteDish(int id)
    {
        Dish? dish = _context.Dishes.FirstOrDefault(dish => dish.DishId == id);

        if(dish != null)
        {
            _context.Dishes.Remove(dish);
            _context.SaveChanges();
        }
        return RedirectToAction("Index");
    }

    [HttpGet("dish/{id}/edit")]
    public IActionResult EditDish(int id)
    {
        Dish? dish = _context.Dishes.FirstOrDefault(dish => dish.DishId == id);
        if(dish != null)
        {
            return View("Edit", dish);
        }
        return RedirectToAction("Index");
    }

    [HttpPost("dish/{id}/update")]
    public IActionResult UpdateDish(Dish editDish, int id)
    {
        if(ModelState.IsValid)
        {
            Dish? dbDish = _context.Dishes.FirstOrDefault(dish => dish.DishId == id);
            if (dbDish != null)
            {
                dbDish.Chef = editDish.Chef;
                dbDish.Name = editDish.Name;
                dbDish.Tastiness = editDish.Tastiness;
                dbDish.Calories = editDish.Calories;
                dbDish.Description = editDish.Description;
                dbDish.UpdatedAt = DateTime.Now;

                _context.Dishes.Update(dbDish);
                _context.SaveChanges();
            }
            return Details(id);
        } else
        {
            return EditDish(id);
        }
    }

    public IActionResult Privacy()
    {
        return View();
    }

}
