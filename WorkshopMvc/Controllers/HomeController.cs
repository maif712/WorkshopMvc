using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using WorkshopMvc.Data;
using WorkshopMvc.Models;

namespace WorkshopMvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var workshops = _context.Workshops.Include(w => w.Participants).ToList();

            return View(workshops);
        }

    }
}
