using Microsoft.EntityFrameworkCore;
using projeto_vini.api.Data;
using projeto_vini.api.Dominio;
using projeto_vini.api.IRepository;

namespace projeto_vini.api.Repository
{
  public class PaisRepository : IPaisRepository
  {
    private readonly ApiDbContext _context;

    public PaisRepository(ApiDbContext context)
    {
      _context = context;
    }

    public async Task Adicionar(Pais pais)
    {
      await _context.Set<Pais>().AddAsync(pais);
    }
  }
}
