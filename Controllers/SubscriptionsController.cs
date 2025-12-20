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
    public async Task<IActionResult> Index(string searchTerm = "")
    {
        await dbContext.SaveChangesAsync();
        var subscriptions = dbContext.Subscriptions.AsQueryable();
        if (!string.IsNullOrWhiteSpace(searchTerm))
        {
            subscriptions = subscriptions.Where(s => s.Name.Contains(searchTerm));
            ViewData["searchTerm"] = searchTerm;
        }

        var viewModel = new SubscriptionIndexViewModel
        {
            Subscriptions = subscriptions.ToList()
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
        dbContext.Subscriptions.Add(subscription);
        await dbContext.SaveChangesAsync();
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Edit(Guid id)
    {
        var subscription = dbContext.Subscriptions.Find(id);
        if (subscription == null)
        {
            return NotFound();
        }
        SubscriptionEditForm editForm = new SubscriptionEditForm
        {
            Id = id,
            SubscriptionForm = new SubscriptionForm
            {
                Name = subscription.Name,
                Category = subscription.Category,
                Amount = subscription.Amount,
                Frequency = subscription.Frequency,
                StartDate = subscription.StartDate,
                EndDate = subscription.EndDate
            }
        };
        return View(editForm);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Guid id, SubscriptionEditForm editForm)
    {
        var subscription = new Subscription
        {
            Id = id,
            Name = editForm.SubscriptionForm.Name,
            Category = editForm.SubscriptionForm.Category,
            Amount = editForm.SubscriptionForm.Amount,
            Frequency = editForm.SubscriptionForm.Frequency,
            StartDate = editForm.SubscriptionForm.StartDate,
            EndDate = editForm.SubscriptionForm.EndDate
        };
        dbContext.Subscriptions.Update(subscription);
        await dbContext.SaveChangesAsync();
        return RedirectToAction("Index");
    }

    [HttpPost]
    public async Task<IActionResult> Delete(Guid id)
    {
        var subscription = dbContext.Subscriptions.Find(id);
        if (subscription == null)
        {
            return NotFound();
        }
        dbContext.Subscriptions.Remove(subscription);
        await dbContext.SaveChangesAsync();
        return RedirectToAction("Index");
    }
}
