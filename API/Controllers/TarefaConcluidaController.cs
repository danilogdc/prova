using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Data;


namespace API.Controllers
{
    [Route("api/tarefas/concluidas")]
    [ApiController]
    public class TarefaConcluidaController : ControllerBase
    {
        private readonly AppDataContext _context;

        public TarefaConcluidaController(AppDataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetTarefasConcluidas()
        {
            try
            {
                var tarefasConcluidas = await _context.Tarefas
                    .Where(t => t.Status == "Concluída")
                    .ToListAsync();

                return Ok(tarefasConcluidas);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
