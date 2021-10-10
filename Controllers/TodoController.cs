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

    [HttpGet]
    public IActionResult Create() {
      return View();
    }

    [HttpPost]
    public IActionResult Create(Todo todo) {
      var todoId = _dbcontext.Todos.Select(x => x.Id).Max() + 1;
      todo.Id = todoId;
      _dbcontext.Todos.Add(todo);
      _dbcontext.SaveChanges();

      return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Edit(int id) {
      var todo = _dbcontext.Todos.Find(id);
      return View(todo);
    }

    [HttpPost]
    public IActionResult Edit(Todo todo) {
      _dbcontext.Todos.Update(todo);
      _dbcontext.SaveChanges();
      return RedirectToAction("Index");
    }

  }
}