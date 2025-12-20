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
    public IActionResult Index()
    {
        var subscriptions = dbContext.Subscriptions.ToList();
        var viewModel = new SubscriptionIndexViewModel
        {
            Form = new SubscriptionForm(),
            Subscriptions = subscriptions
        };

        return View(viewModel);
    }

    [HttpPost]
    public async Task<IActionResult> Index(SubscriptionIndexViewModel subscriptionViewModel)
    {
        string subscriptionName = "Subscription";
        if (subscriptionViewModel.Form.Name != null)
        {
            subscriptionName = subscriptionViewModel.Form.Name;
        }
        var subscription = new Subscription
        {
            Name = subscriptionName,
            Category = subscriptionViewModel.Form.Category,
            Amount = subscriptionViewModel.Form.Amount,
            Frequency = subscriptionViewModel.Form.Frequency,
            StartDate = subscriptionViewModel.Form.StartDate,
            EndDate = subscriptionViewModel.Form.EndDate
        };
        await dbContext.Subscriptions.AddAsync(subscription);
        await dbContext.SaveChangesAsync();
        var subscriptions = dbContext.Subscriptions.ToList();

        var viewModel = new SubscriptionIndexViewModel
        {
            Form = subscriptionViewModel.Form,
            Subscriptions = subscriptions
        };
        return View(viewModel);
    }
}
