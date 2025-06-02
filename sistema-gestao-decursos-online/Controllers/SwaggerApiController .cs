using Microsoft.AspNetCore.Mvc;
using sistema_gestao_decursos_online.Database;
using sistema_gestao_decursos_online.Models;
using Microsoft.EntityFrameworkCore;
public class SwaggerApiController : Controller
{
    private readonly ApplicationDbContext _context;

    public SwaggerApiController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CursoModel>>> GetCursos()
    {
        return await _context.Cursos.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CursoModel>> GetCurso(int id)
    {
        var curso = await _context.Cursos.FindAsync(id);

        if (curso == null)
            return NotFound();

        return curso;
    }
}
