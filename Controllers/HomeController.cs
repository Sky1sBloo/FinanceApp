using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FinanceApp.Models;

using FinanceApp.Models.Entities;
using FinanceApp.Data;

namespace FinanceApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ApplicationDbContext dbContext;

    public HomeController(ILogger<HomeController> logger, ApplicationDbContext dbContext)
    {
        _logger = logger;
        this.dbContext = dbContext;
    }

    public IActionResult Index()
    {
        var transactions = dbContext.Transactions.ToList();
        var viewModel = new TransactionIndexViewModel
        {
            Transactions = transactions
        };
        return View(viewModel);
    }

    [HttpGet]
    public IActionResult CreateTransactions() => View();

    [HttpPost]
    public async Task<IActionResult> CreateTransactions(TransactionForm form)
    {
        if (!ModelState.IsValid)
        {
            return View(form);
        }

        var transaction = new Transaction
        {
            Name = form.Name,
            Amount = form.Amount,
            Date = form.Date,
            Category = form.Category
        };
        dbContext.Add(transaction);
        await dbContext.SaveChangesAsync();
        return RedirectToAction("Index");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
