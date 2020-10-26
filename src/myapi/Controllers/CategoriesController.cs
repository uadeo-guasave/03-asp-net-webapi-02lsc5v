using Microsoft.AspNetCore.Mvc;
using myapi.DbContexts;

namespace myapi.Controllers
{
  [ApiController]
  [Route("api/categories")]
  public class CategoriesController : ControllerBase
  {
    private readonly DemoDbContext _db;
    public CategoriesController(DemoDbContext db)
    {
      _db = db;
    }
  }
}