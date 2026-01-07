using INDT.PropostaService.Api.Controllers.Models;
using INDT.PropostaService.Application.UseCases.AlterarStatusProposta;
using INDT.PropostaService.Application.UseCases.CriarProposta;
using INDT.PropostaService.Application.UseCases.ListarPropostas;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace INDT.PropostaService.Api.Controllers;

[ApiController]
[Route("propostas")]
public class PropostasController : ControllerBase
{
    private readonly CriarPropostaUseCase _criarUseCase;
    private readonly ListarPropostasUseCase _listarUseCase;
    private readonly AlterarStatusPropostaUseCase _alterarStatusUseCase;

    public PropostasController(
        CriarPropostaUseCase criarUseCase,
        ListarPropostasUseCase listarUseCase,
        AlterarStatusPropostaUseCase alterarStatusUseCase)
    {
        _criarUseCase = criarUseCase;
        _listarUseCase = listarUseCase;
        _alterarStatusUseCase = alterarStatusUseCase;
    }

    
    [HttpPost]
    public async Task<IActionResult> Criar([FromBody] CriarPropostaRequest request)
    {
        var id = await _criarUseCase.ExecutarAsync(request.ClienteNome);
        return CreatedAtAction(nameof(ObterTodas), new { id }, null);
    }

    [HttpGet]
    public async Task<IActionResult> ObterTodas()
    {
        var propostas = await _listarUseCase.ExecutarAsync();
        return Ok(propostas);
    }

    [HttpPost("{id}/aprovar")]
    public async Task<IActionResult> Aprovar(Guid id)
    {
        await _alterarStatusUseCase.AprovarAsync(id);
        return NoContent();
    }

    [HttpPost("{id}/rejeitar")]
    public async Task<IActionResult> Rejeitar(Guid id)
    {
        await _alterarStatusUseCase.RejeitarAsync(id);
        return NoContent();
    }
}