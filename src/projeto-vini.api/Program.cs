using Microsoft.OpenApi;
using projeto_vini.api.Data;
using projeto_vini.api.IRepository;
using projeto_vini.api.IServices;
using projeto_vini.api.Repository;
using projeto_vini.api.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddControllers();
builder.Services.RegisterServices(builder.Configuration);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSwaggerGen(options =>
{
  options.SwaggerDoc("v1", new OpenApiInfo
  {
    Title = "GK Studio API",
    Version = "v1"
  });
});

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ICidadeService, CidadeService>();
builder.Services.AddScoped<IPaisRepository, PaisRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();

  app.UseSwaggerUI(options =>
  {
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "Vini API v1");
    options.RoutePrefix = string.Empty;

    options.DocumentTitle = "Vini API - Swagger";
    options.DisplayRequestDuration();
    options.EnableTryItOutByDefault();
  });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
