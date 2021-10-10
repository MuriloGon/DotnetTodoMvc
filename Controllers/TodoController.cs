using System.Linq;
using DotnetTodoMvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotnetTodoMvc.Controllers
{
  public class TodoController : Controller
  {
    public readonly TodoDbContext _dbcontext;

    public TodoController(TodoDbContext dbContext)
    {
      _dbcontext = dbContext;
    }

    [HttpGet]
    public IActionResult Index()
    {
      var todos = _dbcontext.Todos.ToList();
      return View(todos);
    }

  }
}