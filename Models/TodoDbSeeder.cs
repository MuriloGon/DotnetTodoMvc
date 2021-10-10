using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DotnetTodoMvc.Models
{
  public class TodoDbSeeder
  {
    public static void Seed(IServiceProvider serviceProvider)
    {
      using var context = new TodoDbContext(
        serviceProvider.GetRequiredService<DbContextOptions<TodoDbContext>>()
      );

      // Verifica se possui algum elemento do db
      // Se tiver algum elemento sai retorna vazio para sair do método
      if (context.Todos.Any()) return;

      context.Todos.AddRange(
        new Todo{ Id=1, TaskName="Learn Asp.Net Core 5", IsComplete=false},
        new Todo{ Id=2, TaskName="Get a job", IsComplete=false}
      );
      context.SaveChanges();
      Console.WriteLine("Hi!");
    }
  }
}