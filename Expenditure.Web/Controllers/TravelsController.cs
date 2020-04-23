using Expenditure.Web.Data.Entities;
using Expenditure.Web.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Expenditure.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.View;

namespace Expenditure.Web.Controllers
{
    public class TravelsController : Controller
    {
        private readonly DataContext _context;
        private readonly IImageHelper _imageHelper;
        private readonly IConverterHelper _converterHelper;

        public TravelsController(
            DataContext context,
            IImageHelper imageHelper,
            IConverterHelper converterHelper)
        {
            _context = context;
            _imageHelper = imageHelper;
            _converterHelper = converterHelper;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context
                    .Travels
                    .Include(t => t.Expenses)
                    .OrderBy(t => t.StartDate)
                    .ToListAsync());
            }
            
            public IActionResult Create()
            {
                return View();
            }

            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Create(TravelViewModel model)
            {
                if (ModelState.IsValid)
                {
                    string path = string.Empty;

                    if (model.LogoFile != null)
                    {
                        path = await _imageHelper.UploadImageAsync(model.LogoFile, "Travels");
                    }

                    var travel = _converterHelper.ToTravelEntity(model, path, true);
                    _context.Add(travel);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }

                return View(model);
            }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TravelEntity travelEntity = await _context.Travels.FindAsync(id);
            if (travelEntity == null)
            {
                return NotFound();
            }

            TravelViewModel model = _converterHelper.ToTravelViewModel(travelEntity);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(TravelViewModel model)
        {
            if (ModelState.IsValid)
            {
                string path = model.LogoPath;

                if (model.LogoFile != null)
                {
                    path = await _imageHelper.UploadImageAsync(model.LogoFile, "Travels");
                }

                TravelEntity travelEntity = _converterHelper.ToTravelEntity(model, path, false);
                _context.Update(travelEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var travelEntity = await _context.Travels
                .FirstOrDefaultAsync(m => m.Id == id);
            if (travelEntity == null)
            {
                return NotFound();
            }

            _context.Travels.Remove(travelEntity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var travelEntity = await _context.Travels
                .Include(t => t.Expenses)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (travelEntity == null)
            {
                return NotFound();
            }

            return View(travelEntity);

        }
    }
}
