
using Microsoft.AspNetCore.Mvc;

public class GoalsController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}