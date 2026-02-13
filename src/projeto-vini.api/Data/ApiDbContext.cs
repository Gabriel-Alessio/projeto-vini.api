using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using projeto_vini.api.Dominio;

namespace projeto_vini.api.Data
{
  public class ApiDbContext : DbContext
  {
    private readonly IHttpContextAccessor _httpContextAccessor;

    public ApiDbContext(
      DbContextOptions<ApiDbContext> options,
      IHttpContextAccessor httpContextAccessor) : base(options)
    {
      _httpContextAccessor = httpContextAccessor;
    }
    public DbSet<Pais> Pais { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      base.OnModelCreating(builder);

      ConfigurarPais(builder);

      builder.ApplyConfigurationsFromAssembly(typeof(ApiDbContext).Assembly);
    }

    private void ConfigurarPais(ModelBuilder builder)
    {
      builder.Entity<Pais>(entity =>
      {
        entity.Property(e => e.Nome).IsRequired().HasMaxLength(100);
        entity.Property(e => e.Sigla).HasMaxLength(2);
      });
    }
  }
}
