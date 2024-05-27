using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ST10182111_2024POE.Data;
using ST10182111_2024POE.Models;

namespace ST10182111_2024POE.Controllers
{
    public class UserLeadController : Controller
    {
        private readonly ApplicationDBContext _context;

        public UserLeadController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: UserLead
        public async Task<IActionResult> Index()
        {
            return View(await _context.Users.ToListAsync());
        }

        // GET: UserLead/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userLeadEntity = await _context.Users
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (userLeadEntity == null)
            {
                return NotFound();
            }

            return View(userLeadEntity);
        }

        // GET: UserLead/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserLead/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserId,UserName,FirstName,LastName,ContactNumber,Email,LeadSource")] UserLeadEntity userLeadEntity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userLeadEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(userLeadEntity);
        }

        // GET: UserLead/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userLeadEntity = await _context.Users.FindAsync(id);
            if (userLeadEntity == null)
            {
                return NotFound();
            }
            return View(userLeadEntity);
        }

        // POST: UserLead/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserId,UserName,FirstName,LastName,ContactNumber,Email,LeadSource")] UserLeadEntity userLeadEntity)
        {
            if (id != userLeadEntity.UserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userLeadEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserLeadEntityExists(userLeadEntity.UserId))
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
            return View(userLeadEntity);
        }

        // GET: UserLead/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userLeadEntity = await _context.Users
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (userLeadEntity == null)
            {
                return NotFound();
            }

            return View(userLeadEntity);
        }

        // POST: UserLead/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userLeadEntity = await _context.Users.FindAsync(id);
            if (userLeadEntity != null)
            {
                _context.Users.Remove(userLeadEntity);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserLeadEntityExists(int id)
        {
            return _context.Users.Any(e => e.UserId == id);
        }
    }
}
