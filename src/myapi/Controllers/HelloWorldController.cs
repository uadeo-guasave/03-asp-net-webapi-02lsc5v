using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace myapi.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class HelloWorldController : ControllerBase
  {
    private static readonly string[] Hellos = new[]
    {
        "Hola Mundo", "Hello World"
    };

    [HttpGet]
    public string GetHellos()
    {
      var hello = new { en="Hello World", es="Hola Mundo" };
      return hello.ToString();
    }
  }
}