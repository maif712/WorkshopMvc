using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WorkshopMvc.Data;
using WorkshopMvc.Models;

namespace WorkshopMvc.Controllers
{
    public class WorkshopController : Controller
    {
        private readonly ApplicationDbContext _context;

        public WorkshopController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var workshops = _context.Workshops.Include(w => w.Participants).ToList();
            return View(workshops);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Workshop workshop)
        {
            if (ModelState.IsValid)
            {
                _context.Workshops.Add(workshop);
                _context.SaveChanges();
                TempData["success"] = "Workshop created successfully.";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(int id)
        {
            var workshop = _context.Workshops.Find(id);
            return View(workshop);
        }

        [HttpPost]
        public IActionResult Edit(Workshop workshop)
        {
            if (ModelState.IsValid)
            {
                _context.Workshops.Update(workshop);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var workshopToDelete = _context.Workshops.Find(id);
            if (workshopToDelete != null)
            {
                _context.Workshops.Remove(workshopToDelete);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return NotFound();
        }
    }
}
