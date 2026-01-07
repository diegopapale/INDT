using INDT.ContratacaoService.Api.Dtos;
using INDT.ContratacaoService.Application.UseCases.ContratarProposta;
using INDT.ContratacaoService.Application.UseCases.ListarContratacoes;
using Microsoft.AspNetCore.Mvc;

namespace INDT.ContratacaoService.Api.Controllers;
[ApiController]
[Route("contratacoes")]
public class ContratacoesController : ControllerBase
{
    private readonly ContratarPropostaUseCase _useCase;
    private readonly ListarContratacoesUseCase _listarContratacoesUseCase;

    public ContratacoesController(ContratarPropostaUseCase useCase, ListarContratacoesUseCase listarContratacoesUse)
    {
        _useCase = useCase;
        _listarContratacoesUseCase = listarContratacoesUse;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Contratar([FromBody] ContratarPropostaRequest request)
    {
        await _useCase.ExecutarAsync(request.PropostaId);
        return NoContent();
    }

    [HttpGet]
    public async Task<IActionResult> Listar()
    {
        var contratacoes = await _listarContratacoesUseCase.ExecutarAsync();
        return Ok(contratacoes);
    }
}