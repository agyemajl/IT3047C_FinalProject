using Microsoft.AspNetCore.Mvc;

namespace IT3047C_FinalProject.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
