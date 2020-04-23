using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Expenditure.Web.Data.Entities;

namespace Expenditure.Web.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpendituresController : ControllerBase
    {
        private readonly DataContext _context;

        public ExpendituresController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Expenditures
        [HttpGet]
        public IEnumerable<ExpenditureEntity> GetExpenses()
        {
            return _context.Expenses;
        }

        // GET: api/Expenditures/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetExpenditureEntity([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var expenditureEntity = await _context.Expenses.FindAsync(id);

            if (expenditureEntity == null)
            {
                return NotFound();
            }

            return Ok(expenditureEntity);
        }

    }
}