using projeto_vini.api.Dominio;
using projeto_vini.api.IServices;
using projeto_vini.api.Request;

namespace projeto_vini.api.Services
{
  public class CidadeService : ICidadeService
  {
    public Task<PaisNovoCommandResponse> Salvar(PaisNovoCommand command)
    {
      var entity = new Pais(command.Nome, command.Sigla);


      return Task.FromResult(new PaisNovoCommandResponse
      {
        Id = entity.Id,
      });
    }
  }
}
