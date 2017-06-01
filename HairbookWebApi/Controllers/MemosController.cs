using HairbookWebApi.Database;
using HairbookWebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HairbookWebApi.Controllers
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class MemosController : Controller
    {
        private readonly HairbookContext _context;

        public MemosController(HairbookContext context)
        {
            _context = context;
        }

        // GET: api/Memos
        [HttpGet]
        public async Task<IEnumerable<Memo>> GetMemos([FromQuery] int skip = 0, [FromQuery] int take = 10)
        {
            return await _context.Memos
                    .Skip(skip)
                    .Take(take)
                    .ToListAsync();
        }

        // GET: api/Memos/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMemo([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var memo = await _context.Memos.SingleOrDefaultAsync(m => m.MemoId == id);

            if (memo == null)
            {
                return NotFound();
            }

            return Ok(memo);
        }

        // PUT: api/Memos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMemo([FromRoute] int id, [FromBody] Memo memo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != memo.MemoId)
            {
                return BadRequest();
            }

            _context.Entry(memo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MemoExists(id))
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

        // POST: api/Memos
        [HttpPost]
        public async Task<IActionResult> PostMemo([FromBody] Memo memo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Memos.Add(memo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMemo", new { id = memo.MemoId }, memo);
        }

        // DELETE: api/Memos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMemo([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var memo = await _context.Memos.SingleOrDefaultAsync(m => m.MemoId == id);
            if (memo == null)
            {
                return NotFound();
            }

            _context.Memos.Remove(memo);
            await _context.SaveChangesAsync();

            return Ok(memo);
        }

        private bool MemoExists(int id)
        {
            return _context.Memos.Any(e => e.MemoId == id);
        }
    }
}