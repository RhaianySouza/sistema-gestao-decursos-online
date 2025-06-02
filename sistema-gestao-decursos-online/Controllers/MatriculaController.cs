using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sistema_gestao_decursos_online.Database;
using sistema_gestao_decursos_online.Models;

namespace sistema_gestao_decursos_online.Controllers
{
    public class MatriculaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MatriculaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /Matricula
        public async Task<IActionResult> Index()
        {
            var matriculas = _context.Matriculas
                .Include(m => m.Usuario)
                .Include(m => m.Curso)
                .OrderByDescending(m => m.DataMatricula);
            return View(await matriculas.ToListAsync());
        }

        // GET: /Matricula/Create
        public IActionResult Create()
        {
            ViewData["Usuarios"] = _context.Usuarios.ToList();
            ViewData["Cursos"] = _context.Cursos.ToList();
            return View();
        }

        // POST: /Matricula/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UsuarioId,CursoId,DataMatricula,Status")] MatriculaModel matricula)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(matricula);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Não foi possível registrar a matrícula.");
            }

            ViewData["Usuarios"] = _context.Usuarios.ToList();
            ViewData["Cursos"] = _context.Cursos.ToList();
            return View(matricula);
        }

        // GET: /Matricula/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var matricula = await _context.Matriculas.FindAsync(id);
            if (matricula == null) return NotFound();

            ViewData["Usuarios"] = _context.Usuarios.ToList();
            ViewData["Cursos"] = _context.Cursos.ToList();
            return View(matricula);
        }

        // POST: /Matricula/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MatriculaId,UsuarioId,CursoId,DataMatricula,Status")] MatriculaModel matricula)
        {
            if (id != matricula.MatriculaId) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(matricula);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MatriculaExists(matricula.MatriculaId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }

            ViewData["Usuarios"] = _context.Usuarios.ToList();
            ViewData["Cursos"] = _context.Cursos.ToList();
            return View(matricula);
        }

        // GET: /Matricula/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var matricula = await _context.Matriculas
                .Include(m => m.Usuario)
                .Include(m => m.Curso)
                .FirstOrDefaultAsync(m => m.MatriculaId == id);

            if (matricula == null) return NotFound();

            return View(matricula);
        }

        // POST: /Matricula/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var matricula = await _context.Matriculas.FindAsync(id);
            _context.Matriculas.Remove(matricula);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: /Matricula/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var matricula = await _context.Matriculas
                .Include(m => m.Usuario)
                .Include(m => m.Curso)
                .FirstOrDefaultAsync(m => m.MatriculaId == id);

            if (matricula == null) return NotFound();

            return View(matricula);
        }

        private bool MatriculaExists(int id)
        {
            return _context.Matriculas.Any(m => m.MatriculaId == id);
        }
    }
}
