using Microsoft.AspNetCore.Mvc;
using FinanceApp.Models.Entities;
using FinanceApp.Data;

public class GoalsController : Controller
{
    private readonly ApplicationDbContext dbContext;

    public GoalsController(ApplicationDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    [HttpGet]
    public async Task<IActionResult> Index(string searchTerm = "")
    {
        var goals = dbContext.Goals.AsQueryable();
        if (!string.IsNullOrWhiteSpace(searchTerm))
        {
            goals = goals.Where(s => s.Name.Contains(searchTerm));
            ViewData["searchTerm"] = searchTerm;
        }

        var viewModel = new GoalsIndexViewModel
        {
            Goals = goals.ToList()
        };
        return View(viewModel);
    }

    [HttpGet]
    public IActionResult Create() => View();
    [HttpPost]
    public async Task<IActionResult> Create(GoalsForm goalsForm)
    {
        if (!ModelState.IsValid)
        {
            return View(goalsForm);
        }

        var goals = new Goals
        {
            Name = goalsForm.Name,
            TargetAmount = goalsForm.TargetAmount,
            Deadline = goalsForm.Deadline,
            PriorityLevel = goalsForm.PriorityLevel
        };
        dbContext.Goals.Add(goals);
        await dbContext.SaveChangesAsync();
        return RedirectToAction("Index");
    }

    [HttpGet]
    public async Task<IActionResult> Edit(Guid id)
    {
        var goals = await dbContext.Goals.FindAsync(id);
        if (goals == null)
        {
            return NotFound();
        }
        GoalsEditForm editForm = new GoalsEditForm
        {
            Id = id,
            GoalsForm = new GoalsForm
            {
                Name = goals.Name,
                TargetAmount = goals.TargetAmount,
                Deadline = goals.Deadline,
                PriorityLevel = goals.PriorityLevel
            }
        };
        return View(editForm);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Guid id, GoalsEditForm editForm)
    {
        if (editForm == null || id != editForm.Id)
        {
            return BadRequest();
        }

        if (!ModelState.IsValid)
        {
            return View(editForm);
        }

        var goals = new Goals
        {
            Id = id,
            Name = editForm.GoalsForm.Name,
            TargetAmount = editForm.GoalsForm.TargetAmount,
            Deadline = editForm.GoalsForm.Deadline,
            PriorityLevel = editForm.GoalsForm.PriorityLevel
        };
        dbContext.Goals.Update(goals);
        await dbContext.SaveChangesAsync();
        return RedirectToAction("Index");
    }

    [HttpPost]
    public async Task<IActionResult> Delete(Guid id)
    {
        var goals = await dbContext.Goals.FindAsync(id);
        if (goals == null)
        {
            return NotFound();
        }
        dbContext.Goals.Remove(goals);
        await dbContext.SaveChangesAsync();
        return RedirectToAction("Index");
    }
}
