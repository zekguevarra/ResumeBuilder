using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ResumeBuilder.Models;

namespace ResumeBuilder.Controllers
{
    public class LinksController : Controller
    {
        private readonly TupContext _context;
        public class Dropdown
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        public LinksController(TupContext context)
        {
            _context = context;
        }

        // GET: Links
        public async Task<IActionResult> Index()
        {
            var tupContext = _context.Links.Include(l => l.Student);
            return View(await tupContext.ToListAsync());
        }

        // GET: Links/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Links == null)
            {
                return NotFound();
            }

            var link = await _context.Links
                .Include(l => l.Student)
                .FirstOrDefaultAsync(m => m.LinkId == id);
            if (link == null)
            {
                return NotFound();
            }

            return View(link);
        }

        // GET: Links/Create
        public IActionResult Create()
        {
            var students = _context.Students.Select(x => new Dropdown
            {
                Id = x.Id,
                Name = x.Firstname + ' ' + x.Middlename + ' ' + x.Lastname
            }).ToList();
            ViewData["StudentId"] = new SelectList(students, "Id", "Name");
            return View();
        }

        // POST: Links/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LinkId,Facebook,LinkedIn,Github,Portfolio,StudentId")] Link link)
        {
            if (ModelState.IsValid)
            {
                _context.Add(link);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["StudentId"] = new SelectList(_context.Students, "Id", "Id", link.StudentId);
            return View(link);
        }

        // GET: Links/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Links == null)
            {
                return NotFound();
            }

            var link = await _context.Links.FindAsync(id);
            if (link == null)
            {
                return NotFound();
            }
            var students = _context.Students.Select(x => new Dropdown
            {
                Id = x.Id,
                Name = x.Firstname + ' ' + x.Middlename + ' ' + x.Lastname
            }).ToList();
            ViewData["StudentId"] = new SelectList(students, "Id", "Name", link.StudentId);
            return View(link);
        }

        // POST: Links/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LinkId,Facebook,LinkedIn,Github,Portfolio,StudentId")] Link link)
        {
            if (id != link.LinkId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(link);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LinkExists(link.LinkId))
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
            ViewData["StudentId"] = new SelectList(_context.Students, "Id", "Id", link.StudentId);
            return View(link);
        }

        // GET: Links/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Links == null)
            {
                return NotFound();
            }

            var link = await _context.Links
                .Include(l => l.Student)
                .FirstOrDefaultAsync(m => m.LinkId == id);
            if (link == null)
            {
                return NotFound();
            }

            return View(link);
        }

        // POST: Links/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Links == null)
            {
                return Problem("Entity set 'TupContext.Links'  is null.");
            }
            var link = await _context.Links.FindAsync(id);
            if (link != null)
            {
                _context.Links.Remove(link);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LinkExists(int id)
        {
          return (_context.Links?.Any(e => e.LinkId == id)).GetValueOrDefault();
        }
    }
}
