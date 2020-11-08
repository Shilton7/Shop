using Microsoft.AspNetCore.Mvc;

namespace Shop.Controllers
{
  [Route("categories")]

  public class CategoryController : ControllerBase
  {
    [HttpGet]
    [Route("")]
    public string Get()
    {
      return "Get";
    }

    [HttpGet]
    [Route("{id:int}")]
    public string GetById(int id)
    {
      return "id:" + id.ToString();
    }

    [HttpPost]
    [Route("")]
    public string Post()
    {
      return "Post";
    }

    [HttpPut]
    [Route("")]
    public string Put()
    {
      return "Put";
    }

    [HttpDelete]
    [Route("")]
    public string Delete()
    {
      return "Delete";
    }

  }
}