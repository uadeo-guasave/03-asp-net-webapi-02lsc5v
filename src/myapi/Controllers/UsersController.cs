using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using myapi.DbContexts;
using myapi.Entities;

namespace myapi.Controllers
{
  [ApiController]
  // https://localhost:5001/api/users
  [Route("api/users")]
  public class UsersController : ControllerBase
  {
    private readonly DemoDbContext _db;
    public UsersController(DemoDbContext db)
    {
      _db = db;
    }

    private bool Exists(int id)
    {
      return _db.Users.Any(u => u.Id == id);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> Get()
    {
      // select * from users limit 10;
      var users = await _db.Users.Where(u => u.Id > 1000).ToArrayAsync();
      if (users.Length == 0)
      {
        return NotFound();
      }

      return users;
    }

    // https://localhost:5001/api/users/10
    [HttpGet("{id}")]
    public async Task<ActionResult<User>> GetById(int id)
    {
      var user = await _db.Users.FindAsync(id);
      if (user == null)
      {
        return NotFound();
      }

      return user;
    }

    [HttpPost]
    [Route("validate")]
    public async Task<ActionResult<string>> NameExists([FromForm] string username)
    {
      var user = await _db.Users.AnyAsync(u => u.Name == username);
      if (user)
      {
        return UnprocessableEntity();
      }

      return $"{username} is available.";
    }
    // CRUD: Create, Read, Update & Delete

    [HttpPost]
    [Route("create")]
    public async Task<ActionResult<User>> Create([FromBody] User newUser)
    {
      var test = await _db.Users.AnyAsync(u => 
        u.Name == newUser.Name || u.Email == newUser.Email);
      if (test)
      {
        return BadRequest();
      }

      _db.Users.Add(newUser);
      await _db.SaveChangesAsync();

      return CreatedAtAction(nameof(GetById), new { id = newUser.Id }, newUser);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> SaveChanges(int id, [FromBody] User modifiedUser)
    {
      if (id != modifiedUser.Id)
      {
        return BadRequest();
      }

      _db.Entry(modifiedUser).State = EntityState.Modified;

      try
      {
        await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!Exists(id))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }

      return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<User>> Delete(int id)
    {
      var user = await _db.Users.FindAsync(id);
      if (user == null)
      {
        return NotFound();
      }

      _db.Users.Remove(user);
      await _db.SaveChangesAsync();

      return user;
    }
  }
}