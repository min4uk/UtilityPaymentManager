using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UtilityPaymentManager.Models;

namespace UtilityPaymentManager.Controllers
{
    public class CountersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CountersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Counters billing
        public async Task<IActionResult> PaymentIndex()
        {
			return _context.Counters != null ?
						  View(await _context.Counters.ToListAsync()) :
						  Problem("Entity set 'ApplicationDbContext.Counters'  is null.");
		}

        // POST: Pay
        [HttpPost]
		public async Task<IActionResult> Pay([Bind("PaidCounterId,PaidCounterName,PreviousNumber,NewNumber,ChangeAmount,PaidCounterPrice,PaidCounterSum")] PaidCounter paidCounter)
		{
			if (ModelState.IsValid)
			{
				_context.Add(paidCounter);
				await _context.SaveChangesAsync();
                return PartialView("PaidCounterPartialDetail", await _context.PaidCounters.ToListAsync() );
			}
			return View(paidCounter);
		}

		// RemovePaidCounter
		public async Task<IActionResult> RemovePaidCounter(int id)
		{
			if (_context.PaidCounters == null)
			{
				return Problem("Entity set 'ApplicationDbContext.Counters'  is null.");
			}
			var paidCounter = await _context.PaidCounters.FindAsync(id);
			if (paidCounter != null)
			{
				_context.PaidCounters.Remove(paidCounter);
			}

			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(PaymentIndex));
		}

		// GET: Counters
		public async Task<IActionResult> Index()
        {
              return _context.Counters != null ? 
                          View(await _context.Counters.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Counters'  is null.");
        }

        // GET: Counters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Counters == null)
            {
                return NotFound();
            }

            var counter = await _context.Counters
                .FirstOrDefaultAsync(m => m.CounterId == id);
            if (counter == null)
            {
                return NotFound();
            }

            return View(counter);
        }

        // GET: Counters/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Counters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CounterId,Name,CurrentNumber,Price")] Counter counter)
        {
            if (ModelState.IsValid)
            {
                _context.Add(counter);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(counter);
        }

        // GET: Counters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Counters == null)
            {
                return NotFound();
            }

            var counter = await _context.Counters.FindAsync(id);
            if (counter == null)
            {
                return NotFound();
            }
            return View(counter);
        }

        // POST: Counters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CounterId,Name,CurrentNumber,Price")] Counter counter)
        {
            if (id != counter.CounterId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(counter);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CounterExists(counter.CounterId))
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
            return View(counter);
        }

        // GET: Counters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Counters == null)
            {
                return NotFound();
            }

            var counter = await _context.Counters
                .FirstOrDefaultAsync(m => m.CounterId == id);
            if (counter == null)
            {
                return NotFound();
            }

            return View(counter);
        }

        // POST: Counters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Counters == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Counters'  is null.");
            }
            var counter = await _context.Counters.FindAsync(id);
            if (counter != null)
            {
                _context.Counters.Remove(counter);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CounterExists(int id)
        {
          return (_context.Counters?.Any(e => e.CounterId == id)).GetValueOrDefault();
        }
    }
}
