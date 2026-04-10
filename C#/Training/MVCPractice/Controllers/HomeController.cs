using System.Diagnostics;
//using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using MVCPractice.Models;

namespace MVCPractice.Controllers;

[Route("Home")]
public class HomeController : Controller
{   
    
    // private readonly ILogger<HomeController> _logger;

    // public HomeController(ILogger<HomeController> logger)
    // {
    //     _logger = logger;
    // }
    [Route("Index")]
    [Route("")]
    public IActionResult Index()
    {
        return View();
    }

    [Route("Privacy")]
    public IActionResult Privacy()
    {
        return View();
    }

    [Route("About")]
    public IActionResult About()
    {
        return View();
    }

    [Route("Error")]
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
