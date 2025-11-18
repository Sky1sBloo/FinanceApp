using Microsoft.AspNetCore.Mvc;

namespace FinanceApp.Controllers;

public class SubscriptionsController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
