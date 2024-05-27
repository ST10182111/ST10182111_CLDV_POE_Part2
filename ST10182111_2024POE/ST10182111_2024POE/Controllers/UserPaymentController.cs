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
    public class UserPaymentController : Controller
    {
        private readonly ApplicationDBContext _context;

        public UserPaymentController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: UserPayment
        public async Task<IActionResult> Index()
        {
            return View(await _context.Payments.ToListAsync());
        }

        // GET: UserPayment/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userPaymentEntity = await _context.Payments
                .FirstOrDefaultAsync(m => m.user_Payment_ID == id);
            if (userPaymentEntity == null)
            {
                return NotFound();
            }

            return View(userPaymentEntity);
        }

        // GET: UserPayment/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserPayment/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("user_Payment_ID,MethodOfPayment")] UserPaymentEntity userPaymentEntity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userPaymentEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(userPaymentEntity);
        }

        // GET: UserPayment/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userPaymentEntity = await _context.Payments.FindAsync(id);
            if (userPaymentEntity == null)
            {
                return NotFound();
            }
            return View(userPaymentEntity);
        }

        // POST: UserPayment/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("user_Payment_ID,MethodOfPayment")] UserPaymentEntity userPaymentEntity)
        {
            if (id != userPaymentEntity.user_Payment_ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userPaymentEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserPaymentEntityExists(userPaymentEntity.user_Payment_ID))
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
            return View(userPaymentEntity);
        }

        // GET: UserPayment/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userPaymentEntity = await _context.Payments
                .FirstOrDefaultAsync(m => m.user_Payment_ID == id);
            if (userPaymentEntity == null)
            {
                return NotFound();
            }

            return View(userPaymentEntity);
        }

        // POST: UserPayment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userPaymentEntity = await _context.Payments.FindAsync(id);
            if (userPaymentEntity != null)
            {
                _context.Payments.Remove(userPaymentEntity);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserPaymentEntityExists(int id)
        {
            return _context.Payments.Any(e => e.user_Payment_ID == id);
        }
    }
}
