using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop.Data;
using Shop.Models;
using System;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using Shop.Services;

namespace Shop.Controllers
{
  [Route("v1/users")]

  public class UserController : ControllerBase
  {
    [HttpGet]
    [Route("")]
    [Authorize(Roles = "manager")]
    public async Task<ActionResult<List<User>>> Get(
      [FromServices] DataContext context)
    {
      var users = await context
          .Users
          .AsNoTracking()
          .ToListAsync();

      return Ok(users);
    }

    [HttpPost]
    [Route("")]
    [AllowAnonymous]
    public async Task<ActionResult<List<User>>> Post(
    [FromBody] User model,
    [FromServices] DataContext context)
    {

      if (!ModelState.IsValid)
        return BadRequest(ModelState);

      try
      {
        context.Users.Add(model);
        await context.SaveChangesAsync();
        return Ok(model);
      }
      catch
      {
        return BadRequest(new { message = "Não foi possível cadastrar o usuário" });
      }

    }

    [HttpPut]
    [Route("{id:int}")]
    [Authorize]
    public async Task<ActionResult<List<User>>> Put(
      int id,
      [FromBody] User model,
      [FromServices] DataContext context)
    {
      if (id != model.Id)
        return NotFound(new { message = "Usuário não encontrado" });

      if (!ModelState.IsValid)
        return BadRequest(ModelState);

      try
      {
        context.Entry<User>(model).State = EntityState.Modified;
        await context.SaveChangesAsync();
        return Ok(model);
      }
      catch (DbUpdateConcurrencyException)
      {
        return BadRequest(new { message = "Este registro já foi atualizado" });
      }
      catch (Exception)
      {
        return BadRequest(new { message = "Não foi possível atualizar os dados do usuário" });
      }

    }

    [HttpPost]
    [Route("login")]
    [AllowAnonymous]
    public async Task<ActionResult<dynamic>> Authenticate(
                [FromBody] User model,
                [FromServices] DataContext context)
    {

      var user = await context.Users
          .AsNoTracking()
          .Where(x => x.Username == model.Username && x.Password == model.Password)
          .FirstOrDefaultAsync();

      if (user == null)
        return NotFound(new { message = "Usuário ou senha inválidos" });

      var token = TokenService.GenerateToken(user);

      return new
      {
        user = user,
        token = token
      };

    }
  }

}