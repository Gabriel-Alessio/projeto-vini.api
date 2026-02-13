using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using projeto_vini.api.IServices;
using projeto_vini.api.Request;

namespace projeto_vini.api.Controllers
{
  [Route("api/cidade")]
  [ApiController]
  public class CidadesController : ControllerBase
  {
    private readonly ICidadeService _cidadeService;

    public CidadesController(ICidadeService cidadeService)
    {
      _cidadeService = cidadeService;
    }

    /// <summary>
    /// Cadastrar Usuários
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    [ProducesResponseType(typeof(PaisNovoCommandResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(PaisNovoCommandResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    [AllowAnonymous]
    [HttpPost]
    public async Task<PaisNovoCommandResponse> Post([FromBody] PaisNovoCommand command)
      => await _cidadeService.Salvar(command);
  }
}
