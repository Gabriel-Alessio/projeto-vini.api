namespace projeto_vini.api.Dominio
{
  public class Pais : Base
  {
    public Pais(string nome, string sigla)
    {
      Nome = nome;
      Sigla = sigla;
    }

    public virtual string Nome { get; set; } = null!;
    public virtual string Sigla { get; set; } = null!;
  }
}
