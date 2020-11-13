using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shop.Data;
using Shop.Models;

namespace Shop.Controllers
{
  [Route("v1/seeder")]
  public class SeederBasicController : Controller
  {
    [HttpGet]
    [Route("")]
    public async Task<ActionResult<dynamic>> Get([FromServices] DataContext context)
    {
      var employee = new User { Id = 1, Username = "teste", Password = "1234567", Role = "employee" };
      var manager = new User { Id = 2, Username = "Shilton", Password = "1234567", Role = "manager" };
      var category = new Category { Id = 1, Title = "Informática" };
      var product = new Product { Id = 1, Category = category, Title = "Mouse", Price = 79, Description = "Mouse Gamer" };

      context.Users.Add(employee);
      context.Users.Add(manager);
      context.Categories.Add(category);
      context.Products.Add(product);

      try
      {
        await context.SaveChangesAsync();

        return Ok(new
        {
          message = "Dados configurados para teste."
        });
      }
      catch
      {
        return BadRequest(new { message = "Não foi possivel gerar a carga inicial dos dados." });
      }

    }
  }
}