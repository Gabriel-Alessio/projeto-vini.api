using projeto_vini.api.Dominio;

namespace projeto_vini.api.IRepository
{
  public interface IPaisRepository
  {
    Task Adicionar(Pais pais);
  }
}
