using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using StartupIdeas.Models;
using StartupIdeas.Models.EFCore;

namespace StartupIdeas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdeasController : ControllerBase
    {
        private readonly StartupIdeasContext _context;

        public IdeasController(StartupIdeasContext context)
        {
            _context = context;
        }

        // GET api/ideas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Idea>>> GetIdeas()
        {
            return await _context.Ideas.ToListAsync();
        }

        // GET api/ideas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Idea>> GetIdea(int id)
        {
            var idea = await _context.Ideas.FindAsync(id);

            if (idea == null)
            {
                return NotFound();
            }

            return idea;
        }

        // POST api/ideas
        [HttpPost]
        public async Task<ActionResult<Idea>> PostIdea(Idea idea)
        {
            _context.Ideas.Add(idea);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIdea", new { id = idea.Id }, idea);
        }

        // PUT api/ideas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIdea(int id, Idea idea)
        {
            if (id != idea.Id)
            {
                return BadRequest();
            }

            _context.Entry(idea).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE api/ideas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Idea>> DeleteIdea(int id)
        {
            var idea = await _context.Ideas.FindAsync(id);

            if (idea == null)
            {
                return NotFound();
            }

            _context.Ideas.Remove(idea);
            await _context.SaveChangesAsync();

            return idea;
        }
    }
}
