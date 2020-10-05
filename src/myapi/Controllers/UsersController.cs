using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using myapi.DbContexts;
using myapi.Entities;

namespace myapi.Controllers
{
  [ApiController]
  [Route("api/users")]
  public class UsersController : ControllerBase
  {
    private readonly DemoDbContext _db;
    public UsersController(DemoDbContext db)
    {
      _db = db;
    }

    [HttpGet]
    public IEnumerable<User> Get()
    {
      // select * from users limit 10;
      var users = _db.Users.Take(20).ToArray();

      return users;
    }

    // TODO: Utilizar programación asíncrona y multihilo
    // TODO: Programar los métodos para buscar usuarios por id,
    //       crear un nuevo usuario, editar un usuario, eliminar un usuario
  }
}