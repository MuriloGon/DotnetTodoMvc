using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotnetTodoMvc.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace DotnetTodoMvc
{
  public class Program
  {
    public static void Main(string[] args)
    {
      // CreateHostBuilder(args).Build().Run();
      var host = CreateHostBuilder(args).Build();

      using (var scope = host.Services.CreateScope())
      {
        var services = scope.ServiceProvider;
        TodoDbSeeder.Seed(services);
      }

      host.Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
              webBuilder.UseStartup<Startup>();
            });
  }
}
