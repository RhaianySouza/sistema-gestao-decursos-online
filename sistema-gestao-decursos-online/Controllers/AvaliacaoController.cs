/**
 * Controller: AvaliacaoController
 * Descrição: Controla as operações CRUD relacionadas à entidade 'Avaliacao'.
 * Data de Criação: 29/04/2025
 */
using sistema_gestao_decursos_online.Models;
using sistema_gestao_decursos_online.Database;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace sistema_gestao_decursos_online.Controllers
{
    public class AvaliacaoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AvaliacaoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /Avaliacao
        public async Task<IActionResult> Index()
        {
            var avaliacoes = _context.Avaliacoes
                .Include(a => a.Matricula)
                    .ThenInclude(m => m.Usuario)
                .Include(a => a.Matricula.Curso);
            return View(await avaliacoes.ToListAsync());
        }

        // GET: /Avaliacao/Create
        public IActionResult Create()
        {
            
            return View();
        }

        // POST: /Avaliacao/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UsuarioId,CursoId,Nota,Comentario,Data")] AvaliacaoModel avaliacao)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(avaliacao);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Não foi possível inserir os dados.");
            }
            return View(avaliacao);
        }

        // GET: /Avaliacao/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var avaliacao = await _context.Avaliacoes.FindAsync(id);
            if (avaliacao == null) return NotFound();

            return View(avaliacao);
        }

        // POST: /Avaliacao/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AvaliacaoId,UsuarioId,CursoId,Nota,Comentario,Data")] AvaliacaoModel avaliacao)
        {
            if (id != avaliacao.AvaliacaoId) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(avaliacao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AvaliacaoExists(avaliacao.AvaliacaoId))
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
            return View(avaliacao);
        }

        // GET: /Avaliacao/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var avaliacao = await _context.Avaliacoes
                .Include(a => a.Matricula)
                    .ThenInclude(m => m.Usuario)
                .Include(a => a.Matricula.Curso)
                .SingleOrDefaultAsync(a => a.AvaliacaoId == id);
            if (avaliacao == null) return NotFound();

            return View(avaliacao);
        }

        // POST: /Avaliacao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var avaliacao = await _context.Avaliacoes.FindAsync(id);
            _context.Avaliacoes.Remove(avaliacao);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: /Avaliacao/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var avaliacao = await _context.Avaliacoes
                .Include(a => a.Matricula)
                    .ThenInclude(m => m.Usuario)
                .Include(a => a.Matricula.Curso)
                .FirstOrDefaultAsync(a => a.AvaliacaoId == id);

            if (avaliacao == null) return NotFound();

            return View(avaliacao);
        }

        private bool AvaliacaoExists(int id)
        {
            return _context.Avaliacoes.Any(e => e.AvaliacaoId == id);
        }
    }
}
