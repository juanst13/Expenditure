using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Expenditure.Web.Data.Entities;

namespace Expenditure.Web.Controllers
{
    public class ExpendituresController : Controller
    {
        private readonly DataContext _context;

        public ExpendituresController(DataContext context)
        {
            _context = context;
        }

        // GET: Expenditures
        public async Task<IActionResult> Index()
        {
            return View(await _context.Expenses.ToListAsync());
        }

        // GET: Expenditures/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expenditureEntity = await _context.Expenses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (expenditureEntity == null)
            {
                return NotFound();
            }

            return View(expenditureEntity);
        }

        // GET: Expenditures/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Expenditures/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ExpenseType,ExpenditureDate,ExpenseValue,PhotoPath")] ExpenditureEntity expenditureEntity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(expenditureEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(expenditureEntity);
        }

        // GET: Expenditures/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expenditureEntity = await _context.Expenses.FindAsync(id);
            if (expenditureEntity == null)
            {
                return NotFound();
            }
            return View(expenditureEntity);
        }

        // POST: Expenditures/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ExpenseType,ExpenditureDate,ExpenseValue,PhotoPath")] ExpenditureEntity expenditureEntity)
        {
            if (id != expenditureEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(expenditureEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExpenditureEntityExists(expenditureEntity.Id))
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
            return View(expenditureEntity);
        }

        // GET: Expenditures/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expenditureEntity = await _context.Expenses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (expenditureEntity == null)
            {
                return NotFound();
            }

            return View(expenditureEntity);
        }

        // POST: Expenditures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var expenditureEntity = await _context.Expenses.FindAsync(id);
            _context.Expenses.Remove(expenditureEntity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExpenditureEntityExists(int id)
        {
            return _context.Expenses.Any(e => e.Id == id);
        }
    }
}
