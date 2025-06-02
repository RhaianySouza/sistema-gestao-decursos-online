/**
 * Controller: CursoController
 * Descrição: Controla as operações CRUD relacionadas à entidade 'Curso'.
 * Data de Criação: 29/04/2025
 */
using sistema_gestao_decursos_online.Models;
using sistema_gestao_decursos_online.Database;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace sistema_gestao_decursos_online.Controllers
{
    public class CursoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CursoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /Curso
        public async Task<IActionResult> Index()
        {
            return View(await _context.Cursos.OrderBy(c => c.Titulo).ToListAsync());
        }

        // GET: /Curso/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Curso/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Titulo,Descricao,CargaHoraria")] CursoModel curso)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(curso);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Não foi possível inserir os dados.");
            }
            return View(curso);
        }

        // GET: /Curso/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var curso = await _context.Cursos.FindAsync(id);
            if (curso == null) return NotFound();

            return View(curso);
        }

        // POST: /Curso/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CursoId,Titulo,Descricao,CargaHoraria")] CursoModel curso)
        {
            if (id != curso.CursoId) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(curso);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CursoExists(curso.CursoId))
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
            return View(curso);
        }

        // GET: /Curso/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var curso = await _context.Cursos
                .SingleOrDefaultAsync(c => c.CursoId == id);
            if (curso == null) return NotFound();

            return View(curso);
        }

        // POST: /Curso/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var curso = await _context.Cursos.FindAsync(id);
            _context.Cursos.Remove(curso);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: /Curso/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var curso = await _context.Cursos
                .Include(c => c.Matriculas)
                .Include(c => c.CursosUsuarios)
                .FirstOrDefaultAsync(c => c.CursoId == id);

            if (curso == null) return NotFound();

            return View(curso);
        }

        private bool CursoExists(int id)
        {
            return _context.Cursos.Any(e => e.CursoId == id);
        }
    }
}
