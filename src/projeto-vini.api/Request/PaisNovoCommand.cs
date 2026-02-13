using System.ComponentModel.DataAnnotations;

namespace projeto_vini.api.Request
{
  public record PaisNovoCommand
  {
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    public string Nome { get; set; } = null!;

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    public string Sigla { get; set; } = null!;
  }
}
