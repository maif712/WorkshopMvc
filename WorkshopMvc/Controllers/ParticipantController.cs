using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WorkshopMvc.Data;
using WorkshopMvc.Models;

namespace WorkshopMvc.Controllers
{
    public class ParticipantController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ParticipantController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Create(int workshopId)
        {
            ViewBag.WorkshopId = workshopId;
            return View();
        }

        [HttpPost]
        public IActionResult Create(Participant participant)
        {
            // Becuase we are using hidden input in order to send the workshopId, we need to validate the id beacause the user can cahange the workshopId
            var isWorkshopIdValid = _context.Workshops.Any(w => w.Id == participant.WorkshopId);
            if (!isWorkshopIdValid)
            {
                ModelState.AddModelError("", "Workshop id is not valid");
                return View();
            }

            if(ModelState.IsValid)
            {
                _context.Participants.Add(participant);
                _context.SaveChanges();
                TempData["success"] = "Participant added successfully.";
                return RedirectToAction("Index", "Workshop");
            }

            ViewBag.WorkshopId = participant.WorkshopId;
            return View();
        }

        public IActionResult Edit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var participant = _context.Participants.Find(id);

            if (participant == null)
            {
                return NotFound();
            }

            return View(participant);
        }

        [HttpPost]
        public IActionResult Edit(Participant participant)
        {
            // Becuase we are using hidden input in order to send the workshopId, we need to validate the id beacause the user can cahange the workshopId
            var isWorkshopIdValid = _context.Workshops.Any(w => w.Id == participant.WorkshopId);
            if (!isWorkshopIdValid)
            {
                ModelState.AddModelError("", "Workshop id is not valid");
                return View();
            }
            if (ModelState.IsValid)
            {
                _context.Participants.Update(participant);
                _context.SaveChanges();
                TempData["success"] = "Participant edited successfully.";
                return RedirectToAction("Index", "Workshop");
            }
            ViewBag.WorkshopId = participant.WorkshopId;
            return View();
        }

        [HttpPost]
        public IActionResult Confirmed(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var participant = _context.Participants.Find(id);
            if (participant == null)
            {
                return NotFound();
            }
            participant.Status = "confirmed";
            _context.SaveChanges();
            return RedirectToAction("Index", "Workshop");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            if (id == 0) return NotFound();

            var participantToDelete = _context.Participants.Find(id);
            if (participantToDelete == null)
            {
                return NotFound();
            }

            _context.Participants.Remove(participantToDelete);
            _context.SaveChanges();
            TempData["success"] = "Participant deleted successfully.";
            return RedirectToAction("Index", "Workshop");
        }
    }
}
