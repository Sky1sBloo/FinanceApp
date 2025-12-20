using Microsoft.AspNetCore.Mvc;
using FinanceApp.Models.Entities;
using FinanceApp.Data;

namespace FinanceApp.Controllers;

public class SubscriptionsController : Controller
{
    private readonly ApplicationDbContext dbContext;

    public SubscriptionsController(ApplicationDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        await dbContext.SaveChangesAsync();
        var subscriptions = dbContext.Subscriptions.ToList();

        var viewModel = new SubscriptionIndexViewModel
        {
            Subscriptions = subscriptions
        };
        return View(viewModel);
    }

    [HttpGet]
    public IActionResult Create() => View();
    [HttpPost]
    public async Task<IActionResult> Create(SubscriptionForm subscriptionForm)
    {
        var subscription = new Subscription
        {
            Name = subscriptionForm.Name,
            Category = subscriptionForm.Category,
            Amount = subscriptionForm.Amount,
            Frequency = subscriptionForm.Frequency,
            StartDate = subscriptionForm.StartDate,
            EndDate = subscriptionForm.EndDate
        };
        return View();
    }
}
