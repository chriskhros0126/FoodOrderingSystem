using Microsoft.AspNetCore.Mvc;
using FoodOrderingSystem.Models;
using System.Collections.Generic;
using System.Linq;

namespace FoodOrderingSystem.APIs
{
    [ApiController]
    [Route("api/[controller]")]
    public class MenuApiController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<Dish>> Get()
        {
            // Normally, use a DB. For demo: return static data.
            return Ok(MenuControllerStatic.Menu);
        }
    }

    public static class MenuControllerStatic
    {
        public static List<Dish> Menu = new List<Dish>
        {
            new Dish { Id = 1, Name = "Nasi Lemak", Price = 12.50m, IsAvailable = true },
            new Dish { Id = 2, Name = "Mee Goreng", Price = 10.00m, IsAvailable = true }
        };
    }
}
