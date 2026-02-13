using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using projeto_vini.api.Data;

public class ApiDbContextFactory
    : IDesignTimeDbContextFactory<ApiDbContext>
{
  public ApiDbContext CreateDbContext(string[] args)
  {
    var optionsBuilder = new DbContextOptionsBuilder<ApiDbContext>();

    optionsBuilder.UseNpgsql(
        "Host=localhost;Port=5432;Database=vini;Username=postgres;Password=postgres");

    return new ApiDbContext(
        optionsBuilder.Options,
        new HttpContextAccessor());
  }
}