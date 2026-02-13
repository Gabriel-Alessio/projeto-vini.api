using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace projeto_vini.api.Data
{
  public static class InjectorConfig
  {
    public static IServiceCollection RegisterServices(this IServiceCollection services, IConfiguration configuration)
    {
      services.AddHttpContextAccessor();

      services.AddDbContext<ApiDbContext>(options =>
          options.UseNpgsql(
              configuration.GetConnectionString("DefaultConnection")));

      return services;
    }
  }
}
