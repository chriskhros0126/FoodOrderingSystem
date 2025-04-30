// ADMIN ONLY

using Microsoft.AspNetCore.Mvc;
using FoodOrderingSystem.Models;
using FoodOrderingSystem.Data;
using System.Collections.Generic;
using System.Linq;

namespace FoodOrderingSystem.Controllers

{
    public class MenuController : Controller
    {
        private readonly AppDbContext _context;

        public MenuController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var dishes = _context.Dishes.ToList();
            return View(dishes);        
        }

        public IActionResult Create() // GET AND POST
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Dish dish)
        {
            if (ModelState.IsValid)
            {
                _context.Dishes.Add(dish);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dish);
        }

        public IActionResult Edit(int id)
        {
            var dish = _context.Dishes.Find(id);
            return View(dish);
        }

        [HttpPost]
        public IActionResult Edit(Dish dish)
        {
            if (ModelState.IsValid)
            {
                _context.Dishes.Update(dish);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dish);
        }

        public IActionResult Delete(int id)
        {
            var dish = _context.Dishes.Find(id);
            return View(dish);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var dish = _context.Dishes.Find(id);
            if (dish != null)
                {
                    _context.Dishes.Remove(dish);
                    _context.SaveChanges();
                }            
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var dish = _context.Dishes.Find(id);
            return View(dish);
        }
    }
}
