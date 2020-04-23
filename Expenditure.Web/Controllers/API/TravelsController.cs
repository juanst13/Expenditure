using Expenditure.Web.Data.Entities;
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

        public TravelsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetTravels()
        {
            List<TravelEntity> Travels = await _context.Travels
                .Include(t => t.Expenses)
                .ToListAsync();
            return Ok(Travels);
        }
    }
}
