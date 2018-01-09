using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CoraCorpCM.Data;
using CoraCorpCM.Models;

namespace CoraCorpCM.Controllers
{
    public class CollectionController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CollectionController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Collection
        public async Task<IActionResult> Index()
        {
            return View(await _context.Piece.ToListAsync());
        }

        // GET: Collection/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var piece = await _context.Piece
                .SingleOrDefaultAsync(m => m.Id == id);
            if (piece == null)
            {
                return NotFound();
            }

            return View(piece);
        }

        // GET: Collection/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Collection/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,RecordNumber,AccessionNumber,Title,CreationDate,Height,Width,Depth,EstimatedValue,Subject,CopyrightYear,CopyrightOwner,IsFramed,Created,LastModified")] Piece piece)
        {
            if (ModelState.IsValid)
            {
                _context.Add(piece);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(piece);
        }

        // GET: Collection/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var piece = await _context.Piece.SingleOrDefaultAsync(m => m.Id == id);
            if (piece == null)
            {
                return NotFound();
            }
            return View(piece);
        }

        // POST: Collection/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,RecordNumber,AccessionNumber,Title,CreationDate,Height,Width,Depth,EstimatedValue,Subject,CopyrightYear,CopyrightOwner,IsFramed,Created,LastModified")] Piece piece)
        {
            if (id != piece.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(piece);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PieceExists(piece.Id))
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
            return View(piece);
        }

        // GET: Collection/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var piece = await _context.Piece
                .SingleOrDefaultAsync(m => m.Id == id);
            if (piece == null)
            {
                return NotFound();
            }

            return View(piece);
        }

        // POST: Collection/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var piece = await _context.Piece.SingleOrDefaultAsync(m => m.Id == id);
            _context.Piece.Remove(piece);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PieceExists(int id)
        {
            return _context.Piece.Any(e => e.Id == id);
        }
    }
}
