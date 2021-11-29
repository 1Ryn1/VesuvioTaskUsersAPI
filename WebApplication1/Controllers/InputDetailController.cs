using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InputDetailController : ControllerBase
    {
        private readonly InputDetailContext _context;

        public InputDetailController(InputDetailContext context)
        {
            _context = context;
        }

        // GET: api/InputDetail
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InputDetail>>> GetInputDetails()
        {
            return await _context.InputDetails.ToListAsync();

        }

        // GET: api/InputDetail/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InputDetail>> GetInputDetail(int id)
        {
            var inputDetail = await _context.InputDetails.FindAsync(id);

            if (inputDetail == null)
            {
                return NotFound();
            }

            return inputDetail;
        }

        // PUT: api/InputDetail/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInputDetail(int id, InputDetail inputDetail)
        {
            if (id != inputDetail.UserId)
            {
                return BadRequest();
            }

            _context.Entry(inputDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InputDetailExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/InputDetail
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<InputDetail>> PostInputDetail(InputDetail inputDetail)
        {
            _context.InputDetails.Add(inputDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInputDetail", new { id = inputDetail.UserId }, inputDetail);
        }

        // DELETE: api/InputDetail/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInputDetail(int id)
        {
            var inputDetail = await _context.InputDetails.FindAsync(id);
            if (inputDetail == null)
            {
                return NotFound();
            }

            _context.InputDetails.Remove(inputDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InputDetailExists(int id)
        {
            return _context.InputDetails.Any(e => e.UserId == id);
        }
    }
}
