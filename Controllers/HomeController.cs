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

        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

}
