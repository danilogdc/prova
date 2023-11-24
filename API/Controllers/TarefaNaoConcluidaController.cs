using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Data;

namespace API.Controllers
{
    [Route("api/tarefas/naoconcluidas")]
    [ApiController]
    public class TarefaNaoConcluidaController : ControllerBase
    {
        private readonly AppDataContext _context;

        public TarefaNaoConcluidaController(AppDataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetTarefasNaoConcluidas()
        {
            try
            {
                var tarefasNaoConcluidas = await _context.Tarefas
                    .Where(t => t.Status == "Não iniciada" || t.Status == "Em andamento")
                    .ToListAsync();

                return Ok(tarefasNaoConcluidas);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
