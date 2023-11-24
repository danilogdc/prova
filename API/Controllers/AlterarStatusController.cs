using Microsoft.AspNetCore.Mvc;
using API.Data;
using API.Models;

namespace API.Controllers
{
    [Route("api/tarefas/alterarstatus")]
    [ApiController]
    public class AlterarStatusTarefaController : ControllerBase
    {
        private readonly AppDataContext _context;

        public AlterarStatusTarefaController(AppDataContext context)
        {
            _context = context;
        }

        [HttpPatch]
        public async Task<IActionResult> AlterarStatusTarefa([FromBody] Tarefa tarefa)
        {
            try
            {
                var tarefaExistente = await _context.Tarefas.FindAsync(tarefa.TarefaId);

                if (tarefaExistente == null)
                {
                    return NotFound("Tarefa não encontrada");
                }

                if (tarefaExistente.Status == "Não iniciada")
                {
                    tarefaExistente.Status = "Em andamento";
                }
                else if (tarefaExistente.Status == "Em andamento")
                {
                    tarefaExistente.Status = "Concluída";
                }

                await _context.SaveChangesAsync();

                return Ok(tarefaExistente);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
