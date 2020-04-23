using Expenditure.Web.Data.Entities;
using Expenditure.Web.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Expenditure.Web.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class TravelsController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IConverterHelper _converterHelper;

        public TravelsController(
                DataContext context,
                IConverterHelper converterHelper)
        {
            _context = context;
            _converterHelper = converterHelper;
        }

        [HttpGet]
        public async Task<IActionResult> GetTravels()
        {
            List<TravelEntity> Travels = await _context.Travels
                .Include(t => t.Expenses)
                .ToListAsync();
            return Ok(_converterHelper.ToTravelResponse(Travels));
        }
    }
}
