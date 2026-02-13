using projeto_vini.api.Request;

namespace projeto_vini.api.IServices
{
  public interface ICidadeService
  {
    Task<PaisNovoCommandResponse> Salvar(PaisNovoCommand command);
  }
}
