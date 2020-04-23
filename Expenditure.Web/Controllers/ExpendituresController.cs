using Expenditure.Web.Data.Entities;
using Expenditure.Web.Helpers;
using Expenditure.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Expenditure.Web.Controllers
{
    public class ExpendituresController : Controller
    {
        private readonly DataContext _context;
        private readonly IImageHelper _imageHelper;
        private readonly IConverterHelper _converterHelper;

        public ExpendituresController(
            DataContext context,
            IImageHelper imageHelper,
            IConverterHelper converterHelper)
        {
            _context = context;
            _imageHelper = imageHelper;
            _converterHelper = converterHelper;
        }


        // GET: Expenditures
        public async Task<IActionResult> Index()
        {
            return View(await _context.Expenses.OrderBy(t => t.ExpenditureDate).ToListAsync());

        }

        // GET: Expenditures/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ExpenditureEntity expenditureEntity = await _context.Expenses
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ExpenditureViewModel model)
        {
            if (ModelState.IsValid)
            {
                string path = string.Empty;

                if (model.PhotoFile != null)
                {
                    path = await _imageHelper.UploadImageAsync(model.PhotoFile, "Expenses");
                }

                ExpenditureEntity expenditureEntity = _converterHelper.ToExpenditureEntity(model, path, true);
                _context.Add(expenditureEntity);

                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    if (ex.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "Already there is a record with the same plaque.");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, ex.InnerException.Message);
                    }
                }

            }
            return View(model);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ExpenditureEntity expenditureEntity = await _context.Expenses.FindAsync(id);
            if (expenditureEntity == null)
            {
                return NotFound();
            }

            ExpenditureViewModel expenditureViewModel = _converterHelper.ToExpenditureViewModel(expenditureEntity);
            return View(expenditureViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ExpenditureViewModel model)
        {

            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                string path = model.PhotoPath;
                string UpdateExpenseType = model.ExpenseType;
                DateTime UpdateExpenditureDate = model.ExpenditureDate;
                    int UpdateExpenseValue = model.ExpenseValue;


                if (model.PhotoFile != null)
                {
                    path = await _imageHelper.UploadImageAsync(model.PhotoFile, "Expenses");
                }

                ExpenditureEntity expenditureEntity = _converterHelper.ToExpenditureEntity(model, path, false);
                _context.Update(expenditureEntity);

                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    if (ex.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "Already there is a record with the same plaque.");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, ex.InnerException.Message);
                    }
                }

            }
            return View(model);
        }

        // GET: Expenditures/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ExpenditureEntity expenditureEntity = await _context.Expenses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (expenditureEntity == null)
            {
                return NotFound();
            }

            _context.Expenses.Remove(expenditureEntity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
