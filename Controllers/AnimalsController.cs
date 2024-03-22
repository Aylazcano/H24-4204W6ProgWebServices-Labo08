using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using H24_4204W6ProgWebServices_Labo08.Data;
using H24_4204W6ProgWebServices_Labo08.Models;

namespace H24_4204W6ProgWebServices_Labo08.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AnimalsController : ControllerBase
    {
        private readonly H24_4204W6ProgWebServices_Labo08Context _context;

        public AnimalsController(H24_4204W6ProgWebServices_Labo08Context context)
        {
            _context = context;
        }

        // GET: api/Animals
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Animal>>> GetAnimal()
        {
          if (_context.Animal == null)
          {
              return NotFound();
          }
            return await _context.Animal.ToListAsync();
        }

        // GET: api/Animals/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Animal>> GetAnimal(int id)
        {
          if (_context.Animal == null)
          {
              return NotFound();
          }
            var animal = await _context.Animal.FindAsync(id);

            if (animal == null)
            {
                return NotFound();
            }

            return animal;
        }

        // PUT: api/Animals/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAnimal(int id, Animal animal)
        {
            if (id != animal.Id)
            {
                return BadRequest();
            }

            _context.Entry(animal).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnimalExists(id))
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

        // POST: api/Animals
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Animal>> PostAnimal(Animal animal)
        {
          if (_context.Animal == null)
          {
              return Problem("Entity set 'H24_4204W6ProgWebServices_Labo08Context.Animal'  is null.");
          }
            _context.Animal.Add(animal);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAnimal", new { id = animal.Id }, animal);
        }

        // DELETE: api/Animals/5
        [HttpPost]
        [Route("/api/destroy/{id}")]
        public async Task<IActionResult> DeleteAnimal(int id)
        {
            if (_context.Animal == null)
            {
                return NotFound();
            }
            var animal = await _context.Animal.FindAsync(id);
            if (animal == null)
            {
                return NotFound();
            }

            _context.Animal.Remove(animal);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AnimalExists(int id)
        {
            return (_context.Animal?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
