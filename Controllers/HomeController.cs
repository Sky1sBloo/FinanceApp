using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FinanceApp.Models;

using FinanceApp.Models.Entities;
using FinanceApp.Data;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using FinanceApp.Data.Types;

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
    public IActionResult CreateTransaction() => View();

    [HttpPost]
    public async Task<IActionResult> CreateTransaction(TransactionForm form)
    {
        if (!ModelState.IsValid)
        {
            return View(form);
        }

        var transaction = new Transaction
        {
            Name = form.Name,
            Amount = new Currency(form.Amount),
            Date = form.Date,
            Category = form.Category
        };
        dbContext.Add(transaction);
        await dbContext.SaveChangesAsync();
        return RedirectToAction("Index");
    }

    [HttpGet]
    public async Task<IActionResult> EditTransaction(Guid id)
    {
        var transaction = await dbContext.Transactions.FindAsync(id);
        if (transaction == null)
        {
            return NotFound();
        }

        var editForm = new TransactionEditForm
        {
            Id = transaction.Id,
            TransactionForm = new TransactionForm
            {
                Name = transaction.Name,
                Amount = transaction.Amount.Amount,
                Date = transaction.Date,
                Category = transaction.Category
            }
        };

        return View(editForm);
    }

    [HttpPost]
    public async Task<IActionResult> EditTransaction(Guid id, TransactionEditForm editForm)
    {
        if (editForm == null || id != editForm.Id)
        {
            return BadRequest();
        }

        if (!ModelState.IsValid)
        {
            return View(editForm);
        }

        var transaction = new Transaction
        {
            Id = id,
            Name = editForm.TransactionForm.Name,
            Amount = new Currency(editForm.TransactionForm.Amount),
            Date = editForm.TransactionForm.Date,
            Category = editForm.TransactionForm.Category
        };
        dbContext.Transactions.Update(transaction);
        await dbContext.SaveChangesAsync();
        return RedirectToAction("Index");
    }

    [HttpPost]
    public async Task<IActionResult> DeleteTransaction(Guid id)
    {
        var transaction = await dbContext.Transactions.FindAsync(id);
        if (transaction == null)
        {
            return NotFound();
        }

        dbContext.Transactions.Remove(transaction);
        await dbContext.SaveChangesAsync();
        return RedirectToAction("Index");
    }

    [HttpGet("api/transactions")]
    public IActionResult GetTransactions()
    {
        var transactions = dbContext.Transactions.ToList();
        return Json(transactions);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
