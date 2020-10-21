using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ONoticiarioCore.Data;
using ONoticiarioCore.Models;

namespace ONoticiarioCore.Controllers
{
    public class Categoria_NoticiasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public Categoria_NoticiasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Categoria_Noticias
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Categoria_Noticias.Include(c => c.Categorias).Include(c => c.Noticias);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Categoria_Noticias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoria_Noticias = await _context.Categoria_Noticias
                .Include(c => c.Categorias)
                .Include(c => c.Noticias)
                .FirstOrDefaultAsync(m => m.CategoriaIdFK == id);
            if (categoria_Noticias == null)
            {
                return NotFound();
            }

            return View(categoria_Noticias);
        }

        // GET: Categoria_Noticias/Create
        public IActionResult Create()
        {
            ViewData["CategoriaIdFK"] = new SelectList(_context.Categorias, "ID", "ID");
            ViewData["NoticiaIdFK"] = new SelectList(_context.Noticias, "ID", "Conteudo");
            return View();
        }

        // POST: Categoria_Noticias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CategoriaIdFK,NoticiaIdFK")] Categoria_Noticias categoria_Noticias)
        {
            if (ModelState.IsValid)
            {
                _context.Add(categoria_Noticias);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoriaIdFK"] = new SelectList(_context.Categorias, "ID", "ID", categoria_Noticias.CategoriaIdFK);
            ViewData["NoticiaIdFK"] = new SelectList(_context.Noticias, "ID", "Conteudo", categoria_Noticias.NoticiaIdFK);
            return View(categoria_Noticias);
        }

        // GET: Categoria_Noticias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoria_Noticias = await _context.Categoria_Noticias.FindAsync(id);
            if (categoria_Noticias == null)
            {
                return NotFound();
            }
            ViewData["CategoriaIdFK"] = new SelectList(_context.Categorias, "ID", "ID", categoria_Noticias.CategoriaIdFK);
            ViewData["NoticiaIdFK"] = new SelectList(_context.Noticias, "ID", "Conteudo", categoria_Noticias.NoticiaIdFK);
            return View(categoria_Noticias);
        }

        // POST: Categoria_Noticias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CategoriaIdFK,NoticiaIdFK")] Categoria_Noticias categoria_Noticias)
        {
            if (id != categoria_Noticias.CategoriaIdFK)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(categoria_Noticias);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Categoria_NoticiasExists(categoria_Noticias.CategoriaIdFK))
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
            ViewData["CategoriaIdFK"] = new SelectList(_context.Categorias, "ID", "ID", categoria_Noticias.CategoriaIdFK);
            ViewData["NoticiaIdFK"] = new SelectList(_context.Noticias, "ID", "Conteudo", categoria_Noticias.NoticiaIdFK);
            return View(categoria_Noticias);
        }

        // GET: Categoria_Noticias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoria_Noticias = await _context.Categoria_Noticias
                .Include(c => c.Categorias)
                .Include(c => c.Noticias)
                .FirstOrDefaultAsync(m => m.CategoriaIdFK == id);
            if (categoria_Noticias == null)
            {
                return NotFound();
            }

            return View(categoria_Noticias);
        }

        // POST: Categoria_Noticias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var categoria_Noticias = await _context.Categoria_Noticias.FindAsync(id);
            _context.Categoria_Noticias.Remove(categoria_Noticias);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Categoria_NoticiasExists(int id)
        {
            return _context.Categoria_Noticias.Any(e => e.CategoriaIdFK == id);
        }
    }
}
