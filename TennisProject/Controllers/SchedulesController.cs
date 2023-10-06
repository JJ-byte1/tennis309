using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TennisProject.Models;

namespace TennisProject.Controllers
{
    public class SchedulesController : Controller
    {
        private readonly AspnetTennisProject53bc9b9d9d6a45d484292a2761773502Context _context;

        public SchedulesController(AspnetTennisProject53bc9b9d9d6a45d484292a2761773502Context context)
        {
            _context = context;
        }

        // GET: Schedules
        public async Task<IActionResult> Index()
        {
              return _context.Schedules != null ? 
                          View(await _context.Schedules.ToListAsync()) :
                          Problem("Entity set 'AspnetTennisProject53bc9b9d9d6a45d484292a2761773502Context.Schedules'  is null.");
        }



        // GET: Schedules
        public async Task<IActionResult> schedules(string Id)
        {

            List<Schedule> schedules = await _context.Schedules.ToListAsync();

            List<Schedule> coachSchedules = new List<Schedule>();

            foreach (var scheduledEvent in schedules)
            {
                
                if(scheduledEvent.UserId == Id)
                    coachSchedules.Add(scheduledEvent);

            }
    
            schedules = coachSchedules.ToList();

            return _context.Schedules != null ?
                        View(schedules) :
                        Problem("Entity set 'AspnetTennisProject53bc9b9d9d6a45d484292a2761773502Context.Schedules'  is null.");
        }



        // GET: Schedules/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Schedules == null)
            {
                return NotFound();
            }

            var schedule = await _context.Schedules
                .FirstOrDefaultAsync(m => m.SessionId == id);
            if (schedule == null)
            {
                return NotFound();
            }

            return View(schedule);
        }

        // GET: Schedules/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Schedules/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SessionId,UserId,ScheduleItem,Date")] Schedule schedule)
        {
            if (ModelState.IsValid)
            {
                schedule.SessionId = Guid.NewGuid();
                _context.Add(schedule);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(schedule);
        }

        // GET: Schedules/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Schedules == null)
            {
                return NotFound();
            }

            var schedule = await _context.Schedules.FindAsync(id);
            if (schedule == null)
            {
                return NotFound();
            }
            return View(schedule);
        }

        // POST: Schedules/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("SessionId,UserId,ScheduleItem,Date")] Schedule schedule)
        {
            if (id != schedule.SessionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(schedule);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ScheduleExists(schedule.SessionId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(schedule);
        }

        // GET: Schedules/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Schedules == null)
            {
                return NotFound();
            }

            var schedule = await _context.Schedules
                .FirstOrDefaultAsync(m => m.SessionId == id);
            if (schedule == null)
            {
                return NotFound();
            }

            return View(schedule);
        }

        // POST: Schedules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Schedules == null)
            {
                return Problem("Entity set 'AspnetTennisProject53bc9b9d9d6a45d484292a2761773502Context.Schedules'  is null.");
            }
            var schedule = await _context.Schedules.FindAsync(id);
            if (schedule != null)
            {
                _context.Schedules.Remove(schedule);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ScheduleExists(Guid id)
        {
          return (_context.Schedules?.Any(e => e.SessionId == id)).GetValueOrDefault();
        }
    }
}
