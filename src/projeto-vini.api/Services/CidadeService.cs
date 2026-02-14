using projeto_vini.api.Data;
using projeto_vini.api.Dominio;
using projeto_vini.api.IRepository;
using projeto_vini.api.IServices;
using projeto_vini.api.Request;

namespace projeto_vini.api.Services
{
  public class CidadeService : ICidadeService
  {
    private readonly IPaisRepository _paisRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CidadeService(IPaisRepository paisRepository, IUnitOfWork unitOfWork)
    {
      _paisRepository = paisRepository;
      _unitOfWork = unitOfWork;
    }

    public async Task<PaisNovoCommandResponse> Salvar(PaisNovoCommand command)
    {
      await _unitOfWork.BeginTransactionAsync();

      try
      {
        var entity = new Pais(command.Nome, command.Sigla);

        await _paisRepository.Adicionar(entity);

        await _unitOfWork.CommitTransactionAsync();

        return new PaisNovoCommandResponse
        {
          Id = entity.Id
        };
      }
      catch
      {
        await _unitOfWork.RollbackTransactionAsync();
        throw;
      }
    }
  }
}
