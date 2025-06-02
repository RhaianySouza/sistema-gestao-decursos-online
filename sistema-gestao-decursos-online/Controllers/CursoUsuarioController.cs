/**
 * Controller: CursoUsuarioController
 * Descrição: Controla as operações CRUD relacionadas à entidade 'CursoUsuario', que representa a associação entre 'Usuario' e 'Curso'.
 * Data de Criação: 29/04/2025
 */
using sistema_gestao_decursos_online.Models;
using sistema_gestao_decursos_online.Database;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace sistema_gestao_decursos_online.Controllers
{
    public class CursoUsuarioController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CursoUsuarioController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /CursoUsuario
        public async Task<IActionResult> Index()
        {
            var cursoUsuarios = await _context.CursosUsuarios
                .Include(cu => cu.Usuario)
                .Include(cu => cu.Curso)
                .ToListAsync();

            return View(cursoUsuarios);
        }

        // GET: /CursoUsuario/Create
        public IActionResult Create()
        {
            ViewBag.Usuarios = _context.Usuarios.ToList();
            ViewBag.Cursos = _context.Cursos.ToList();
            return View();
        }

        // POST: /CursoUsuario/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UsuarioId,CursoId")] CursoUsuarioModel cursoUsuario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cursoUsuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Usuarios = _context.Usuarios.ToList();
            ViewBag.Cursos = _context.Cursos.ToList();
            return View(cursoUsuario);
        }

        // GET: /CursoUsuario/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var cursoUsuario = await _context.CursosUsuarios.FindAsync(id);
            if (cursoUsuario == null) return NotFound();

            ViewBag.Usuarios = _context.Usuarios.ToList();
            ViewBag.Cursos = _context.Cursos.ToList();

            return View(cursoUsuario);
        }

        // POST: /CursoUsuario/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UsuarioId,CursoId")] CursoUsuarioModel cursoUsuario)
        {
            if (id != cursoUsuario.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cursoUsuario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CursoUsuarioExists(cursoUsuario.Id))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Usuarios = _context.Usuarios.ToList();
            ViewBag.Cursos = _context.Cursos.ToList();
            return View(cursoUsuario);
        }

        // GET: /CursoUsuario/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var cursoUsuario = await _context.CursosUsuarios
                .Include(cu => cu.Usuario)
                .Include(cu => cu.Curso)
                .FirstOrDefaultAsync(cu => cu.Id == id);

            if (cursoUsuario == null) return NotFound();

            return View(cursoUsuario);
        }

        // POST: /CursoUsuario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cursoUsuario = await _context.CursosUsuarios.FindAsync(id);
            _context.CursosUsuarios.Remove(cursoUsuario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: /CursoUsuario/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var cursoUsuario = await _context.CursosUsuarios
                .Include(cu => cu.Usuario)
                .Include(cu => cu.Curso)
                .FirstOrDefaultAsync(cu => cu.Id == id);

            if (cursoUsuario == null) return NotFound();

            return View(cursoUsuario);
        }

        private bool CursoUsuarioExists(int id)
        {
            return _context.CursosUsuarios.Any(e => e.Id == id);
        }
    }
}
